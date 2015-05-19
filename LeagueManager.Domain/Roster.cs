using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Domain
{
    [Table("roster")]
    public class Roster
    {
        #region Constructor
        public Roster() { } 
        #endregion

        /// <summary>
        /// Roster Id
        /// </summary>
        [Key]
        [Index]
        [Required]
        [Column("id")]
        public Guid RosterId { get; set; }

        /// <summary>
        /// Team Id Foreign Key Reference
        /// Team Object
        /// </summary>
        public Guid team_id_fk { get; set; }
        [ForeignKey("team_id_fk")]
        public Team Team { get; set; }

        /// <summary>
        /// List of Players
        /// </summary>
        public List<Player> Players { get; set; }
        
        /// <summary>
        /// Roster Record Last Update Data
        /// </summary>
        public LastUpdate LastUpdate { get; set; }

        #region Public Methods
        /// <summary>
        /// Initialize the Database with Data On Schema Rebuild
        /// </summary>
        /// <returns>List of Roster Object</returns>
        public Roster InitializeDatabaseRoster(Guid team_id_fk)
        {
            return new Roster() { RosterId = Guid.NewGuid(), team_id_fk = team_id_fk, LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now } };
        } 
        #endregion
    }
}
