using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueManager.Domain
{
    [Table("league")]
    public class League
    {
        /// <summary>
        /// League Id
        /// </summary>
        [Key]
        [Index]
        [Required]
        [Column("id")]
        public Guid LeagueId { get; set; }

        /// <summary>
        /// League Name
        /// </summary>
        [Required]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Facility
        /// </summary>
        public Guid facility_id_fk { get; set; }
        [ForeignKey("facility_id_fk")]
        public Facility Facility { get; set; }

        /// <summary>
        /// League Cost (US$)
        /// </summary>
        [Column("cost")]
        public decimal Cost { get; set; }

        /// <summary>
        /// League Facilitator 1
        /// </summary>
        public Guid contactperson_id_fk1 { get; set; }
        [ForeignKey("contactperson_id_fk1")]
        public ContactPerson Facilitator1 { get; set; }

        /// <summary>
        /// League Facilitator 2
        /// </summary>
        public Guid contactperson_id_fk2 { get; set; }
        [ForeignKey("contactperson_id_fk2")]
        public ContactPerson Facilitator2 { get; set; }

        /// <summary>
        /// League Record Last Update Data
        /// </summary>
        public LastUpdate LastUpdate { get; set; }

        #region Public Methods
        /// <summary>
        /// Initialize the Database with Data On Schema Rebuild
        /// </summary>
        /// <returns>List of League Object</returns>
        public League InitializeDatabaseLeague()
        {
            return new League()
            {
                LeagueId = Guid.NewGuid(),
                Name = "Rochester NY City League",
                Cost = 730.00M,
                LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now }
            };
        }
        #endregion
    }
}
