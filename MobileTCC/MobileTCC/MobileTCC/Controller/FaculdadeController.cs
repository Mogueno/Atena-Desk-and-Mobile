using MobileTCC.Helpers;
using MobileTCC.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace MobileTCC.Controller
{
    public class FaculdadeController
    {
        const string baseAPI = "https://atenaapiv1.azurewebsites.net";
        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<TB_FACULDADE>> GetAllFaculdades()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(baseAPI + "/faculdades");
            return JsonConvert.DeserializeObject<IEnumerable<TB_FACULDADE>>(result);
        }
    }
}
