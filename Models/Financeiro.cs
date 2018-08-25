using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Financeiro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Cliente")]
        public Guid idCliente { get; set; }
        public Guid idUser { get; set; }
        public decimal valorCobrado { get; set; }
        public decimal valorLogin { get; set; }
        public DateTime? dataVencimento { get; set; }
        public DateTime? dataBaixaCliente { get; set; }
        public DateTime? dataBaixaRevendedor { get; set; }
        public DateTime dataLancamento { get; set; }
        public int origemPagamentoCliente { get; set; }
        public int origemPagamentoRevendedor { get; set; }
        public bool apagado { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}