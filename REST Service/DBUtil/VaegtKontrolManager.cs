using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Windows.Markup;
using ModelLibary.Models;
using ModelLibrary.Models;

namespace REST_Service.DBUtil
{
    public class VaegtKontrolManager
    {
        private const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = RoyalUniBrew; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string GET = "SELECT * FROM VaegtKontrol";
        private const string INSERT = "INSERT INTO VaegtKontrol (Process_Ordre_Nr, DatoTid, Vaegt_Kontrol_Nr) VALUES(@Process_Ordre_Nr, @DatoTid, @Vaegt_Kontrol_Nr)";
        




        // GET: api/VaegtKontrolManager
        public IEnumerable<VaegtKontrol> Get()
        {
            List<VaegtKontrol> liste = new List<VaegtKontrol>();

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                VaegtKontrol vaegtKontrol = ReadVaegtKontrol(reader);
                liste.Add(vaegtKontrol);
            }
            conn.Close();


            return liste;
        }

        // GET: api/VaegtKontrolManager/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/VaegtKontrolManager
        public bool Post(VaegtKontrol vaegtKontrol)
        {
            bool retValue = false;

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@@Process_Ordre_Nr", vaegtKontrol.ProcessOrdreNr);
            cmd.Parameters.AddWithValue("@DatoTid", vaegtKontrol.DatoTid);
            cmd.Parameters.AddWithValue("@Vaegt_Kontrol_Nr", vaegtKontrol.KontrolNr);

            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1 ? true : false;
            conn.Close();
            
            return retValue;
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
