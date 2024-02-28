using MongoDB.Bson;

namespace FIAP_PersistenciaDadosBff.Models
{
    public class LogAlteracaoPreco
    {
        public ObjectId Id { get; set; }
        public int ProdutoId { get; set; }
        public decimal PrecoAntigo { get; set; }
        public decimal NovoPreco { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
