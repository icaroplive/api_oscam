using RestSharp;

namespace webapi.Controllers
{
    public class CieloController
    {
        RestRequest request = new RestRequest();
        RestClient client = new RestClient();
        public CieloController() {
            client = new RestClient("https://ws.pagseguro.uol.com.br/");
            request = new RestRequest("v2/checkout/?email=email&token=token", Method.POST);
            
            
        }
    }
}