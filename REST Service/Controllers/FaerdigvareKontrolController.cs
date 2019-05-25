using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using REST_Service.DBUtil;
using ModelLibary.Models;

namespace REST_Service.Controllers
{
    public class FaerdigvareKontrolController : ApiController
    {
        private FaerdigvareKontrolManager manager = new FaerdigvareKontrolManager();

        [Route("api/Faerdigvare/{process_ordre_nr}")]
        public FaerdigvareKontrol GetFaerdigvareKontrol(int process_ordre_nr)
        {
            return manager.GetFaerdigvareKontrol(process_ordre_nr);
        }



        #region ubrugte
        // GET: api/FaerdigvareKontrol
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FaerdigvareKontrol/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FaerdigvareKontrol
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FaerdigvareKontrol/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FaerdigvareKontrol/5
        public void Delete(int id)
        {
        }
        #endregion
    }
}
