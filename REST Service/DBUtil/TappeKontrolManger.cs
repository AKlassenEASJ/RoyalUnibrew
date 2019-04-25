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
            TappeKontrol tappeKontrol = new TappeKontrol();
            {

            }
            ;

            return tappeKontrol;
        }


    }
}