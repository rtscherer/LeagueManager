using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Domain
{
    [Table("location")]
    public class Location
    {
        /// <summary>
        /// Location Id
        /// </summary>
        [Key]
        [Index]
        [Required]
        [Column("id")]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Location Name
        /// </summary>
        [Required, MaxLength(50)]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Location Address Line 1
        /// </summary>
        [Required]
        [Column("address_line1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Location Address Line 2
        /// </summary>
        [Column("address_line2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Location City
        /// </summary>
        [Required]
        [Column("city")]
        public string City { get; set; }

        /// <summary>
        /// Location State
        /// </summary>
        [Required]
        [Column("state")]
        public string State { get; set; }

        /// <summary>
        /// Location Zip Code
        /// </summary>
        [Required]
        [Column("zip")]
        public string Zip { get; set; }

        /// <summary>
        /// Location Record Last Update Data
        /// </summary>
        public LastUpdate LastUpdate { get; set; }

        #region Public Methods
        /// <summary>
        /// Initialize the Database with Data On Schema Rebuild
        /// </summary>
        /// <returns>List of Location Object</returns>
        public Location InitializeDatabaseLocation()
        {
            return new Location() {
                LocationId = Guid.NewGuid(),
                Name = "Cobbs Hill Park",
                AddressLine1 = "100 Norris Drive",
                AddressLine2 = "Culver Rd. and Norris Dr.",
                City = "Rochester",
                State = "NY",
                Zip = "14610",
                LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now }
            };
        }
        #endregion
    }
}
