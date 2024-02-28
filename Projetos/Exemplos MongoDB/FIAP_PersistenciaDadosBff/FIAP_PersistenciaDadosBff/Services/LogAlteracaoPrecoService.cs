using FIAP_PersistenciaDadosBff.Interfaces;
using FIAP_PersistenciaDadosBff.Models;
using MongoDB.Driver;

namespace FIAP_PersistenciaDadosBff.Services
{
    public class LogAlteracaoPrecoService : ILogAlteracaoPrecoService
    {
        private readonly IMongoCollection<LogAlteracaoPreco> _logCollection;

        public LogAlteracaoPrecoService(IMongoClient database)
        {
            _logCollection = database.GetDatabase("Fiap").GetCollection<LogAlteracaoPreco>("LogsAlteracaoPreco");
        }

        public async Task<List<LogAlteracaoPreco>> ObterLogsPorProduto(int produtoId)
        {
            var filter = Builders<LogAlteracaoPreco>.Filter.Eq(l => l.ProdutoId, produtoId);
            return await _logCollection.Find(filter).ToListAsync();
        }

        public async Task RegistrarLogAlteracaoPreco(int produtoId, decimal precoAntigo, decimal novoPreco)
        {
            var log = new LogAlteracaoPreco
            {
                ProdutoId = produtoId,
                PrecoAntigo = precoAntigo,
                NovoPreco = novoPreco,
                DataAlteracao = DateTime.UtcNow
            };

            await _logCollection.InsertOneAsync(log);
        }
    }
}
