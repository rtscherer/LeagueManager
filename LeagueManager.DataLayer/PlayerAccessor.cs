using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using LeagueManager.Domain;

namespace LeagueManager.DataLayer
{
    public class PlayerAccessor
    {
        private static string connectionString;

        public PlayerAccessor()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MYSQLSERVER"].ToString();
        }

        public void InsertPlayer(Player player)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                LeagueManagerContext leagueManagerContext = new LeagueManagerContext(mySqlConnection, false);
                leagueManagerContext.Player.Add(player);
                leagueManagerContext.SaveChanges();
            }
        }
    }
}
