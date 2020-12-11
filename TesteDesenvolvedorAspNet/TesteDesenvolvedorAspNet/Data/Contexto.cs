using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TesteDesenvolvedorAspNet.Models;

namespace TesteDesenvolvedorAspNet.Data
{
    public class Contexto : DbContext
    {
        public Contexto() : base("name=DesenvolvedorAspNet")
        { }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Produto>().HasKey(c => new { c.IdProduto });
            modelBuilder.Entity<Cliente>().HasKey(c => new { c.IdCliente });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Produto> ProdutoItens { get; set; }
        public DbSet<Cliente> ClienteItens { get; set; }
    }
}
