using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leilao.Model
{
    [Table("Produtos")]
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Valor { get; set; }
        public List<Lance> Lances { get; set; }
    }
}
