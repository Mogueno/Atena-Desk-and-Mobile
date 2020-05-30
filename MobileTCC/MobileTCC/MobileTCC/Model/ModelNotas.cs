using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MobileTCC.Model
{
    public class SingleNotaData
    {
        public string titulo { get; set; }
        public string conteudo { get; set; }
        public int matID { get; set; }
    }

    [JsonObject]
    public class RootObject 
    {
        public IList<TB_NOTASUSER2> reqSendData { get; set; }
    }

    [JsonObject]
    public class TB_NOTASUSER2
    {
        [DefaultValue("")]
        public string titulo { get; set; }
        [DefaultValue("")]
        public string conteudo { get; set; }
        [DefaultValue("")]
        public int notaID { get; set; }
        [DefaultValue("")]
        public int matID { get; set; }

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
    public class TB_USER_DATA2
    {
        [DefaultValue("")]
        public string USER_STR_NOME { get; set; }
        [DefaultValue(0)]
        public int USER_INT_IDADE { get; set; }
        [DefaultValue("")]
        public string USER_STR_SEXO { get; set; }
        [DefaultValue("")]
        public string USER_STR_EMAIL { get; set; }
        [DefaultValue("")]
        public string USER_STR_SENHA { get; set; }
        [DefaultValue("")]
        public int FAC_INT_ID { get; set; }
        [DefaultValue("")]
        public int CUR_INT_ID { get; set; }
        [DefaultValue("")]
        public int MAT_INT_ID { get; set; }

    }

    [JsonObject]
    public class TB_USER_DATA
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

        public TB_USER_DATA()
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

    [JsonObject]
    public class TB_NOTA_DATAReturn
    {
        public bool inserted { get; set; }
    }

    [JsonObject]
    public class TB_NOTA_DATAPATCHReturn
    {
        public bool patched { get; set; }
    }

    [JsonObject]
    public class TB_NOTA_DATA_NEW
    {
        public int userID { get; set; }
        public int facID { get; set; }
        public int matID { get; set; }
        public int curID { get; set; }
        [DefaultValue("")]
        public string titulo { get; set; }
        [DefaultValue("")]
        public string conteudo { get; set; }
    }

    [JsonObject]
    public class TB_NOTA_DATA
    {
        public int userID { get; set; }
        public int notaID{ get; set; }
        [DefaultValue("")]
        public String titulo { get; set; }
        [DefaultValue("")]
        public String conteudo { get; set; }

        public TB_NOTA_DATA()
        {
            this.userID = 0;
            this.notaID = 0;
            this.titulo = "";
            this.conteudo = "";
        }

    }
    public class TB_USERReturn
    {

        public int USER_INT_ID { get; set; }
        public bool newUser { get; set; }


        public TB_USERReturn()
        {
            USER_INT_ID = 0;
            newUser = false;
        }
    }

    public class TB_FACULDADEReq
    {
        public int userID { get; set; }
        public int facID { get; set; }
        public int curID { get; set; }
        public int matID1 { get; set; }
        public int matID2 { get; set; }
    }

    [JsonObject]
    public class TB_FACULDADEReturn
    {
        public bool insertCompleted { get; set; }
        public string err { get; set; }
    }

    [JsonObject]
    public class TB_NOTA_DELETEReturn
    {
        public bool deleted { get; set; }
    }



    public class TB_FACULDADE
    {
        public int FAC_INT_ID;
        public string FAC_STR_NOME;
    }
    public class TB_CURSO
    {
        public int CUR_INT_ID;
        public string CUR_STR_NOME;
    }
    public class TB_MATERIA
    {
        public int MAT_INT_ID;
        public string MAT_STR_NOME;
    }


    //Todas as tables no mesmo arquivo -- o banco de dados inteiro em um model so
}
