using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueManager.Domain;
using LeagueManager.Data;

namespace LeagueManager.Core
{
    public class TeamManager
    {
        public Team GetTeamById(Guid teamId)
        {
            return new TeamAccessor().GetTeamById(teamId);
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return new TeamAccessor().GetAllTeams;
        }

        public Team InsertTeam(string name)
        {
            Domain.Team team = new Domain.Team()
            {
                TeamId = Guid.NewGuid(),
                Name = name,
                LastUpdate = new LastUpdate() { UpdateUser = "Api", UpdateDate = DateTime.Now }
            };
            new TeamAccessor().InsertTeam(team);

            Roster roster = new Roster()
            {
                RosterId = Guid.NewGuid(),
                team_id_fk = team.TeamId,
                LastUpdate = new LastUpdate() { UpdateUser = "Api", UpdateDate = DateTime.Now }
            };
            new RosterAccessor().InsertRoster(roster);

            return team;
        }

        public void UpdateTeam(Team team)
        {
            new TeamAccessor().UpdateTeam(team);
        }

        public void DeleteTeam(Guid teamId)
        {
            new TeamAccessor().DeleteTeam(teamId);
            new RosterAccessor().DeleteRoster(teamId);
        }
    }
}
