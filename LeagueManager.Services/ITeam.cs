///-----------------------------------------------------
/// LEAGUE MANAGER SERVICES
/// ITeam.cs
/// Description: LeagueManager Team Service
/// Author: Ryan Scherer, SchererDevelopment
/// Last Updated: 04/25/2015
///-----------------------------------------------------
namespace LeagueManager.Services
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface ITeam
    {
        /// <summary>
        /// Get a Team By Id
        /// </summary>
        /// <returns>Team Object</returns>
        [OperationContract]
        LeagueManager.Domain.Team GetTeamById();

        /// <summary>
        /// Get a List of All Existing Teams
        /// </summary>
        /// <returns>IEnumerable of Type Team</returns>
        [OperationContract]
        IEnumerable<LeagueManager.Domain.Team> GetTeams();

        /// <summary>
        /// Insert a New Team and Create an Associated Empty Roster It
        /// </summary>
        /// <param name="name">Team Name</param>
        /// <returns>Team Object</returns>
        [OperationContract]
        LeagueManager.Domain.Team InsertTeam(string name);

        /// <summary>
        /// Update an Existing Team
        /// </summary>
        /// <param name="teamId">Guid Team Id</param>
        /// <param name="name">Team Name</param>
        /// <returns>Team Object</returns>
        [OperationContract]
        LeagueManager.Domain.Team UpdateTeam(Guid teamId, string name);

        /// <summary>
        /// Delete a Team By Team Id
        /// </summary>
        /// <param name="teamId">Guid Team Id</param>
        [OperationContract]
        void DeleteTeam(Guid teamId);
    }
}
