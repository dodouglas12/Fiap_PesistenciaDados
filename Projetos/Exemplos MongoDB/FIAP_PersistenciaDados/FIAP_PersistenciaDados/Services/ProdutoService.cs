using FIAP_PersistenciaDados.Interfaces;
using FIAP_PersistenciaDados.Models;
using System.CodeDom;
using System.Collections;

namespace FIAP_PersistenciaDados.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string URL_API = "https://localhost:7120/api/Produtos/";

        public ProdutoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<Produto>> GetAllAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync<Produto[]>(URL_API + "GetAll");

            if (response != null)
            {
                return response.ToList();
            }
            else
            {
                return new List<Produto>();
            }
        }

        public async void CreateAsync(Produto produto)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.PostAsJsonAsync(URL_API + "Create", produto);
        }

        public async void UpdateByIdAsync(Produto produto)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.PostAsJsonAsync(URL_API + "Update", produto);
        }

        public async Task DeleteAsync(Produto produto)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.DeleteAsync(URL_API + $"Remove?id={produto.Id}");
        }

        public async Task<List<LogAlteracaoPreco>> RetornarLogsAsync(int? id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(URL_API + $"RetornarLogs?id={id}");

            if (response != null)
            {
                return await response.Content.ReadFromJsonAsync<List<LogAlteracaoPreco>>();
            }
            else
            {
                return new List<LogAlteracaoPreco>();
            }
        }
    }
}
