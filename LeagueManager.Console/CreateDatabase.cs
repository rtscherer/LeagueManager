using LeagueManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using LeagueManager.Data;

namespace LeagueManager.DatabaseConsole
{
    class CreateDatabase
    {
        #region Private Members
        private static string connectionString = ConfigurationManager.ConnectionStrings["MYSQLSERVER"].ToString();

        enum DatabaseRefreshType { SchemaOnly, StagingData, MigrateData }
        #endregion

        public static void Main(string[] args)
        {
            Console.WriteLine("League Manager Database Schema Utility");
            Console.WriteLine();

            Console.WriteLine("Enter a Number Below to Select Refresh Type");
            Console.WriteLine(" 1.) Schema Only");
            Console.WriteLine(" 2.) Refresh Staging Data");
            Console.WriteLine(" 3.) Migrate Existing Data");

            Console.WriteLine();

            int selectedRefreshType = 0;
            int.TryParse(Console.ReadLine(), out selectedRefreshType);

            ProcessAndExecuteUserSelection(selectedRefreshType);
        }

        #region Private Methods
        /// <summary>
        /// Process User Selection for Database Schema Refresh Type
        /// </summary>
        /// <param name="selectedRefreshType">integer Database Schema Refresh Type</param>
        private static void ProcessAndExecuteUserSelection(int selectedRefreshType)
        {
            switch (selectedRefreshType)
            {
                case 1:
                    Console.WriteLine("Rebuilding Database Schema. Selected Refresh Type: {0}", DatabaseRefreshType.SchemaOnly);
                    DatabaseSchemaRebuild(DatabaseRefreshType.SchemaOnly);
                    Console.WriteLine("Schema Refresh Complete. Refresh Type: {0}.", DatabaseRefreshType.SchemaOnly);
                    Console.WriteLine();
                    Console.WriteLine("Press Any Key to Exit.");
                    Console.WriteLine();
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Rebuilding Database Schema. Selected Refresh Type: {0}", DatabaseRefreshType.StagingData);
                    DatabaseSchemaRebuild(DatabaseRefreshType.StagingData);
                    Console.WriteLine("Schema Refresh Complete. Refresh Type: {0}.", DatabaseRefreshType.StagingData);
                    Console.WriteLine();
                    Console.WriteLine("Press Any Key to Exit.");
                    Console.WriteLine();
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Rebuilding Database Schema. Selected Refresh Type: {0}", DatabaseRefreshType.MigrateData);
                    DatabaseSchemaRebuild(DatabaseRefreshType.MigrateData);
                    Console.WriteLine("Schema Refresh Complete. Refresh Type: {0}.", DatabaseRefreshType.MigrateData);
                    Console.WriteLine();
                    Console.WriteLine("Press Any Key to Exit.");
                    Console.WriteLine();
                    Console.ReadLine();
                    break;
                default:
                    throw new InvalidOperationException("No Valid Selection was Provided. Please Provide a Valid Selection.");
            }
        }

        /// <summary>
        /// Drop and Recreate Database Schema
        /// </summary>
        /// <param name="mySqlConnection">MySQL Connection Object</param>
        private static void DropAndCreateDatabase(MySqlConnection mySqlConnection)
        {
            using (LeagueManagerContext contextDB = new LeagueManagerContext(mySqlConnection, false))
            {
                contextDB.Database.Delete();
                contextDB.Database.Create(); //CreateIfNotExists();
            }
        }

        /// <summary>
        /// Database Schema Rebuild
        /// </summary>
        /// <param name="databaseRefreshType">Enum Database Refresh Type</param>
        private static void DatabaseSchemaRebuild(DatabaseRefreshType databaseRefreshType)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                // Drop and Re-Create Database
                DropAndCreateDatabase(mySqlConnection);

                if (databaseRefreshType == DatabaseRefreshType.SchemaOnly) return;

                if (databaseRefreshType == DatabaseRefreshType.MigrateData)
                    throw new NotImplementedException("Migrate Data is Not Yet Supported.");

                // Open Connection
                mySqlConnection.Open();

                // Begin the Transaction with MySql Database
                MySqlTransaction transaction = mySqlConnection.BeginTransaction();

                try
                {
                    // DbConnection that is Already Opened
                    using (LeagueManagerContext context = new LeagueManagerContext(mySqlConnection, false))
                    {
                        // Interception/SQL Logging
                        context.Database.Log = (string message) => { Console.WriteLine(message); };

                        // Pass an Existing Transaction to the Context
                        context.Database.UseTransaction(transaction);

                        // Initialize Database with Data
                        //  [1.] Initialize Team Table with Data
                        List<Team> teams = new Team().InitializeDatabaseTeams();
                        context.Team.AddRange(teams);

                        //  [3.] Initialize Roster Table with Data
                        List<Roster> rosters = new List<Roster>();
                        teams.ForEach(team =>
                        {
                            rosters.Add(new Roster().InitializeDatabaseRoster(team.TeamId));
                        });

                        //  [2.] Initialize Player Table with Data
                        List<Player> players = new Player().InitializeDatabasePlayers(rosters[0].RosterId);
                        rosters[0].Team = teams[0];
                        rosters[0].Players = players;
                        context.Roster.AddRange(rosters);
                        context.Player.AddRange(players);

                        // [4.] Initialize Contact Person Table with Data
                        List<ContactPerson> contacts = new ContactPerson().InitializeDatabaseContactPerson();
                        ContactPerson contactPerson1 = contacts[0];
                        ContactPerson contactPerson2 = contacts[1];
                        context.ContactPerson.Add(contactPerson1);
                        context.ContactPerson.Add(contactPerson2);

                        // [5.] Initialize Location Table with Data
                        Location location = new Location().InitializeDatabaseLocation();
                        context.Location.Add(location);

                        // [6.] Initialize Facility Table Data
                        Facility facility = new Facility().InitializeDatabaseFacility();
                        facility.contact_id_fk1 = contactPerson1.ContactPersonId;
                        facility.contact_id_fk2 = contactPerson2.ContactPersonId;
                        facility.location_id_fk = location.LocationId;
                        context.Facility.Add(facility);

                        // [7.] Initialize League Table Data
                        League league = new League().InitializeDatabaseLeague();
                        league.contactperson_id_fk1 = contactPerson1.ContactPersonId;
                        league.contactperson_id_fk2 = contactPerson2.ContactPersonId;
                        league.facility_id_fk = facility.FacilityId;
                        context.League.Add(league);

                        // Save Changes
                        context.SaveChanges();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        #endregion
    }
}