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

            //return manager.
            

        }

    // PUT: api/FaerdigVares/5
    public bool Put(int nummer, [FromBody]FaerdigVare faerdigVare)
        {
            return manager.Put(nummer, faerdigVare);
        }

        // DELETE: api/FaerdigVares/5
        public void Delete(int id)
        {
        }
    }
}
