using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Domain
{
    public class Game : Sport
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Facility Facility { get; set; }
        public GameFormat Format { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public Boolean IsScoreFinal { get; set; }
        public LastUpdate LastUpdate { get; set; }

        public Game() { }

        public enum GameFormat
        {
            Exhibition,
            RegularSeason,
            Playoff
        }

        #region Private Properties
        //
        private string GameTypeString { get { return ConvertGameTypeEnumToStringValue(Format); } }
        //
        #endregion

        #region Private Methods
        //
        /// <summary>
        /// Convert Game Type Enum Value to Game Type String Value
        /// </summary>
        /// <param name="gameFormat">Game Type Enum</param>
        /// <returns>Game Type String Value</returns>
        private string ConvertGameTypeEnumToStringValue(GameFormat gameFormat)
        {
            throw new NotImplementedException();
        }
        //
        #endregion
    }
}
