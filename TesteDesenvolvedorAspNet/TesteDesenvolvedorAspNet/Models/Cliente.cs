using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDesenvolvedorAspNet.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        //public Cliente()
        //{
        //    this.Produtos = new HashSet<Produto>();
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 IdCliente { get; set; }
        [Required(ErrorMessage = "Nome do cliente deve ser inserido.")]
        public String NomeCliente { get; set; }
        [Required(ErrorMessage = "CPF do cliente deve ser inserido.")]
        public String CPF { get; set; }
        [Required(ErrorMessage = "Email do cliente deve ser inserido.")]
        public String Email { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}