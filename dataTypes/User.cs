using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataTypes
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public User(string _login, string _password)
        {
            id = 0;
            name = "";
            login = _login;
            password = _password;
        }
    }
}
