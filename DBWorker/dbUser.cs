using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWorker
{
    public class dbUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public dbUser GetUserByLoginFromDB(string _login) 
        {
            using (mydbaseEntities mydbe = new mydbaseEntities())
            {
                try
                {
                    Users usr = mydbe.Users.Where(b => b.login == _login).First();
                    id = usr.Id;
                    name = usr.name;
                    login = usr.login;
                    password = usr.password;
                }
                catch
                {
                    
                }
            }

            return this;
        }
    }
}
