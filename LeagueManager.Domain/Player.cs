using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Domain
{
    [Table("player")]
    public class Player
    {
        #region Constructor
        public Player() { }
        #endregion

        /// <summary>
        /// Player Id
        /// </summary>
        [Key]
        [Index]
        [Required]
        [Column("id")]
        public Guid PlayerId { get; set; }

        /// <summary>
        /// Roster
        /// </summary>
        public Guid roster_id_fk { get; set; }
        [ForeignKey("roster_id_fk")]
        public Roster Roster { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [Required]
        [Column("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Phone Number
        /// </summary>
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// EMail
        /// </summary>
        [Column("email")]
        public string EMail { get; set; }

        /// <summary>
        /// Primary Position
        /// </summary>
        [Column("primary_position")]
        public string PrimaryPosition { get; set; }

        /// <summary>
        /// Secondary Position
        /// </summary>
        [Column("secondary_position")]
        public string SecondaryPosition { get; set; }

        /// <summary>
        /// Batting Position
        /// </summary>
        [Column("batting_position")]
        public string BattingPosition { get; set; }

        /// <summary>
        /// Roster Status (Has Roster Been Signed)
        /// </summary>
        [Column("roster_status")]
        public Boolean HasSignedRoster { get; set; }

        /// <summary>
        /// League Fee Status (Has League Fee Been Paid)
        /// </summary>
        [Column("league_fee_status")]
        public Boolean HasPayedLeagueFee { get; set; }

        /// <summary>
        /// Player Record Last Update Data
        /// </summary>
        public LastUpdate LastUpdate { get; set; }

        #region Public Methods
        /// <summary>
        /// Initialize the Database with Data On Schema Rebuild
        /// </summary>
        /// <returns>List of Player Object</returns>
        public List<Player> InitializeDatabasePlayers()
        {
            return new List<Player>() { 
                new Player() { PlayerId = Guid.NewGuid(), FirstName = "Art", LastName = "Nigro", PhoneNumber = "(585) 555-5555", EMail = "anigro@yahoo.com", PrimaryPosition = "C", SecondaryPosition = "2B", BattingPosition = "Right", HasSignedRoster = false, HasPayedLeagueFee = true, LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now }},
                new Player() { PlayerId = Guid.NewGuid(), FirstName = "Marc", LastName = "Guerrie", PhoneNumber = "(585) 555-5555", EMail = "mguerrie@yahoo.com", PrimaryPosition = "1B", SecondaryPosition = "DH", BattingPosition = "Right", HasSignedRoster = false, HasPayedLeagueFee = false, LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now }},
                new Player() { PlayerId = Guid.NewGuid(), FirstName = "Randy", LastName = "Kaufman", PhoneNumber = "(585) 555-5555", EMail = "rkaufman@yahoo.com", PrimaryPosition = "SS", SecondaryPosition = "DH", BattingPosition = "Right", HasSignedRoster = true, HasPayedLeagueFee = true, LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now }},
                new Player() { PlayerId = Guid.NewGuid(), FirstName = "Jack", LastName = "Walter", PhoneNumber = "(585) 555-5555", EMail = "jwalter@gmail.com", PrimaryPosition = "L", SecondaryPosition = "3B", BattingPosition = "Right", HasSignedRoster = true, HasPayedLeagueFee = true, LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now }},
                new Player() { PlayerId = Guid.NewGuid(), FirstName = "Matt", LastName = "Parr", PhoneNumber = "(585) 555-5555", EMail = "mparr@ur.rochester.edu", PrimaryPosition = "R", SecondaryPosition = "C", BattingPosition = "Right", HasSignedRoster = true, HasPayedLeagueFee = true, LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now }}
            };
        }
        #endregion
    }
}
