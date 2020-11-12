using System.ComponentModel.DataAnnotations.Schema;

namespace Leilao.Model
{
    [Table("Lances")]
    public class Lance
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int ProdutoId { get; set; }
        public float Valor { get; set; }
        public Pessoa Pessoa { get; set; }
        public Produto Produto { get; set; }
    }
}
