using FIAP_PersistenciaDadosBff.Interfaces;
using FIAP_PersistenciaDadosBff.Models;

namespace FIAP_PersistenciaDadosBff.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogAlteracaoPrecoService _logAlteracaoPrecoService;

        public ProdutoService(IProdutoRepository produtoRepository, 
                              ILogAlteracaoPrecoService logAlteracaoPrecoService)
        {
            _produtoRepository = produtoRepository;
            _logAlteracaoPrecoService = logAlteracaoPrecoService;
        }

        public async Task CreateAsync(Produto produto)
        {
            await _produtoRepository.CreateAsync(produto);
        }

        public async Task DeleteAsync(int id)
        {
            await _produtoRepository.DeleteAsync(id);
        }

        public async Task<IList<Produto>> GetAllAsync()
        {
            return await _produtoRepository.GetAllAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            await _produtoRepository.UpdateAsync(produto);
        }
        
        //********************************************************************
        //Métodos relacionados ao Mongo
        public async Task AtualizarPrecoProduto(int produtoId, decimal novoPreco)
        {
            // Lógica para atualizar o preço do produto
            var produto = (await GetAllAsync()).FirstOrDefault(x => x.Id.Equals(produtoId));
            var precoAntigo = produto.Preco;
            
            produto.Preco = novoPreco;
            await UpdateAsync(produto);

            // Registra um log de alteração de preço
            await _logAlteracaoPrecoService.RegistrarLogAlteracaoPreco(produtoId, precoAntigo, novoPreco);
        }

        public async Task<List<LogAlteracaoPreco>> ObterLogsAlteracaoPreco(int produtoId)
        {
            return await _logAlteracaoPrecoService.ObterLogsPorProduto(produtoId);
        }
    }
}
