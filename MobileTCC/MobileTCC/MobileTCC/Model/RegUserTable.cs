using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTCC.Model
{
    public class RegUserTable
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Sexo{ get; set; }
        public string gImage { get; set; }


    }
}
