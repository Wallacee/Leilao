using Leilao.Model;
using System.Data.Entity;

namespace Leilao.DataAccess
{
    public class LeilaoContexto : DbContext
    {
        public LeilaoContexto() : base("LeilaoDB") { }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Lance> Lances { get; set; }
    }
}
