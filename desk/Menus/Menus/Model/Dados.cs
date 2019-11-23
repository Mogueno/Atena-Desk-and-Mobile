using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Menus.Model
{
    public class Dados
    {
        public string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public const string strUpdateUser = "UPDATE TB_USER SET = USER_STR_NOME = @USER_STR_NOME, USER_INT_IDADE = @USER_INT_IDADE, USER_STR_SEXO = @USER_STR_SEXO, USER_STR_EMAIL = @USER_STR_EMAIL, USER_STR_SENHA = @USER_STR_SENHA, USER_STR_FACEBOOKLOGIN = @USER_STR_FACEBOOKLOGIN, USER_STR_GOOGLELOGIN = @USER_STR_GOOGLELOGIN WHERE USER_INT_ID = @USER_INT_ID";
        public const string strInsertUser = "INSERT INTO TB_USER VALUES (@USER_STR_NOME, @USER_INT_IDADE, @USER_STR_SEXO, @USER_STR_EMAIL, @USER_STR_SENHA, @USER_STR_FACEBOOKLOGIN, @USER_STR_GOOGLELOGIN)";

        public const string strUpdateCurso = "UPDATE TB_CURSO SET = CUR_STR_NOME = @CUR_STR_NOME WHERE USER_INT_ID = @USER_INT_ID";
        public const string strInsertCurso = "INSERT INTO TB_CURSO VALUES (@CUR_STR_NOME)";

        public const string strUpdateFacul = "UPDATE TB_FACULDADE SET = FAC_STR_NOME = @FAC_STR_NOME WHERE FAC_USER_INT_ID_FK = @FAC_USER_INT_ID_FK";
        public const string strInsertFacul = "INSERT INTO TB_FACULDADE VALUES (@FAC_STR_NOME)";

        public const string strInsertNota = "INSERT INTO TB_NOTA_STR VALUES (@STR_STR_PATH)";

        public void GravarUser(string Nome, string Idade,  string Sexo, string Email, string Senha, string Facebook, string Google)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strInsertUser, objConexao))
                {
                    objCommand.Parameters.AddWithValue("@USER_STR_NOME", Nome);
                    objCommand.Parameters.AddWithValue("@USER_INT_IDADE", Idade);
                    objCommand.Parameters.AddWithValue("@USER_STR_SEXO", Sexo);
                    objCommand.Parameters.AddWithValue("@USER_STR_EMAIL", Email);
                    objCommand.Parameters.AddWithValue("@USER_STR_SENHA", Senha);
                    objCommand.Parameters.AddWithValue("@USER_STR_FACEBOOKLOGIN", Facebook);
                    objCommand.Parameters.AddWithValue("@USER_STR_GOOGLELOGIN", Google);


                    objConexao.Open();

                    objCommand.ExecuteNonQuery();

                    objConexao.Close();
                }
            }
        }

        public void AtualizarUser(string IdUser, string Nome, string Idade, string Sexo, string Email, string Senha, string Facebook, string Google)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strUpdateUser, objConexao))
                {
                    objCommand.Parameters.AddWithValue("@USER_INT_ID", IdUser);
                    objCommand.Parameters.AddWithValue("@USER_STR_NOME", Nome);
                    objCommand.Parameters.AddWithValue("@USER_INT_IDADE", Idade);
                    objCommand.Parameters.AddWithValue("@USER_STR_SEXO", Sexo);
                    objCommand.Parameters.AddWithValue("@USER_STR_EMAIL", Email);
                    objCommand.Parameters.AddWithValue("@USER_STR_SENHA", Senha);
                    objCommand.Parameters.AddWithValue("@USER_STR_FACEBOOKLOGIN", Facebook);
                    objCommand.Parameters.AddWithValue("@USER_STR_GOOGLELOGIN", Google);


                    objConexao.Open();

                    objCommand.ExecuteNonQuery();

                    objConexao.Close();
                }
            }
        }

        public void GravarCurso(string NomeCurso)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strInsertCurso, objConexao))
                {
                    objCommand.Parameters.AddWithValue("@CUR_STR_NOME", NomeCurso);

                    objConexao.Open();

                    objCommand.ExecuteNonQuery();

                    objConexao.Close();
                }
            }
        }

        public void AtualizarCurso(string IdCurso, string NomeCurso)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strUpdateCurso, objConexao))
                {
                    objCommand.Parameters.AddWithValue("@CUR_INT_ID", IdCurso);
                    objCommand.Parameters.AddWithValue("@CUR_STR_NOME", NomeCurso);

                    objConexao.Open();

                    objCommand.ExecuteNonQuery();

                    objConexao.Close();
                }
            }
        }

        public void GravarFacul(string NomeFacul)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strInsertFacul, objConexao))
                {
                    objCommand.Parameters.AddWithValue("@FAC_STR_NOME", NomeFacul);

                    objConexao.Open();

                    objCommand.ExecuteNonQuery();

                    objConexao.Close();
                }
            }
        }


        public void AtualizarFacul(string IdFacul, string NomeFacul)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strUpdateFacul, objConexao))
                {
                    objCommand.Parameters.AddWithValue("@FAC_INT_ID", IdFacul);
                    objCommand.Parameters.AddWithValue("@FAC_STR_NOME", NomeFacul);

                    objConexao.Open();

                    objCommand.ExecuteNonQuery();

                    objConexao.Close();
                }
            }
        }

        public void GravarNota(string NotaContent)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strInsertNota, objConexao))
                {
                    objCommand.Parameters.AddWithValue("@STR_STR_PATH", NotaContent);

                    objConexao.Open();

                    objCommand.ExecuteNonQuery();

                    objConexao.Close();
                }
            }
        }


    }
}
