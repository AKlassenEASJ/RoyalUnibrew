using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelLibary.Models;
using REST_Service.DBUtil;

namespace REST_Service.Controllers
{
    public class BemandingsController : ApiController
    {
        #region Manager

        private BemandingManager _manager = new BemandingManager();

        #endregion


        // GET: api/Bemandings
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Bemandings/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bemandings
        public bool Post([FromBody]Bemanding bemandingToPost)
        {
            return _manager.Post(bemandingToPost);

        }

        // PUT: api/Bemandings/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bemandings/5
        public void Delete(int id)
        {
        }
    }
}
