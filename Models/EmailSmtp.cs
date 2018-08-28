using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class EmailSmtp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }
        public Guid idUser { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        [ForeignKey("Smtp")]
        public Guid idSmtp { get; set; }
        public virtual Smtp Smtp { get; set; }
    }
}