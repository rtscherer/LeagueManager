using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using LeagueManager.Domain;
using LeagueManager.Core;

namespace api.leaguemanager.Controllers
{
    public class PlayersController : ApiController
    {
        // GET: /Players/
        //public IEnumerable<Player> Get()
        //{
        //    return new PlayerManager().GetPlayers();
        //}

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
