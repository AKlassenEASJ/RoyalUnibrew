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
    public class FaerdigVaresController : ApiController
    {

        #region Manager

        FaerdigVareManager manager = new FaerdigVareManager();

        #endregion

        // GET: api/FaerdigVares
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FaerdigVares/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FaerdigVares
        public bool Post([FromBody]FaerdigVare faerdigVare)
        {

            return manager.Post(faerdigVare);
            
           
            

        }

        // PUT: api/FaerdigVares/5
        [Route("api/FaerdigVares/{nummer}")]
        public bool Put(int nummer, [FromBody]FaerdigVare faerdigvare) 
        {
            return manager.Put(nummer, faerdigvare);
        }

        // DELETE: api/FaerdigVares/5
        public void Delete(int id)
        {
        }
    }
}
