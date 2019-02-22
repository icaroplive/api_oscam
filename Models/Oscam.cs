using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace webapi.Models
{
    public class Oscam
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public async static Task<int> criarUsuarioAsync(string usuario, string senha, string nome,Servidor servidor,int disabled=0)
        {
            var credCache = new CredentialCache();
            credCache.Add(new Uri(servidor.servidorCam), "Digest", new NetworkCredential(servidor.userCam, servidor.senhaCam));
            var HttpHandler = new HttpClientHandler();
            HttpHandler.Credentials = credCache.GetCredential(new Uri(servidor.servidorCam), "Digest");
            var httpClient = new HttpClient(HttpHandler);
            var answer = httpClient.GetAsync(new Uri(String.Format("{4}/user_edit.html?user={0}&pwd={1}&description={2}&disabled={3}&group=1&action=Save",usuario,senha,nome,disabled == 1 ? 0 : 1,servidor.servidorCam))).Result;
            return (int)answer.StatusCode;
        }
        public async static Task<int> deleteAsync(string usuario,Servidor servidor)
        {
            var credCache = new CredentialCache();
            credCache.Add(new Uri(servidor.servidorCam), "Digest", new NetworkCredential(servidor.userCam, servidor.senhaCam));
            var HttpHandler = new HttpClientHandler();
            HttpHandler.Credentials = credCache.GetCredential(new Uri(servidor.servidorCam), "Digest");
            var httpClient = new HttpClient(HttpHandler);
            var answer = httpClient.GetAsync(new Uri(String.Format("{0}/oscamapi.json?part=userstats&user={1}&action=delete",servidor.servidorCam,usuario))).Result;
            
            
            return (int)answer.StatusCode;
        }
        public async static Task<StatusOscam> getCanais(Servidor servidor)
        {
            var credCache = new CredentialCache();
            credCache.Add(new Uri(servidor.servidorCam), "Digest", new NetworkCredential(servidor.userCam, servidor.senhaCam));
            var HttpHandler = new HttpClientHandler();
            HttpHandler.Credentials = credCache.GetCredential(new Uri(servidor.servidorCam), "Digest");
            var httpClient = new HttpClient(HttpHandler);
            var answer = httpClient.GetAsync(new Uri(String.Format("{0}/oscamapi.json?part=status",servidor.servidorCam))).Result;
            
            var ewew=answer.Content.ReadAsStringAsync().Result;
            var xpxp = string.Join(" ", Regex.Split(ewew, @"(?:\r\n|\n|\r|\t)"));



            StatusOscam serialize = JsonConvert.DeserializeObject<StatusOscam>(xpxp);
            
            return serialize;
        }
    }
}