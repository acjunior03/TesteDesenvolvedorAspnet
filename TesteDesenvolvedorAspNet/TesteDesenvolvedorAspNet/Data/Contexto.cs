using System;
using System.Data.Entity;
using TesteDesenvolvedorAspNet.Models;

namespace TesteDesenvolvedorAspNet.Data
{
    public class Contexto : DbContext
    {
        public Contexto() : base("name=DesenvolvedorAspNet")
        { }
        public DbSet<Produto> ProdutoItens { get; set; }
        public DbSet<Cliente> ClienteItens { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasKey(c => new { c.IdProduto });
            modelBuilder.Entity<Cliente>().HasKey(c => new { c.IdCliente });
            //modelBuilder.Entity<Cliente>().ToTable("Cliente").HasKey(r => r.IdCliente);
            //modelBuilder.Entity<Produto>().ToTable("Produto").HasKey(r => r.IdProduto);


            //modelBuilder.Entity<Cliente>().HasMany<Produto>(g => g.Produtos);

            //modelBuilder.Entity<Produto>().HasRequired<Cliente>(s => s.Cliente).WithMany(g => g.Produtos).HasForeignKey<Int64>(s => (Int64)s.IdCliente);
            //modelBuilder.Entity<Cliente>().HasMany<Produto>(g => g.Produtos).WithRequired(s => s.Cliente).HasForeignKey<Int64>(s => (Int64)s.IdCliente).WillCascadeOnDelete(value: false);
            //base.OnModelCreating(modelBuilder);
        }
        //modelBuilder.Entity<Produto>().HasRequired(p => p.Cliente).WithMany().HasForeignKey(u=> u.IdCliente);
        //modelBuilder.Entity<Produto>().HasRequired(p => p.Cliente).WithOptional();
        //modelBuilder.Entity<Produto>().HasKey(c => new { c.IdProduto });
        //modelBuilder.Entity<Cliente>().HasKey(c => new { c.IdCliente });
    }
}
