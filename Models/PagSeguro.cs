using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace webapi.Models
{
    public class PagSeguro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid financeiroId { get; set; }
        public string code_reference { get; set; }
        public string transaction_id { get; set; }
        public string email { get; set; }
        public string token { get; set; }
    }
}