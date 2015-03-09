using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueManager.Domain
{
    [Table("contact_person")]
    public partial class ContactPerson
    {
        /// <summary>
        /// Contact Person Id
        /// </summary>
        [Key]
        [Index]
        [Required]
        [Column("id")]
        public Guid ContactPersonId { get; set; }

        /// <summary>
        /// Contact Person First Name
        /// </summary>
        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Contact Person Last Name
        /// </summary>
        [Required]
        [Column("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Contact Person Phone 1
        /// </summary>
        [Required]
        [Column("phone1")]
        public string Phone1 { get; set; }

        /// <summary>
        /// Contact Person Phone 2
        /// </summary>
        [Column("phone2")]
        public string Phone2 { get; set; }

        /// <summary>
        /// Contact Person Email Address 1
        /// </summary>
        [Column("email_address1")]
        public string EmailAddress1 { get; set; }

        /// <summary>
        /// Contact Person Email Address 2
        /// </summary>
        [Column("email_address2")]
        public string EmailAddress2 { get; set; }

        /// <summary>
        /// Contact Person Record Last Update Data
        /// </summary>
        public LastUpdate LastUpdate { get; set; }
    }
}
