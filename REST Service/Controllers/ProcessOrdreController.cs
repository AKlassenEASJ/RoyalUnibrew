﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST_Service.Controllers
{
    public class ProcessOrdreController : ApiController
    {
        // GET: api/ProcessOrdre
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ProcessOrdre/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProcessOrdre
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProcessOrdre/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProcessOrdre/5
        public void Delete(int id)
        {
        }
    }
}
