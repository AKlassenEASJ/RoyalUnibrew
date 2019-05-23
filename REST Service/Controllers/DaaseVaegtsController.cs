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
        [Route("api/DaaseVaegts/{ProcessOrderNr}")]
        public IEnumerable<VaegtKontrol> Get(int ProcessOrderNr)
        {
            return manger.GetVaegtKontrols(ProcessOrderNr);
        }

        // GET: api/DaaseVaegts/5
        [Route ("api/DaaseVaegts/{PONr}/{KNR}")]
        public IEnumerable<DaaseVaegt> Get(int PONr, int KNR)
        {
            return manger.Get(PONr, KNR);
        }

        // POST: api/DaaseVaegts
        public bool Post([FromBody]DaaseVaegt value)
        {
            return manger.Post(value);
        }

        // PUT: api/DaaseVaegts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DaaseVaegts/5
        public void Delete(int id)
        {
        }

        //[Route("api/DaaseVaegts/VaegtKontrol/{ProcessOrderNr}")]
        //public IEnumerable<VaegtKontrol> VaegtKontrols([FromBody]int ProcessOrderNr)
        //{
        //    return manger.GetVaegtKontrols(ProcessOrderNr);
        //}
    }
}
