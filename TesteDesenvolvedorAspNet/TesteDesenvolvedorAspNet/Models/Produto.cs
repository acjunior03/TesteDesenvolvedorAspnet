﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDesenvolvedorAspNet.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 IdProduto { get; set; }
        [Required(ErrorMessage = "Nome do produto deve ser inserido.")]
        public String NomeProduto { get; set; }
        [ForeignKey("Cliente")]
        public Int64 IdCliente { get; set; }
        public virtual Cliente Clientes { get; set; }
    }
}