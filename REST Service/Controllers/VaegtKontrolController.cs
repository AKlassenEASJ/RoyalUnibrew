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
        
        // GET: api/VaegtKontrol/5
        public VaegtKontrol Get(int Kontrol_Nr)
        {
            return manager.Get(Kontrol_Nr);
        }

        //
        [Route("api/VaegtKontrol/max/{process_ordre_nr}")]
        public int GetKontrolMaxNr(int process_ordre_nr)
        {
            return manager.Getmax(process_ordre_nr);
        }

        // POST: api/VaegtKontrol
        public bool Post([FromBody]VaegtKontrol value)
        {
            return manager.Post(value);
        }
        


        #region Ubrugte
        

        
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
