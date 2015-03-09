using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Domain
{
    public partial class ContactPerson
    {
        #region Public Methods
        /// <summary>
        /// Initialize the Database with Data On Schema Rebuild
        /// </summary>
        /// <returns>List of ContactPerson Object</returns>
        public List<ContactPerson> InitializeDatabaseContactPerson()
        {
            return new List<ContactPerson>() {
                new ContactPerson()
                {
                    ContactPersonId = Guid.NewGuid(),
                    FirstName = "Andy",
                    LastName = "Yazinski",
                    EmailAddress1 = string.Empty,
                    EmailAddress2 = string.Empty,
                    Phone1 = "(585) 323-2635",
                    Phone2 = string.Empty,
                    LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now }
                },
                new ContactPerson()
                {
                    ContactPersonId = Guid.NewGuid(),
                    FirstName = "Hector",
                    LastName = "Martinez",
                    EmailAddress1 = string.Empty,
                    EmailAddress2 = string.Empty,
                    Phone1 = "(585) 323-2635",
                    Phone2 = string.Empty,
                    LastUpdate = new LastUpdate() { UpdateUser = "Create Database Console", UpdateDate = DateTime.Now }
                }
            };

        }
        #endregion
    }
}
