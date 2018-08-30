using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Oscam
    {
        static string url = "http://ipr.net.br:8888/";
        private static readonly HttpClient _httpClient = new HttpClient();
        public async static Task<int> criarUsuarioAsync(string usuario, string senha, string nome,Servidor servidor,int disabled=0)
        {
            var credCache = new CredentialCache();
            credCache.Add(new Uri(url), "Digest", new NetworkCredential(servidor.userCam, servidor.senhaCam));
            var HttpHandler = new HttpClientHandler();
            HttpHandler.Credentials = credCache.GetCredential(new Uri(servidor.urlCam), "Digest");
            var httpClient = new HttpClient(HttpHandler);
            var answer = httpClient.GetAsync(new Uri(String.Format("{4}/user_edit.html?user={0}&pwd={1}&description={2}&disabled={3}&group=1&action=Save",usuario,senha,nome,disabled,servidor.urlCam))).Result;
            return (int)answer.StatusCode;
        }
        public async static Task<int> deleteAsync(string usuario,Servidor servidor)
        {
            var credCache = new CredentialCache();
            credCache.Add(new Uri(url), "Digest", new NetworkCredential("ew", "ew"));
            var HttpHandler = new HttpClientHandler();
            HttpHandler.Credentials = credCache.GetCredential(new Uri(servidor.urlCam), "Digest");
            var httpClient = new HttpClient(HttpHandler);
            var answer = httpClient.GetAsync(new Uri(String.Format("{0}/oscamapi.json?part=userstats&user={1}&action=delete",servidor.urlCam,usuario))).Result;
            
            
            return (int)answer.StatusCode;
        }
    }
}