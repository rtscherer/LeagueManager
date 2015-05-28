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

        public List<Player> Save(List<Player> players)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                LeagueManagerContext leagueManagerContext = new LeagueManagerContext(mySqlConnection, false);
                leagueManagerContext.Player.AddRange(players);
                leagueManagerContext.SaveChanges();
            }

            return players;
        }

        public IEnumerable<Player> GetPlayers(Guid rosterId)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                var players = new LeagueManagerContext(mySqlConnection, false).Player;

                return from player in players
                       where player.roster_id_fk == rosterId
                       select player;
            }
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

        public void DeletePlayer(Player player)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                LeagueManagerContext leagueManagerContext = new LeagueManagerContext(mySqlConnection, false);
                leagueManagerContext.Player.Remove(player);
                leagueManagerContext.SaveChanges();
            }
        }
    }
}
