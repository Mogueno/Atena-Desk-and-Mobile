using MobileTCC.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileTCC.Controller
{
    public class NotaController
    {
        const string baseAPI = "https://atenaapiv1.azurewebsites.net";
        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        //Busca todas as Notas
        public async Task<RootObject> GetAllNotas(int userID)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(baseAPI + "/notas/" + userID);
            return JsonConvert.DeserializeObject<RootObject>(result);
        }
    }
}
