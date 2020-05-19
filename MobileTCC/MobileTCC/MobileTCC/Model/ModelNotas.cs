using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MobileTCC.Model
{
    [Table("TB_NOTAS")]
    public class TableNotas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public String Titulo { get; set; }
        [NotNull]
        public String Dados { get; set; }

        public TableNotas()
        {
            this.Id = 0;
            this.Dados = "";
            this.Titulo = "";
        }
    }

    [Table("TB_USUARIO")]
    public class TableUsuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
        public String Email { get; set; }
        public String Sexo { get; set; }
        public String Faculdade { get; set; }
        public String Materia { get; set; }
        public String Curso { get; set; }
        public String GImage { get; set; }
        public Boolean GLogin { get; set; }


        public TableUsuario()
        {
            this.Id = 0;
            this.Login = " ";
            this.Senha = " ";
            this.Email = " ";
            this.Sexo = " ";
            this.Faculdade = " ";
            this.Materia = " ";
            this.Curso = " ";
            this.GLogin = false;
            this.GImage = " ";
        }
    }
    
    //Google Login data model
    [JsonObject]
    public class User
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("verified_email")]
            public bool VerifiedEmail { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("given_name")]
            public string GivenName { get; set; }

            [JsonProperty("family_name")]
            public string FamilyName { get; set; }

            [JsonProperty("link")]
            public string Link { get; set; }

            [JsonProperty("picture")]
            public string Picture { get; set; }

            [JsonProperty("gender")]
            public string Gender { get; set; }
        }

    [JsonObject]
    public class TB_USER
    {
        public int userID { get; set; }
        [DefaultValue("")]
        public String userName { get; set; }
        public int userIdade { get; set; }
        [DefaultValue("")]
        public String userSexo { get; set; }
        [DefaultValue("")]
        public String userEmail { get; set; }
        [DefaultValue("")]
        public String userSenha { get; set; }
        [DefaultValue("")]
        public int userF { get; set; }
        [DefaultValue("")]
        public int userG { get; set; }

        public TB_USER()
        {
            this.userID = 0;
            this.userName ="";
            this.userIdade = 0;
            this.userSexo = "";
            this.userEmail = "";
            this.userSenha = "";
            this.userF = 0;
            this.userG = 0;
        }

    }
    public class TB_USERReturn
    {
        public int USER_INT_ID { get; set; }


        public TB_USERReturn()
        {
            USER_INT_ID = 0;
        }
    }

    public class TB_FACULDADE
    {
        public int FAC_INT_ID;
        public string FAC_STR_NOME;
    }


    //Todas as tables no mesmo arquivo -- o banco de dados inteiro em um model so
}
