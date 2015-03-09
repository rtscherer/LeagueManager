using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueManager.Domain;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace LeagueManager.DataLayer
{
    public class TeamAccessor
    {
        private static string connectionString;

        public TeamAccessor()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MYSQLSERVER"].ToString();
        }

        public IEnumerable<Team> GetTeams
        {
            get
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    var teams = new LeagueManagerContext(mySqlConnection, false).Team;

                    return from team in teams select team;
                }
            }
        }

        public void InsertTeam(Team team)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                LeagueManagerContext leagueManagerContext = new LeagueManagerContext(mySqlConnection, false);
                leagueManagerContext.Team.Add(team);
                leagueManagerContext.SaveChanges();
            }
        }

        public void DeleteTeam(Guid teamId)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                LeagueManagerContext leagueManagerContext = new LeagueManagerContext(mySqlConnection, false);
                var teams = leagueManagerContext.Team.Where(x => x.TeamId == teamId);
                var team = (from t in teams select t).FirstOrDefault();
                if (team != null)
                {
                    leagueManagerContext.Team.Remove(team);
                    leagueManagerContext.SaveChanges();
                }
            }
        }
    }
}
