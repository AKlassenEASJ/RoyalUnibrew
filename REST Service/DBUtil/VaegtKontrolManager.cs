using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelLibary.Models;

namespace REST_Service.DBUtil
{
    public class VaegtKontrolManager
    {
        private const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = RoyalUniBrew; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string GET = "SELECT * FROM VaegtKontrol";
        private const string INSERT = "INSERT INTO VaegtKontrol ()";
        




        // GET: api/VaegtKontrolManager
        public IEnumerable<VaegtKontrol> Get()
        {
            List<VaegtKontrol> liste = new List<VaegtKontrol>();

            SqlConnection conn = new SqlConnection(ConnectionString);




            return liste;
        }

        // GET: api/VaegtKontrolManager/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/VaegtKontrolManager
        public void Post([FromBody]VaegtKontrol value)
        {
        }

        // PUT: api/VaegtKontrolManager/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VaegtKontrolManager/5
        public void Delete(int id)
        {
        }

        private VaegtKontrol ReadVaegtKontrol(SqlDataReader reader)
        {
            VaegtKontrol tempVaegtKontrol = new VaegtKontrol();

            tempVaegtKontrol.ProcessOrdreNr = reader.GetInt32(0);
            tempVaegtKontrol.DatoTid = reader.GetDateTime(1);
            tempVaegtKontrol.KontrolNr = reader.GetInt32(2);

            return tempVaegtKontrol;

        }

    }
}
