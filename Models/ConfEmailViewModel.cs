using System;

namespace webapi.Models
{
    public class ConfEmailViewModel
    {
        //string smtp,int porta,string email,string senha,string destinatario,string titulo,string corpo
        public Smtp smtp { get; set; }
        public Revendedor revendedor { get; set; }
        public ModeloEmail ModeloEmail { get; set; }
        public Financeiro Financeiro { get; set; }
        public Cliente cliente { get; set; }
    }
}