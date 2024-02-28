using FIAP_PersistenciaDadosBff.Models;

namespace FIAP_PersistenciaDadosBff.Interfaces
{
    public interface ILogAlteracaoPrecoService
    {
        public Task RegistrarLogAlteracaoPreco(int produtoId, decimal precoAntigo, decimal novoPreco);

        public Task<List<LogAlteracaoPreco>> ObterLogsPorProduto(int produtoId);
     }
}
