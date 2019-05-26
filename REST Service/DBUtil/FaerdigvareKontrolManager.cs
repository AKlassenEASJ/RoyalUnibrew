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
    public class FaerdigvareKontrolManager
    {


        #region connectionstring
        private const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = RoyalUniBrew; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        #endregion


        #region SQL statements
        private const String GETALL = "SELECT * FROM hentFaerdigvareKontrol";
        private const String GETONE = "SELECT * FROM hentFaerdigvareKontrol WHERE Process_Ordre_Nr = @POID";
        private const String GETFAERDIGVAREKONTROL = "SELECT * FROM hentFaerdigvareKontrol WHERE Process_Ordre_Nr = @POID";
        #endregion


        #region Metoder

        
        //GETALL: api/FaerdigvareKontrolManager

        public IEnumerable<FaerdigvareKontrol> Get()
        {
            List<FaerdigvareKontrol> liste = new List<FaerdigvareKontrol>();

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GETALL, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                FaerdigvareKontrol faerdigvareKontrol = ReadFaerdigvareKontrol(reader);
                liste.Add(faerdigvareKontrol);
            }
            conn.Close();
            return liste;
        }
    

        // GET: api/FaerdigvareKontrolManager/5
        public FaerdigvareKontrol Get(int idNr)
        {
            FaerdigvareKontrol faerdigvareKontrol = null;

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(GETONE, connection);
            cmd.Parameters.AddWithValue("@POID", idNr);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                faerdigvareKontrol = ReadFaerdigvareKontrol(reader);
            }
            connection.Close();
            return faerdigvareKontrol;
        }

        
        // Get all data from view
        public FaerdigvareKontrol GetFaerdigvareKontrol(int idNr)
        {

            FaerdigvareKontrol faerdigvareKontrol = new FaerdigvareKontrol();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(GETFAERDIGVAREKONTROL, connection);
            cmd.Parameters.AddWithValue("@POID", idNr);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                faerdigvareKontrol = ReadFaerdigvareKontrol(reader);
            }

            connection.Close();
            return faerdigvareKontrol;
        }
        
        #endregion


        #region Hjælpemetoder
        private FaerdigvareKontrol ReadFaerdigvareKontrol(SqlDataReader reader)
        {
            FaerdigvareKontrol tempFaerdigvareKontrol = new FaerdigvareKontrol();


            tempFaerdigvareKontrol.ProcessOrdreNr = reader.GetInt32(0);
            tempFaerdigvareKontrol.FaerdigvareNr = reader.GetInt32(1);
            tempFaerdigvareKontrol.FaerdigvareNavn = reader.GetString(2);
            tempFaerdigvareKontrol.LaagNr = reader.GetInt32(3);
            tempFaerdigvareKontrol.DaaseNr = reader.GetInt32(4);
            tempFaerdigvareKontrol.MultipackNr = reader.GetInt32(5);
            tempFaerdigvareKontrol.KartonNr = reader.GetInt32(6);
            tempFaerdigvareKontrol.PalleNr = reader.GetInt32(7);
            
            return tempFaerdigvareKontrol;

        }
        #endregion


        // SQL kode til oprettelse af database view for at Getmax kan fungerer:
        /*
            create view hentFaerdigvareKontrol as 
	    select distinct 
		    PO.Process_Ordre_Nr as ProcessOrdreNr, 
		    PO.Faerdigvare_Nr as FaerdigvareNr, 
		    FV.Navn as FaerdigvareNavn,
		    TK.Laag_Nr as LaagNr, 
		    TK.Daase_Nr as DaaseNr, 
		    PK.Folie_Raavare_Nr as MultipackNr, 
		    PK.Karton_Raavare_Nr as KartonNr, 
		    PK.Kontrol_Palle_Nr as PalleNr

	    from ProcessOrdre PO
		    inner join TappeKontrol TK
			    on PO.Process_Ordre_Nr = TK.Process_Ordre_Nr
		    inner join PakkeKontrol PK
			    on PO.Process_Ordre_Nr = PK.Process_Ordre_Nr
		    inner join Faerdigvare FV 
			    on PO.Faerdigvare_Nr = FV.Faerdigvare_Nr

	
	    where PK.Kontrol_Palle_Nr is not null
	
	    group by Process_Ordre_Nr
        */

    }
}