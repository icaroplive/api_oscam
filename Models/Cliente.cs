using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public DateTime dataCriado { get; set; }
        public decimal valorCobrado { get; set; }
        public Guid idUser { get; set; }
        public bool ativo { get; set; }
        public bool apagado { get; set; }
        public DateTime? dataApagado { get; set; }
        
    }
}