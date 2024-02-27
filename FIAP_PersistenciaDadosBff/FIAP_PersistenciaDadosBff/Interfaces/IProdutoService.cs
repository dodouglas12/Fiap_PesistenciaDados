using FIAP_PersistenciaDadosBff.Models;

namespace FIAP_PersistenciaDadosBff.Interfaces
{
    public interface IProdutoService
    {
        public Task<IList<Produto>> GetAllAsync();

        public Task CreateAsync(Produto produto);

        public Task UpdateAsync(Produto produto);

        public Task DeleteAsync(int id);
    }
}
