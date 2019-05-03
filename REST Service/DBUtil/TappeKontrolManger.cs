using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibrary.Models;


namespace REST_Service.DBUtil
{
    public class TappeKontrolManger
    {
        private const string ConnString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LokalRoyalUnibrew;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string GET = "SELECT * FROM TappeKontrol";
        private const string INSERT =
            "INSERT INTO TappeKontrol (Process_Ordre_Nr, Tidspunkt, Daase_Nr, Laag_Nr, Helhed, Kamera_Tjek, CCP, Vaeske_Temp, Kontrol_Temp, Tunnel_PH_Tjek, Vaegt_Kontrol, Smag_Test_Nr, Smag_Test, Kvitter_Proeve, Sukker_Tjek, CO2_Kontrol, Signatur) VALUES (@Process_Ordre_Nr, @Tidspunkt, @Daase_Nr, @Laag_Nr, @Helhed, @Kamera_Tjek, @CCP, @Vaeske_Temp, @Kontrol_Temp, @Tunnel_PH_Tjek, @Vaegt_Kontrol, @Smag_Test_Nr, @Smag_Test, @Kvitter_Proeve, @Sukker_Tjek, @CO2_Kontrol, @Signatur)";

        public IEnumerable<TappeKontrol> Get()
        {
            List<TappeKontrol> liste = new List<TappeKontrol>();

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                TappeKontrol tappeKontrol = ReadTappeKontrol(reader);
                liste.Add(tappeKontrol);
            }
            conn.Close();

            return liste;
        }

        private TappeKontrol ReadTappeKontrol(SqlDataReader reader)
        {
            TappeKontrol tappeKontrol = new TappeKontrol()
            {
                ProcessOrderNr = reader.GetInt32(0),
                Tidspunkt = reader.GetDateTime(1),
                Daasenr = reader.GetInt32(2),
                Laagnr = reader.GetInt32(3),
                Helhed = TjekStringNull(reader, 4),
                KameraTjek = TjekStringNull(reader, 5),
                Ccp = TjekStringNull(reader, 6),
                VaeskeTemp = reader.GetDouble(7),
                KontrolTemp = reader.GetDouble(8),
                TunnelPhTjek = TjekStringNull(reader, 9),
                VaegtKontrol = TjekDoubleNull(reader, 10),
                SmagsTestNr = TjekIntNull(reader, 11),
                SmagsTest = TjekStringNull(reader, 12),
                KviterProve = TjekStringNull(reader, 13),
                SukkerTjek = TjekStringNull(reader, 14),
                Co2Kontrol = TjekDoubleNull(reader, 15),
                Signatur = reader.GetString(16)
            };
           
            return tappeKontrol;
        }

        private string TjekStringNull(SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
            {
                return reader.GetString(index);
            }

            return null;
        }

        private int TjekIntNull(SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
            {
                    return reader.GetInt32(index);
            }

            return -1;
        }

        private double TjekDoubleNull(SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
            {
                return reader.GetDouble(index);
            }

            return -1;
        }

        public bool Post(TappeKontrol tappeKontrol)
        {
            bool retValue = false;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@Process_Ordre_Nr", tappeKontrol.ProcessOrderNr);
            cmd.Parameters.AddWithValue("@Tidspunkt", tappeKontrol.Tidspunkt);
            cmd.Parameters.AddWithValue("@Daase_Nr", tappeKontrol.Daasenr);
            cmd.Parameters.AddWithValue("@Laag_Nr", tappeKontrol.Laagnr);
            cmd.Parameters.AddWithValue("@Helhed", tappeKontrol.Helhed == null ? (object)DBNull.Value: tappeKontrol.Helhed);
            cmd.Parameters.AddWithValue("@Kamera_Tjek", tappeKontrol.KameraTjek == null ? (object)DBNull.Value : tappeKontrol.KameraTjek);
            cmd.Parameters.AddWithValue("@CCP", tappeKontrol.Ccp == null ? (object)DBNull.Value : tappeKontrol.Ccp);
            cmd.Parameters.AddWithValue("@Vaeske_Temp", tappeKontrol.VaeskeTemp);
            cmd.Parameters.AddWithValue("@Kontrol_Temp", tappeKontrol.KontrolTemp);
            cmd.Parameters.AddWithValue("@Tunnel_PH_Tjek", tappeKontrol.TunnelPhTjek == null ? (object)DBNull.Value : tappeKontrol.TunnelPhTjek);
            cmd.Parameters.AddWithValue("@Vaegt_Kontrol", tappeKontrol.VaegtKontrol == -1 ? (object)DBNull.Value : tappeKontrol.VaegtKontrol);
            cmd.Parameters.AddWithValue("@Smag_Test_Nr", tappeKontrol.SmagsTestNr == -1 ? (object)DBNull.Value : tappeKontrol.SmagsTestNr);
            cmd.Parameters.AddWithValue("@Smag_Test", tappeKontrol.SmagsTest == null ? (object)DBNull.Value :tappeKontrol.SmagsTest );
            cmd.Parameters.AddWithValue("@Kvitter_Proeve", tappeKontrol.KviterProve == null ? (object)DBNull.Value : tappeKontrol.KviterProve);
            cmd.Parameters.AddWithValue("@Sukker_Tjek", tappeKontrol.SukkerTjek == null ? (object)DBNull.Value : tappeKontrol.SukkerTjek);
            cmd.Parameters.AddWithValue("@CO2_Kontrol", tappeKontrol.Co2Kontrol == -1 ? (object)DBNull.Value : tappeKontrol.Co2Kontrol);
            cmd.Parameters.AddWithValue("@Signatur", tappeKontrol.Signatur);

            
            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1 ? true : false;

            conn.Close();
            return retValue;
            
        }

        

    }
}