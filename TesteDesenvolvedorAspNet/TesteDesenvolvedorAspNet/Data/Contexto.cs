using System.Data.Entity;
using TesteDesenvolvedorAspNet.Models;

namespace TesteDesenvolvedorAspNet.Data
{
    public class Contexto : DbContext
    {
        public Contexto() : base("name=DesenvolvedorAspNet")
        { }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasKey(c => new { c.IdProduto });
            modelBuilder.Entity<Cliente>().HasKey(c => new { c.IdCliente });
            modelBuilder.Entity<Produto>().HasRequired(t => t.Cliente).WithMany(t => t.Produtos).HasForeignKey(d => d.IdCliente);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Produto> ProdutoItens { get; set; }
        public DbSet<Cliente> ClienteItens { get; set; }
    }
}
