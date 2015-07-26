using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using LeagueManager.Domain;

namespace LeagueManager.Data
{
    public class ContactPersonAccessor
    {
        private static string connectionString;

        public ContactPersonAccessor()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MYSQLSERVER"].ToString();
        }

        public IEnumerable<ContactPerson> GetContacts
        {
            get
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    var contacts = new LeagueManagerContext(mySqlConnection, false).ContactPerson;

                    return from contact in contacts select contact;
                }
            }
        }
    }
}
