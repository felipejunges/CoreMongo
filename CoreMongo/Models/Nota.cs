using System;
using System.ComponentModel.DataAnnotations;

namespace CoreMongo.Models
{
    public class Nota
    {
        public Guid Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Conteudo { get; set; }
        [Required]
        public int Acessos { get; set; }
    }
}