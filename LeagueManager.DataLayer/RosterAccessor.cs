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
    public class RosterAccessor
    {
        private static string connectionString;

        public RosterAccessor()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MYSQLSERVER"].ToString();
        }

        public IEnumerable<Roster> GetRosters
        {
            get
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    var rosters = new LeagueManagerContext(mySqlConnection, false).Roster;

                    return from roster in rosters select roster;
                }
            }
        }

        public void InsertRoster(Roster roster)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                LeagueManagerContext leagueManagerContext = new LeagueManagerContext(mySqlConnection, false);
                leagueManagerContext.Roster.Add(roster);
                leagueManagerContext.SaveChanges();
            }
        }

        public void DeleteRoster(Guid id)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                LeagueManagerContext leagueManagerContext = new LeagueManagerContext(mySqlConnection, false);
                List<Roster> rosters = new List<Roster>();
                rosters = leagueManagerContext.Roster.Where(x => x.team_id_fk == id).ToList();
                if (rosters == null)
                    rosters = leagueManagerContext.Roster.Where(x => x.RosterId == id).ToList();

                var roster = (from r in rosters select r).FirstOrDefault();
                if (roster != null)
                {
                    leagueManagerContext.Roster.Remove(roster);
                    leagueManagerContext.SaveChanges();
                }
            }
        }
    }
}
