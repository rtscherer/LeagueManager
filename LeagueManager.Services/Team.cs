///-----------------------------------------------------
/// LEAGUE MANAGER SERVICES
/// Team.cs
/// Description: LeagueManager Team Service
/// Author: Ryan Scherer, SchererDevelopment
/// Last Updated: 04/25/2015
///-----------------------------------------------------
namespace LeagueManager.Services
{
    using LeagueManager.Core;
    using System;
    using System.Collections.Generic;

    public class Team : ITeam
    {
        /// <summary>
        /// Get a Team By Id
        /// </summary>
        /// <returns>Team Object</returns>
        public Domain.Team GetTeamById()
        {
            throw new NotImplementedException("GetTeamById has not yet been implmented.");
        }

        /// <summary>
        /// Get a List of All Existing Teams
        /// </summary>
        /// <returns>IEnumerable of Type Team</returns>
        public IEnumerable<Domain.Team> GetTeams()
        {
            return new TeamManager().GetAllTeams();
        }

        /// <summary>
        /// Insert a New Team and Create an Associated Empty Roster Id
        /// </summary>
        /// <param name="name">Team Name</param>
        /// <returns>Team Object</returns>
        public Domain.Team InsertTeam(string name)
        {
            return new TeamManager().InsertTeam(name);
        }

        /// <summary>
        /// Update an Existing Team
        /// </summary>
        /// <param name="teamId">Guid Team Id</param>
        /// <param name="name">Team Name</param>
        /// <returns>Team Object</returns>
        public LeagueManager.Domain.Team UpdateTeam(Guid teamId, string name)
        {
            throw new NotImplementedException("UpdateTeam has not yet been implmented.");
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
