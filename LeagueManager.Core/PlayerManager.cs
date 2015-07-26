using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueManager.Domain;
using LeagueManager.Data;

namespace LeagueManager.Core
{
    public class PlayerManager
    {
        

        public void InsertPlayer(Player player)
        {
            new PlayerAccessor().InsertPlayer(player);
        }

        public void DeletePlayer(Guid playerId)
        {

        }
    }
}
