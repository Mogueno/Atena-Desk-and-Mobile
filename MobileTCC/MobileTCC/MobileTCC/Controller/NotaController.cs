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

        //Busca os dados de uma nota
        public async Task<SingleNotaData> GetSingleNota(int notaID, int userID)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(baseAPI + "/singlenota/" + userID + "-" + notaID);
            return JsonConvert.DeserializeObject<SingleNotaData>(result);
        }

        //Atualiza os dados da nota
        public async Task<TB_NOTA_DATAPATCHReturn> PatchNota(int userID, int notaID, string titulo, string conteudo)
        {
            TB_NOTA_DATA nota = new TB_NOTA_DATA
            {
                userID = userID,
                notaID = notaID,
                titulo = titulo,
                conteudo = conteudo
            };
            HttpClient client = GetClient();
            string json = JsonConvert.SerializeObject(nota, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PatchAsync(new Uri(baseAPI + "/notapatch/" + userID + "-" + notaID), httpContent);

            return JsonConvert.DeserializeObject<TB_NOTA_DATAPATCHReturn>(await response.Content.ReadAsStringAsync());
        }


        //Adiciona uma nova nota
        public async Task<TB_NOTA_DATAReturn> AddNewNota(int userID, int facID, int curID, int matID, string conteudo, string titulo)
        {
            TB_NOTA_DATA_NEW user = new TB_NOTA_DATA_NEW
            {
                userID = userID,
                facID = facID,
                curID = curID,
                matID = matID,
                titulo = titulo,
                conteudo = conteudo
            };
            HttpClient client = GetClient();
            var response = await client.PostAsync(baseAPI + "/notadata",
                new StringContent(
                    JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<TB_NOTA_DATAReturn>(await response.Content.ReadAsStringAsync());
        }
    }
}
