using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueManager.Domain;
using LeagueManager.DataLayer;

namespace LeagueManager.Core
{
    public class PlayerManager
    {
        public IEnumerable<Player> GetPlayers()
        {
            Roster roster = new Roster()
            {
                RosterId = new Guid("15b6cb13-1c4e-4b51-b442-5a7f226a3e6a")
            };

            return new PlayerAccessor().GetPlayers(roster);
        }
    }
}
