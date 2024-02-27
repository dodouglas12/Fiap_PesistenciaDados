using Dapper.Contrib.Extensions;

namespace FIAP_PersistenciaDadosBff.Models
{
    [Table("produto")]
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }
    }
}
