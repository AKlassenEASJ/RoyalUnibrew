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
    public class ProcessOrdreController : ApiController
    {
        ProcessOrdreManager manager = new ProcessOrdreManager();

        // GET: api/ProcessOrdre
        public IEnumerable<ProcessOrdre> Get()
        {
            return manager.Get();
        }



        // GET: api/ProcessOrdre/5
        [Route("api/ProcessOrdre/{processOrdreNr}")]
        public ProcessOrdre Get(int processOrdreNr)
        {
            return manager.Get(processOrdreNr);
        }

        //Get: api/ProcessOrdre/{date}
        [Route("api/ProcessOrdreDate/{Dato}")]
        public IEnumerable<ProcessOrdre> Get(DateTime Dato)
        {
            return manager.Get(Dato);
        }
        // POST: api/ProcessOrdre
        public bool Post([FromBody]ProcessOrdre processOrdre)
        {
            return manager.Post(processOrdre);
        }

        //Delete: api/ProcessOrdre/5
        public bool Delete(int processOrdreNr)
        {
            return manager.Delete(processOrdreNr);
        }
    }
}
