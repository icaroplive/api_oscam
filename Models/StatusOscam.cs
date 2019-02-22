using System.Collections.Generic;

namespace webapi.Models
{
    public class StatusOscam
    {
        public ClienteOscam oscam { get; set; }
    }
    public class ClienteOscam {
        public string version { get; set; }
        public status status { get; set; }
    }
    public class status {
        public List<DadosCliente> client { get; set; }
    }
    public class DadosCliente {
        public string name_enc { get; set; }
        public string rname_enc { get; set; }
        public string protocol { get; set; }
        public request request { get; set; }
    }
    public class request {
        public string chname { get; set; }
    }

}