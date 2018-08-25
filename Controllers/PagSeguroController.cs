using RestSharp;

namespace webapi.Controllers
{
    public class CieloController
    {
        RestRequest request = new RestRequest();
        RestClient client = new RestClient();
        public CieloController() {
            client = new RestClient("https://ws.pagseguro.uol.com.br/");
            request = new RestRequest("v2/checkout/?email=icaropinheiro@live.com&token=A9D849A6ABA64541B7EF2C665B57E0A5", Method.POST);
            
            
        }
    }
}