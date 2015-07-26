using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueManager.Domain;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace LeagueManager.Data
{
    public class TeamAccessor
    {
        private static string connectionString;

        public TeamAccessor()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MYSQLSERVER"].ToString();
        }

        public Team GetTeamById(Guid teamId)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                var teams = new LeagueManagerContext(mySqlConnection, false).Team;

                return (from team in teams
                        where team.TeamId == teamId
                        select team).FirstOrDefault();
            }
        }

        public IEnumerable<Team> GetAllTeams
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

        public void UpdateTeam(Team team)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                LeagueManagerContext leagueManagerContext = new LeagueManagerContext(mySqlConnection, false);
                var existingTeam = leagueManagerContext.Team.SingleOrDefault(t => t.TeamId == team.TeamId);
                if (existingTeam != null)
                {
                    existingTeam = team;
                    leagueManagerContext.SaveChanges();
                }
                else throw new ArgumentException(string.Format("Team does not exist to update. TeamId: {0}.", team.TeamId), team.TeamId.ToString());
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
