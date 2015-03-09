using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Domain
{
    [Table("facility")]
    public class Facility
    {
        /// <summary>
        /// Factility Id
        /// </summary>
        [Key]
        [Index]
        [Required]
        [Column("id")]
        public Guid FacilityId { get; set; }

        /// <summary>
        /// Factility Name
        /// </summary>
        [Required, MaxLength(50)]
        [Column("name")]
        public string FacilityName { get; set; }

        /// <summary>
        /// Factility Location
        /// </summary>
        public Guid location_id_fk { get; set; }
        [ForeignKey("location_id_fk")]
        public Location Location { get; set; }

        /// <summary>
        /// Factility Contact Person 1
        /// </summary>
        public Guid contact_id_fk1 { get; set; }
        [ForeignKey("contact_id_fk1")]
        public ContactPerson ContactPerson1 { get; set; }

        /// <summary>
        /// Factility Contact Person 2
        /// </summary>
        public Guid contact_id_fk2 { get; set; }
        [ForeignKey("contact_id_fk2")]
        public ContactPerson ContactPerson2 { get; set; }

        /// <summary>
        /// Facility Phone Number
        /// </summary>
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Facility Record Last Update Data
        /// </summary>
        public LastUpdate LastUpdate { get; set; }

        #region Public Methods
        /// <summary>
        /// Initialize the Database with Data On Schema Rebuild
        /// </summary>
        /// <returns>List of Facility Object</returns>
        public Facility InitializeDatabaseFacility()
        {
            return new Facility()
            {
                FacilityId = Guid.NewGuid(),
                FacilityName = "Cobbs Hill Park Softball Fields",
                PhoneNumber = "(585) 428-6770",
                LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now }
            };
        }
        #endregion
    }
}
