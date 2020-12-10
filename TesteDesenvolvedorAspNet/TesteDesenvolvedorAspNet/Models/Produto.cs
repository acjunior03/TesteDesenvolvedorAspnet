using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDesenvolvedorAspNet.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 IdProduto { get; set; }
        [Required(ErrorMessage = "Nome do produto deve ser inserido.")]
        public String NomeProduto { get; set; }
        public Boolean Ativo { get; set; }
        [ForeignKey("Cliente")]
        public Int64? IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}