using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LeagueManager.Domain;
using LeagueManager.Core;

namespace LeagueManager.Api.Controllers
{
    public class TeamsController : ApiController
    {
        public TeamsController() { }

        // GET api/values
        public IEnumerable<Team> GetAllTeams()
        {
            return new TeamManager().GetAllTeams();
        }

        // GET api/values/5
        public Team GetTeamById(Guid id)
        {
            return new TeamManager().GetTeamById(id);
        }

        // POST api/values
        [HttpPost]
        public Team Post([FromBody]string Name)
        {
            Team team = new TeamManager().InsertTeam(Name);

            var inserted = new TeamManager().GetTeamById(team.TeamId);
            if (inserted == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return inserted;
        }

        // PUT api/values/5
        public Team Put(Guid id, Team value)
        {
            var updated = new TeamManager().GetTeamById(id);
            if (updated == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            new TeamManager().UpdateTeam(value);
            return updated;
        }

        // DELETE api/values/5
        public Team Delete(Guid id)
        {
            var deleted = new TeamManager().GetTeamById(id);
            if (deleted == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            new TeamManager().DeleteTeam(id);
            return deleted;
        }
    }
}