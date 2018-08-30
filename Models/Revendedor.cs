using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Revendedor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid idUser { get; set; }
        public decimal valorLogin { get; set; }
        public string emailPagseguro { get; set; }
        public string tokenPagseguro { get; set; }
        public string tokenWidePay { get; set; }
        public int diaVencimento { get; set; }
        public string emailSmtp { get; set; }
        [MaxLength(100)]
        public string senha { get; set; }
        public Guid idSmtp { get; set; }
    }
}