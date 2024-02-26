using FIAP_PersistenciaDados.Interfaces;
using FIAP_PersistenciaDados.Models;
using System.CodeDom;
using System.Collections;

namespace FIAP_PersistenciaDados.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string URL_API = "https://sua-api.com/api/produtos";

        public ProdutoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<Produto>> GetAllAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync<Produto[]>(URL_API);

            if (response != null)
            {
                return response;
            }
            else
            {
                return new List<Produto>();
            }
        }

        public async void CreateAsync(Produto produto)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.PostAsJsonAsync(URL_API, produto);
        }

        public async void UpdateByIdAsync(Produto produto)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.PostAsJsonAsync(URL_API, produto);
        }

        public async void DeleteAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.PostAsJsonAsync(URL_API, id);
        }
    }
}
