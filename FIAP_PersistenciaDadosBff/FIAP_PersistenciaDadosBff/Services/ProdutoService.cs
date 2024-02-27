using FIAP_PersistenciaDadosBff.Interfaces;
using FIAP_PersistenciaDadosBff.Models;

namespace FIAP_PersistenciaDadosBff.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
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
    }
}
