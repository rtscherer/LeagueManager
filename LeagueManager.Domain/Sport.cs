using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Domain
{
    public class Sport
    {
        public int Id { get; set; }
        public SportType SportName { get; set; }
        public GameDurationType GameDuration { get { return DetermineGameDurationType(SportName); } }

        public enum SportType
        {
            Baseball,
            Football,
            Basketball,
            Hockey
        }

        public enum GameDurationType
        {
            Inning,
            Quarter,
            Half,
            Period
        }

        public GameDurationType DetermineGameDurationType(SportType sportType)
        {
            switch (sportType)
            {
                case SportType.Baseball:
                    return GameDurationType.Inning;
                case SportType.Football:
                    return GameDurationType.Quarter;
                case SportType.Basketball:
                    return GameDurationType.Quarter;
                case SportType.Hockey:
                    return GameDurationType.Period;
                default:
                    return GameDurationType.Inning;
            }
        }
    }
}
