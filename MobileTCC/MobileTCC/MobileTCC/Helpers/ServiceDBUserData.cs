using MobileTCC.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MobileTCC.Helpers
{
    class ServiceDBUserData
    {
        SQLiteConnection conn;
        public string Mensagem { get; set; }
        public ServiceDBUserData(string Caminho)
        {
            if (Caminho == "")
                Caminho = App.Caminho;

            conn = new SQLiteConnection(Caminho); // Define o banco
            conn.CreateTable<TableUsuario>(); // Cria a tabela
            conn.Execute("PRAGMA foreign_keys = ON");

        }

        public List<TableUsuario> ListarUsuario()
        {
            List<TableUsuario> lista = new List<TableUsuario>();
            try
            {
                lista = conn.Table<TableUsuario>().ToList();
                this.Mensagem = "Listagem das Notas" + lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lista;
        }

    }
}
