using System.ComponentModel.DataAnnotations;

namespace FIAP_PersistenciaDados.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }
    }

}
