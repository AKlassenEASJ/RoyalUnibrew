using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelLibary.Models;
using ModelLibrary.Models;
using REST_Service.DBUtil;

namespace REST_Service.Controllers
{
    public class VaegtKontrolController : ApiController
    {
        VaegtKontrolManager manager = new VaegtKontrolManager();

        // GET: api/VaegtKontrol
        public IEnumerable<VaegtKontrol> Get()
        {
            return manager.Get();
        }


        // POST: api/VaegtKontrol
        public bool Post([FromBody]VaegtKontrol value)
        {
            return manager.Post(value);
        }
        
        #region Ubrugte

        // GET: api/VaegtKontrol/5
        public string Get(int id)
        {
            return "value";
        }
        // PUT: api/VaegtKontrol/5
        public void Put(int id, [FromBody]string value)
        {
        }
        // DELETE: api/VaegtKontrol/5
        public void Delete(int id)
        {
        }
        #endregion
    }
}
