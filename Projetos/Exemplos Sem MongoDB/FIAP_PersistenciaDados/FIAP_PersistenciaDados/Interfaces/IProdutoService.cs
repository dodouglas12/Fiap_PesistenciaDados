using FIAP_PersistenciaDados.Models;
using System.Collections;

namespace FIAP_PersistenciaDados.Interfaces
{
    public interface IProdutoService
    {
        public Task<IList<Produto>> GetAllAsync();

        public void CreateAsync(Produto produto); 

        public void UpdateByIdAsync(Produto produto);

        public Task DeleteAsync(Produto produto);
    }
}
