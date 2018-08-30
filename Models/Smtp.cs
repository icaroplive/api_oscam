using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Smtp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }
        [MaxLength(100)]
        public string endereco { get; set; }
        public int porta { get; set; }
        [MaxLength(100)]
        public string sslTls { get; set; }
        [MaxLength(100)]
        public string descricao { get; set; }
    }
}