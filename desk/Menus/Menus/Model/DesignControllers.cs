using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Menus.Model
{
    public class DesignControllers
    {

        public void GravarUser(string Nome, string Idade,  string Sexo, string Email, string Senha, string Facebook, string Google)
        {
            //using (SqlConnection objConexao = new SqlConnection(strConexao))
            //{
            //    using (SqlCommand objCommand = new SqlCommand(strInsertUser, objConexao))
            //    {
            //        objCommand.Parameters.AddWithValue("@USER_STR_NOME", Nome);
            //        objCommand.Parameters.AddWithValue("@USER_INT_IDADE", Idade);
            //        objCommand.Parameters.AddWithValue("@USER_STR_SEXO", Sexo);
            //        objCommand.Parameters.AddWithValue("@USER_STR_EMAIL", Email);
            //        objCommand.Parameters.AddWithValue("@USER_STR_SENHA", Senha);
            //        objCommand.Parameters.AddWithValue("@USER_STR_FACEBOOKLOGIN", Facebook);
            //        objCommand.Parameters.AddWithValue("@USER_STR_GOOGLELOGIN", Google);


            //        objConexao.Open();

            //        objCommand.ExecuteNonQuery();



            //        objConexao.Close();
            //    }
            //}
        }
    }
}
