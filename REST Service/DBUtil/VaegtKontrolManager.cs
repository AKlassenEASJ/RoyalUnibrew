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

        #region connectionstring
        private const string ConnectionString = "Data Source=aklassen-zeland2019.database.windows.net;Initial Catalog=RoyalUniBrew;User ID=Line644s;Password=Database123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //private const string ConnectionString =
        //    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = RoyalUniBrew; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        #endregion


        #region SQL statements
        private const String GETALL = "SELECT * FROM VaegtKontrol";
        private const String GETONE = "SELECT * FROM VaegtKontrol WHERE Kontrol_Nr = @ID";
        private const String INSERT = "INSERT INTO VaegtKontrol (Process_Ordre_Nr, Kontrol_Nr, Dato_Tid) VALUES(@Process_Ordre_Nr, @Kontrol_Nr, @Dato_Tid)";
        private const String GETMAX = "SELECT * FROM hentMaxKontrol_Nr WHERE Process_Ordre_Nr = @PODID";
        private const String DELETE = "DELETE FROM VaegtKontrol WHERE Kontrol_Nr = @ID";
        #endregion


        #region Metoder
        //GETALL: api/VaegtKontrolManager
        public IEnumerable<VaegtKontrol> Get()
        {
            List<VaegtKontrol> liste = new List<VaegtKontrol>();

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GETALL, conn);
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
        public VaegtKontrol Get(int idNr)
        {
            VaegtKontrol vaegtKontrol = null;

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(GETONE, connection);
            cmd.Parameters.AddWithValue("@ID", idNr);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                vaegtKontrol = ReadVaegtKontrol(reader);
            }
            connection.Close();
            return vaegtKontrol;
        }


        // Optælling af kontroller get
        public int Getmax(int idNr)
        {
            int vaegtKontrol = 0;

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(GETMAX, connection);
            cmd.Parameters.AddWithValue("@PODID", idNr);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                vaegtKontrol = reader.GetInt32(0);
            }
            connection.Close();
            return vaegtKontrol;
        }



        // POST: api/VaegtKontrolManager
        public bool Post(VaegtKontrol vaegtKontrol)
        {
            bool retValue = false;

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@Process_Ordre_Nr", vaegtKontrol.ProcessOrdreNr);
            cmd.Parameters.AddWithValue("@Kontrol_Nr", vaegtKontrol.KontrolNr);
            cmd.Parameters.AddWithValue("@Dato_Tid", vaegtKontrol.DatoTid);

            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1 ? true : false;
            conn.Close();
            
            return retValue;
        }
        
        // DELETE: api/VaegtKontrolManager/5
        public bool Delete(int kontrolNr)
        {

            bool success = true;

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DELETE, conn);
            cmd.Parameters.AddWithValue("@ID", kontrolNr);

            int rowsAffected = cmd.ExecuteNonQuery();
            success = rowsAffected == 1;

            return success;
        }




        #region Ubrugte metoder
        // PUT: api/VaegtKontrolManager/5


        public void Put(int id, [FromBody]string value)
        {
        }

        #endregion
        #endregion


        #region Hjælpemetoder
        private VaegtKontrol ReadVaegtKontrol(SqlDataReader reader)
        {
            VaegtKontrol tempVaegtKontrol = new VaegtKontrol();

            tempVaegtKontrol.ProcessOrdreNr = reader.GetInt32(0);
            tempVaegtKontrol.KontrolNr = reader.GetInt32(1);
            tempVaegtKontrol.DatoTid = reader.GetDateTime(2);

            return tempVaegtKontrol;

        }
        #endregion


        // SQL kode til oprettelse af database view for at Getmax kan fungerer:
        // skal skrives i en sql query efter vaegtkontrol er oprettet
        // (du skal tilrette Vaegtkontrol til hvad du selv har kaldt vaegtkontrol i din database)
        /*
        create view hentMaxKontrol_Nr as 
        select Max(Kontrol_Nr) as maxKontrol, Process_Ordre_Nr from VaegtKontrol group by Process_Ordre_Nr
        */
        
    }
}
