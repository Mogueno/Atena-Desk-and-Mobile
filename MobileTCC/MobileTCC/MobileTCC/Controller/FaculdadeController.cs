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

        //Busca todas as faculdades
        public async Task<IEnumerable<TB_FACULDADE>> GetAllFaculdades()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(baseAPI + "/faculdades");
            return JsonConvert.DeserializeObject<IEnumerable<TB_FACULDADE>>(result);
        }

        //Busca todos os cursos
        public async Task<IEnumerable<TB_CURSO>> GetAllCursos()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(baseAPI + "/cursos");
            return JsonConvert.DeserializeObject<IEnumerable<TB_CURSO>>(result);
        }

        //Busca todas as materias
        public async Task<IEnumerable<TB_MATERIA>> GetAllMaterias()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(baseAPI + "/materias");
            return JsonConvert.DeserializeObject<IEnumerable<TB_MATERIA>>(result);
        }

        //Adiciona um novo usuario
        public async Task<TB_FACULDADEReturn> FacData(int userID, int facID, int curID, int matID1, int matID2)
        {
            TB_FACULDADEReq user = new TB_FACULDADEReq
            {
                userID = userID,
                facID = facID,
                curID = curID,
                matID1 = matID1,
                matID2 = matID2
            };
            HttpClient client = GetClient();
            var response = await client.PostAsync(baseAPI + "/facdata",
                new StringContent(
                    JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<TB_FACULDADEReturn>( await response.Content.ReadAsStringAsync());
        }
    }
}
