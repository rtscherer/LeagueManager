using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Domain
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public List<Game> Games { get; set; }
        public LastUpdate LastUpdate { get; set; }

        public Schedule()
        {
            this.Games = new List<Game>(0);
        }
    }
}
