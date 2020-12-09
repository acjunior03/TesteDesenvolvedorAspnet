using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TesteDesenvolvedorAspNet.Models;

namespace TesteDesenvolvedorAspNet.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Produto> ProdutoItens { get; set; }
        public DbSet<Cliente> ClienteItens { get; set; }
    }
}