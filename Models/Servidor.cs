using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Servidor
    {
        [Key]
        public int id { get; set; }
        public string urlCam { get; set; }
    }
}