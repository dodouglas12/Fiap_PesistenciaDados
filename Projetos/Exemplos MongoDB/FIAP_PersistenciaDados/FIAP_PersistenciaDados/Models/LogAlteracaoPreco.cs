namespace FIAP_PersistenciaDados.Models
{
    public class LogAlteracaoPreco
    {
        public int ProdutoId { get; set; }
        public decimal PrecoAntigo { get; set; }
        public decimal NovoPreco { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
