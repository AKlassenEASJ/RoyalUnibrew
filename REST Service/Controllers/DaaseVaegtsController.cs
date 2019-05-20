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
    public class DaaseVaegtsController : ApiController
    {
        DaaseVaegtManger manger = new DaaseVaegtManger();
        // GET: api/DaaseVaegts
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DaaseVaegts/5
        [Route ("api/DaaseVaegts/{PONr}/{KNR}")]
        public IEnumerable<DaaseVaegt> Get(int PONr, int KNR)
        {
            return manger.Get(PONr, KNR);
        }

        // POST: api/DaaseVaegts
        public void Post([FromBody]DaaseVaegt value)
        {
            manger.Post(value);
        }

        // PUT: api/DaaseVaegts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DaaseVaegts/5
        public void Delete(int id)
        {
        }
    }
}
