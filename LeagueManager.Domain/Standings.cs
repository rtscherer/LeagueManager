using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Domain
{
    public class Standings
    {
        public List<Team> Teams { get; set; }

        public Standings()
        {
            this.Teams = new List<Team>(0);
        }
    }
}
