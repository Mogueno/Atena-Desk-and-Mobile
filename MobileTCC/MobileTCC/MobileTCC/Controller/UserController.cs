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
    public class UserController
    {
        const string baseAPI = "https://atenaapiv1.azurewebsites.net";
        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        
        //Busca todos os usuarios
        public async Task<IEnumerable<TB_USER>> GetAllUsers()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(baseAPI + "/usuarios");
            return JsonConvert.DeserializeObject<IEnumerable<TB_USER>>(result);
        }

        //Adiciona um novo usuario
        public static async Task<TB_USERReturn> AddNewUser(string name, int idade, string sexo, string email, string senha, int userF, int userG)
        {
            TB_USER user = new TB_USER
            {
                userName = name,
                userIdade = idade,
                userEmail = email,
                userSenha = senha,
                userSexo = sexo,
                userF = userF,
                userG = userG,
            };
            HttpClient client = GetClient();
            var response = await client.PostAsync(baseAPI + "/usuario",
                new StringContent(
                    JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<TB_USERReturn>(await response.Content.ReadAsStringAsync());
        }
        
        //Atualiza o registro do usuario
        public async Task<TB_USER> PatchUser(int userID, string name, int idade, string sexo, string email, string senha, int userF, int userG)
        {
            TB_USER user = new TB_USER
            {
                userName = name,
                userIdade = idade,
                userEmail = email,
                userSenha = senha,
                userSexo = sexo,
                userF = userF,
                userG = userG,
            };
            HttpClient client = GetClient();
            string json = JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PatchAsync(new Uri(baseAPI + "/usuario/" + userID) , httpContent);

            return JsonConvert.DeserializeObject<TB_USER>(await response.Content.ReadAsStringAsync());
        }

        //Deleta o registro do usuario
        public async Task<TB_USER> DeleteUser(int userID)
        { 
            HttpClient client = GetClient();
            var response = await client.DeleteAsync(new Uri(baseAPI + "/usuario/" + userID));
            return JsonConvert.DeserializeObject<TB_USER>(await response.Content.ReadAsStringAsync());
        }

        //Busca usuario existente
        public async Task<IList<TB_USERReturn>> GetExistentUser(string userEmail, string userSenha)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(baseAPI + "/login/" + userEmail + "-" + userSenha);
            return JsonConvert.DeserializeObject<IList<TB_USERReturn>>(result);
        }

    }
}
