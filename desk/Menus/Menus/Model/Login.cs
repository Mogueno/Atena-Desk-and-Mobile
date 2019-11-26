using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menus
{
    public static class Login
    {
        private static string usuario;
        private static string senha;
        private static string facul;
        private static string curso;
        private static string materia;


        public static string Usuario { get => usuario; set => usuario = value; }
        public static string Senha { get => senha; set => senha = value; }
        public static string Facul { get => facul; set => facul = value; }
        public static string Curso { get => curso; set => curso = value; }
        public static string Materia { get => materia; set => materia = value; }
    }
}
