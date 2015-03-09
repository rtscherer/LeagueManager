using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LeagueManager.Services
{
    [ServiceContract]
    public interface ITeam
    {
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
        /// Delete a Team By Team Id
        /// </summary>
        /// <param name="teamId">Guid Team Id</param>
        [OperationContract]
        void DeleteTeam(Guid teamId);
    }
}
