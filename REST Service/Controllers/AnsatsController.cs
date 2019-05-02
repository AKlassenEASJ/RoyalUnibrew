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

        AnsatManager manager = new AnsatManager();

        #endregion


        // GET: api/Ansats
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        // GET: api/Ansats/5
        public Ansat Get(string initialer)
        {
            return manager.Get(initialer);
        }

        // POST: api/Ansats
        public bool Post([FromBody]Ansat ansat)
        {
            return manager.Post(ansat);
        }

        // PUT: api/Ansats/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ansats/5
        public bool Delete(string initialer)
        {
            return manager.Delete(initialer);
        }
    }
}
