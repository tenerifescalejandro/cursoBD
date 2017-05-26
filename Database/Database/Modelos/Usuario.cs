using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Usuario
    {
        //añadiendo propiedades: escribir prop tab tab

        public int hiddenId { get; set; }
        public string Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string photoUrl { get; set; }
        public string searchPreferences { get; set; }
        public bool status { get; set; }
        public bool deleted { get; set; }
        public bool isAdmin { get; set; }


    }
}
