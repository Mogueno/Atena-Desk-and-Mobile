using MobileTCC.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileTCC.Helpers
{
    class ServiceDBNotas
    {
        SQLiteConnection conn;
        public string Mensagem { get; set; }
        public List<TableNotas> data { get; set; }
        public ServiceDBNotas(string Caminho)
        {

            if (Caminho == "")
                Caminho = App.Caminho;

            conn = new SQLiteConnection(Caminho); // Define o banco
            conn.CreateTable<TableNotas>(); // Cria a tabela
            conn.Execute("PRAGMA foreign_keys = ON");
        }

        public void InserirNota(TableNotas notas)
        {
            // Validacao para saber se tem titulo e dados

            try
            {
                if (string.IsNullOrEmpty(notas.Titulo))
                    throw new Exception("Titulo da Nota não Informado");
                if (string.IsNullOrEmpty(notas.Dados))
                    throw new Exception("Dados da Nota não Informado");
                int result = conn.Insert(notas);
                if (result != 0)
                {
                    this.Mensagem =
                    string.Format("{0} registro(s) adicionado(s): [Nota: {1}]", result, notas.Titulo);
                }
                else
                {
                    string.Format("0 registro(s) adicionado(s): Informe o Titulo e os dados da nota!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void AlterarNota(TableNotas notas)
        {
            try
            {
                if (string.IsNullOrEmpty(notas.Titulo))
                    throw new Exception("Titulo da Nota não Informado");
                if (string.IsNullOrEmpty(notas.Dados))
                    throw new Exception("Dados da Nota não Informado");
                if (notas.Id <= 0)
                    throw new Exception("Id da Nota não Informado");
                int result = conn.Update(notas);
                Mensagem = string.Format(" {0} Registros Alterados.", result);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro:  {0}", ex.Message));
            }
        }

        public void ExcluirNota(int Id)
        {
            try
            {
                int result = conn.Table<TableNotas>().Delete
                    (registro => registro.Id == Id);
                Mensagem = string.Format(" {0} Registros Deletados.", result);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro:  {0}", ex.Message));
            }
        }

        public List<TableNotas> ListarNota()
        {
            List<TableNotas> lista = new List<TableNotas>();
            try
            {
                lista = conn.Table<TableNotas>().ToList();
                this.Mensagem = "Listagem das Notas";
                this.data = lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;
        }

        public List<TableNotas> LocalizarNota(string titulo)
        {
            List<TableNotas> lista = new List<TableNotas>();
            try
            {
                var resp = from p in conn.Table<TableNotas>()
                           where p.Titulo.ToLower().Contains(titulo.ToLower())
                           select p;

                lista = resp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro:  {0}", ex.Message));
            }
            return lista;
        }

    }
}
