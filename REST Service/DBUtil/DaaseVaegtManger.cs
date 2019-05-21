using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibary.Models;


namespace REST_Service.DBUtil
{
    public class DaaseVaegtManger
    {
        private const string ConnString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LokalRoyalUnibrew;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string GET = "SELECT * FROM VaegtDaase WHERE Process_Ordre_Nr = @PONR AND Kontrol_Nr = @KNR;";
        private const string INSERT = "INSERT INTO VaegtDaase (Process_Ordre_Nr, Kontrol_Nr, Daase_Nr, Vaegt) VALUES (@PONR, @KNR, @DNR, @Vaegt)";
        private const string GetVaegts = "SELECT * FROM VaegtKontrol WHERE Process_Ordre_Nr = @PONR;";


        public IEnumerable<DaaseVaegt> Get(int ProcessOrderNr, int KontrolNr)
        {
           List<DaaseVaegt> daaser = new List<DaaseVaegt>();

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET, conn);
            cmd.Parameters.AddWithValue("@PONR", ProcessOrderNr);
            cmd.Parameters.AddWithValue("@KNR", KontrolNr);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DaaseVaegt daaseVaegt = ReadDaaseVaegt(reader);
                daaser.Add(daaseVaegt);
            }
            conn.Close();

            return daaser;
        }

        private DaaseVaegt ReadDaaseVaegt(SqlDataReader reader)
        {
            DaaseVaegt daase = new DaaseVaegt();

            daase.ProcessOrderNr = reader.GetInt32(0);
            daase.KontrolOrderNr = reader.GetInt32(1);
            daase.DaaseNr = reader.GetInt32(2);
            daase.DasseVaegt = reader.GetDouble(3);

            return daase;
        }

        public bool Post(DaaseVaegt daaseVeVaegt)
        {
            bool retValue = false;

            SqlConnection conn = new SqlConnection(ConnString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(INSERT, conn);
                cmd.Parameters.AddWithValue("@PONR", daaseVeVaegt.ProcessOrderNr);
                cmd.Parameters.AddWithValue("@KNR", daaseVeVaegt.KontrolOrderNr);
                cmd.Parameters.AddWithValue("@DNR", daaseVeVaegt.DaaseNr);
                cmd.Parameters.AddWithValue("@Vaegt", daaseVeVaegt.DasseVaegt);

                int rowsAffected = cmd.ExecuteNonQuery();
                retValue = rowsAffected == 1 ? true : false;
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    $"{daaseVeVaegt.ProcessOrderNr}/n{daaseVeVaegt.KontrolOrderNr}/n{daaseVeVaegt.DaaseNr}/n{daaseVeVaegt.DasseVaegt}");
            }

            finally
            {
                conn.Close();
            }

            return retValue;
        }

        public IEnumerable<VaegtKontrol> GetVaegtKontrols(int ProcessOrderNr)
        {
            List<VaegtKontrol> liste = new List<VaegtKontrol>();

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GetVaegts, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                VaegtKontrol vaegtKontrol = ReadVaegts(reader);
                liste.Add(vaegtKontrol);
            }
            conn.Close();
            return liste;
        }

        private VaegtKontrol ReadVaegts(SqlDataReader reader)
        {
            VaegtKontrol vaegtKontrol = new VaegtKontrol();

            vaegtKontrol.ProcessOrdreNr = reader.GetInt32(0);
            vaegtKontrol.KontrolNr = reader.GetInt32(1);
            vaegtKontrol.DatoTid = reader.GetDateTime(2);

            return vaegtKontrol;
        }
    }
}