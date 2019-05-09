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
    public class AnsatsController : ApiController
    {

        #region Manager

        private AnsatManager _manager = new AnsatManager();

        #endregion


        // GET: api/Ansats
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        // GET: api/Ansats/5
        public Ansat Get(string initialer)
        {
            return _manager.Get(initialer);
        }

        // POST: api/Ansats
        public bool Post([FromBody]Ansat ansat)
        {
            return _manager.Post(ansat);
        }

        // PUT: api/Ansats/5
        public bool Put(string initialer, [FromBody]Ansat ansat)
        {
            return _manager.Put(initialer, ansat);
        }

        // DELETE: api/Ansats/5
        public bool Delete(string initialer)
        {
            return _manager.Delete(initialer);
        }
    }
}
