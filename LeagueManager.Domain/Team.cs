using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Domain
{
    [Table("team")]
    public class Team
    {
        #region Constructor
        public Team()
        {
            if (TeamId == Guid.Empty)
                TeamId = Guid.NewGuid();
        }
        #endregion

        /// <summary>
        /// Team Id
        /// </summary>
        [Key]
        [Index]
        [Required]
        [Column("id")]
        public Guid TeamId { get; set; }

        /// <summary>
        /// Team Name
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        //public League League { get; set; }
        //public Schedule Schedule { get; set; }
        //public Ranking Ranking { get; set; }

        /// <summary>
        /// Team Record Last Update Data
        /// </summary>
        public LastUpdate LastUpdate { get; set; }

        #region Public Methods
        /// <summary>
        /// Validate that the Team Object Has Been Constructed Properly
        /// </summary>
        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new Exception("Team object is not valid. Team must have a Name.");
            if (string.IsNullOrEmpty(LastUpdate.UpdateUser))
                throw new Exception("Team object is not valid. Last Update property must contain a username.");
        }

        /// <summary>
        /// Initialize the Database with Data On Schema Rebuild
        /// </summary>
        /// <returns>List of Team Object</returns>
        public List<Team> InitializeDatabaseTeams()
        {
            return new List<Team>() {
                new Team() { TeamId = Guid.NewGuid(), Name = "Wolfpack", LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now } },
                new Team() { TeamId = Guid.NewGuid(), Name = "DragonFly", LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now } },
                new Team() { TeamId = Guid.NewGuid(), Name = "Johnny's", LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now } },
                new Team() { TeamId = Guid.NewGuid(), Name = "Abeline", LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now } },
                new Team() { TeamId = Guid.NewGuid(), Name = "Jeremiah's", LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now } }
            };
        }
        #endregion
    }
}
