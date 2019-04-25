using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelLibary.Models;



namespace REST_Service.Controllers
{
    public class AnsatsController : ApiController
    {
        // GET: api/Ansats
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Ansats/5
        public Ansat Get(string id)
        {
            return "value";
        }

        // POST: api/Ansats
        public void Post([FromBody]Ansat value)
        {
        }

        // PUT: api/Ansats/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ansats/5
        public void Delete(int id)
        {
        }
    }
}
