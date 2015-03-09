using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LeagueManager.Domain;
using LeagueManager.Core;

namespace LeagueManager.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Team : ITeam
    {
        /// <summary>
        /// Get a List of All Existing Teams
        /// </summary>
        /// <returns>IEnumerable of Type Team</returns>
        public IEnumerable<Domain.Team> GetTeams()
        {
            return new TeamManager().GetTeams();
        }

        /// <summary>
        /// Insert a New Team and Create an Associated Empty Roster It
        /// </summary>
        /// <param name="name">Team Name</param>
        /// <returns>Team Object</returns>
        public Domain.Team InsertTeam(string name)
        {
            return new TeamManager().InsertTeam(name);
        }

        /// <summary>
        /// Delete a Team By Team Id
        /// </summary>
        /// <param name="teamId">Guid Team Id</param>
        public void DeleteTeam(Guid teamId)
        {
            new TeamManager().DeleteTeam(teamId);
        }
    }
}
