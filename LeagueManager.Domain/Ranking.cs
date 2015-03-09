using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Domain
{
    public class Ranking
    {
        public Guid Id { get; set; }
        public RankingType Type { get; set; }
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public League League { get; set; }
        public int Rank { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public double WinningPercentage { get; set; }
        public int GamesBack { get; set; }
        public LastUpdate LastUpdate { get; set; }

        #region Constructor
        //
        public Ranking() { }

        public Ranking(Guid teamId, string teamName, League league, RankingType rankingType)
        {
            TeamId = teamId;
            TeamName = teamName;
            Type = rankingType;
            League = league;
            WinningPercentage = CalculateWinningPercentage(Wins, Losses);
            // Calculate
            Rank = 1;
            // Calculate
            GamesBack = 0;
        }
        //
        #endregion

        /// <summary>
        /// Ranking Scope Enum
        /// </summary>
        public enum RankingType
        {
            League,
            Division,
            WildCard
        }

        /// <summary>
        /// Calculate Winning Percentage
        /// </summary>
        /// <param name="wins">Wins</param>
        /// <param name="losses">Losses</param>
        /// <returns></returns>
        public double CalculateWinningPercentage(int wins, int losses)
        {
            int totalGames = wins + losses;
            double winningPercentage = (double)wins / (double)totalGames;

            return winningPercentage;
        }
    }
}
