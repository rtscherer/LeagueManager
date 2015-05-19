using LeagueManager.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.DataLayer
{
    public class LeagueManagerInitializer : DropCreateDatabaseAlways<LeagueManagerContext>
    {
        protected override void Seed(LeagueManagerContext context)
        {
            // Interception/SQL Logging
            //context.Database.Log = (string message) => { Console.WriteLine(message); };

            // Pass an Existing Transaction to the Context
            //context.Database.UseTransaction(transaction);

            // Initialize Database with Data
            //  [1.] Initialize Team Table with Data
            List<Team> teams = new Team().InitializeDatabaseTeams();
            context.Team.AddRange(teams);

            //  [2.] Initialize Player Table with Data
            List<Player> players = new Player().InitializeDatabasePlayers();
            context.Player.AddRange(players);

            //  [3.] Initialize Roster Table with Data
            Roster roster = new Roster().InitializeDatabaseRoster();
            roster.Team = teams[0];
            roster.Players = players;
            context.Roster.Add(roster);

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
            //context.SaveChanges();
            base.Seed(context);
        }
    }
}
