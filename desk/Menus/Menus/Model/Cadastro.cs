﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menus
{
    public class Cadastro
    {
        private string nome;
        private string sobrenome;
        private int idade;
        private string sexo;
        private string email;
        private int userId;
        private int notaId;
        private int modified;

        public string Nome { get => nome; set => nome = value; }
        public string Sobrenome { get => sobrenome; set => sobrenome = value; }
        public int Idade { get => idade; set => idade = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Email { get => email; set => email = value; }
        public int UserId { get => userId; set => userId = value; }
        public int NotaId { get => notaId; set => notaId = value; }
        public int Modified { get => modified; set => modified = value; }
    }
}
