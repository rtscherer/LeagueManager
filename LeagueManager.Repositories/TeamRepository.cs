using LeagueManager.Domain;
using LeagueManager.Repositories.SQL;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace LeagueManager.Repositories
{
    public class TeamRepository
    {
        public string connectionString;

        public TeamRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["leaguemanager"].ConnectionString;
        }

        public Team GetTeamById(Guid id)
        {
            Team team = new Team();

            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.CommandTimeout = 30;
                        mySqlCommand.CommandType = System.Data.CommandType.Text;
                        mySqlCommand.CommandText = TeamSQL.GetTeam();

                        mySqlConnection.Open();
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                team.Id = mySqlDataReader.GetGuid("id");
                                team.Name = mySqlDataReader.GetString("name");
                                //team.League.Id = mySqlDataReader.GetGuid("league_id");
                                //team.Roster.Id = mySqlDataReader.GetGuid("roster_id");
                                //team.Schedule.Id = mySqlDataReader.GetGuid("schedule_id");
                                //team.Ranking.Id = mySqlDataReader.GetGuid("ranking_id");
                                //team.LastUpdate.UpdateUser = mySqlDataReader.GetString("update_user");
                                //team.LastUpdate.UpdateDate = mySqlDataReader.GetDateTime("update_date");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return team;
        }

        public Team InsertTeam(Team team)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.CommandTimeout = 30;
                        mySqlCommand.CommandType = System.Data.CommandType.Text;

                        mySqlCommand.CommandText = TeamSQL.InsertTeam();
                        mySqlCommand.Parameters.AddWithValue("Id", team.Id);
                        mySqlCommand.Parameters.AddWithValue("Name", team.Name);
                        mySqlCommand.Parameters.AddWithValue("LeagueId", team.League == null ? Guid.Empty : team.League.Id);
                        mySqlCommand.Parameters.AddWithValue("RosterId", team.Roster == null ? Guid.Empty : team.Roster.Id);
                        mySqlCommand.Parameters.AddWithValue("ScheduleId", team.Schedule == null ? Guid.Empty : team.Schedule.Id);
                        mySqlCommand.Parameters.AddWithValue("RankingId", team.Ranking == null ? Guid.Empty : team.Ranking.Id);
                        mySqlCommand.Parameters.AddWithValue("UpdateUser", team.LastUpdate.UpdateUser);
                        mySqlCommand.Parameters.AddWithValue("UpdateDate", team.LastUpdate.UpdateDate);

                        mySqlConnection.Open();
                        mySqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return team;
        }

        public void DeleteTeamById(Guid id)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.CommandTimeout = 30;
                        mySqlCommand.CommandType = System.Data.CommandType.Text;

                        mySqlCommand.CommandText = TeamSQL.DeleteTeam();
                        mySqlCommand.Parameters.AddWithValue("Id", id);

                        mySqlConnection.Open();
                        mySqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
