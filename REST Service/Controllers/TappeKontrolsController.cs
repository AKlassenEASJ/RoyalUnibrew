using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelLibrary.Models;
using REST_Service.DBUtil;

namespace REST_Service.Controllers
{
    public class TappeKontrolsController : ApiController
    {
        TappeKontrolManger manger = new TappeKontrolManger();

        // GET: api/TappeKontrols
        public IEnumerable<TappeKontrol> Get()
        {
            return manger.Get();
        }

        // GET: api/TappeKontrols/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TappeKontrols
        public bool Post([FromBody]TappeKontrol value)
        {
            return manger.Post(value);
        }

        // PUT: api/TappeKontrols/5
        public void Put(int id, [FromBody]string value)
        {
           
        }

        // DELETE: api/TappeKontrols/5
        public void Delete(int id)
        {
        }
    }
}
