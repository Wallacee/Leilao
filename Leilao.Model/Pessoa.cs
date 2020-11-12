using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leilao.Model
{
    [Table("Pessoas")]
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<Lance> Lances { get; set; }
    }
}
