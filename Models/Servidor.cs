using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Servidor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }
        public string urlCam { get; set; }
        public string servidorCam { get; set; }
        public string userCam { get; set; }
        public string senhaCam { get; set; }
    }
}