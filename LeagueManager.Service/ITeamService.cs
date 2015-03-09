using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LeagueManager.Domain;

namespace LeagueManager.Service
{
    [ServiceContract]
    public interface ITeamService
    {
        [OperationContract]
        Team GetTeamById(Guid id);

        [OperationContract]
        Team InsertTeam(Team team);

        //[OperationContract]
        //Team UpdateTeam(Guid id);

        [OperationContract]
        void DeleteTeam(Guid id);
    }
}
