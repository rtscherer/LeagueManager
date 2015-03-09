using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueManager.Domain;
using LeagueManager.DataLayer;

namespace LeagueManager.Core
{
    public class TeamManager
    {
        public IEnumerable<Team> GetTeams()
        {
            return new TeamAccessor().GetTeams;
        }

        public Team InsertTeam(string name)
        {
            Domain.Team team = new Domain.Team()
            {
                TeamId = Guid.NewGuid(),
                Name = name,
                LastUpdate = new LastUpdate() { UpdateUser = "TeamService", UpdateDate = DateTime.Now }
            };
            new TeamAccessor().InsertTeam(team);

            Roster roster = new Roster()
            {
                RosterId = Guid.NewGuid(),
                team_id_fk = team.TeamId,
                LastUpdate = new LastUpdate() { UpdateUser = "TeamService", UpdateDate = DateTime.Now }
            };
            new RosterAccessor().InsertRoster(roster);

            return team;
        }

        public void DeleteTeam(Guid teamId)
        {
            new TeamAccessor().DeleteTeam(teamId);
            new RosterAccessor().DeleteRoster(teamId);
        }
    }
}
