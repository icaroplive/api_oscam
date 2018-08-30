using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class ModeloEmail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }
        [MaxLength(50)]
        public string titulo { get; set; }
        public string corpo { get; set; }
        [MaxLength(20)]
        public string tipo { get; set; }
    }
}