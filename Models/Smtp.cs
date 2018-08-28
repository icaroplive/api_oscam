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
        public string endereco { get; set; }
        public int porta { get; set; }
        public string sslTls { get; set; }
        public string descricao { get; set; }
    }
}