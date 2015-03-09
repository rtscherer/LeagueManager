using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Domain
{
    public class LastUpdate
    {
        [Required, MaxLength(50)]
        [Column("update_user")]
        public string UpdateUser { get; set; }

        [Column("update_date")]
        public DateTime UpdateDate { get; set; }
    }
}
