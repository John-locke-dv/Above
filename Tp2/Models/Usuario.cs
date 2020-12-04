using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tp2.Models
{
    public class Usuario
    {
        public string usuario { get; set; }
        public string password { get; set; }

        public int id { get; set; }
      

        public Usuario(int id, string usuario, string password)
        {
            this.id = id;
            this.usuario = usuario;
            this.password = password;
        }
       
    }
}
