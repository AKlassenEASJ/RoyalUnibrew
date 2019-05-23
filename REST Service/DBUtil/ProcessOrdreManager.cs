using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibary.Models;

namespace REST_Service.DBUtil
{
    public class ProcessOrdreManager
    {
        //Thomas Local ConnectionString: @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestRoyalUni;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string thomasConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestRoyalUni;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string christianConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = RoyalUniBrew; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string LineConnString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LokalRoyalUnibrew;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string ConnectionString =
            "Data Source=aklassen-zeland2019.database.windows.net;Initial Catalog=RoyalUniBrew;User ID=Line644s;Password=Database123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //private const string ConnectionString = thomasConnectionString;

        //private const string ConnectionString = LineConnString;
        //private const string ConnectionString = christianConnectionString;

        private const string GETAll = "SELECT * FROM ProcessOrdre";
        private const string GETONE = "SELECT * FROM ProcessOrdre WHERE Process_Ordre_Nr = @No ";
        private const string INSERT = "INSERT INTO ProcessOrdre (Process_Ordre_Nr, Faerdigvare_Nr, Dato, Kolonne) VALUES (@Process_Ordre_Nr, @Faerdigvare_Nr, @Dato, @Kolonne)";
        private const string DELETE = "DELETE FROM ProcessOrdre WHERE Process_Ordre_Nr = @No";
        private const string GETDATE = "SELECT * FROM ProcessOrdre WHERE Dato = @Date";

        //GETALL: API/ProcessOrdre
        public IEnumerable<ProcessOrdre> Get()
        {
            List<ProcessOrdre> liste = new List<ProcessOrdre>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(GETAll, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ProcessOrdre processOrdre = ReadProcessOrdre(reader);
                liste.Add(processOrdre);
            }
            connection.Close();
            return liste;
        }

        ////GETONE: api/ProcessOrdre/1
        //public ProcessOrdre Get(int pONr)
        //{
        //    ProcessOrdre processOrdre = null;

        //    SqlConnection connection = new SqlConnection(ConnectionString);
        //    connection.Open();
        //    SqlCommand cmd = new SqlCommand(GETONE, connection);
        //    cmd.Parameters.AddWithValue("@No", pONr);

        //    SqlDataReader reader = cmd.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        processOrdre = ReadProcessOrdre(reader);
        //    }
        //    connection.Close();
        //    return processOrdre;
        //}

        public IEnumerable<ProcessOrdre> Get(DateTime date)
        {
            List<ProcessOrdre> liste = new List<ProcessOrdre>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(GETDATE, connection);
            cmd.Parameters.AddWithValue("@Date", date);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ProcessOrdre processOrdre = ReadProcessOrdre(reader);
                liste.Add(processOrdre);
            }
            connection.Close();
            return liste;
        }


        // POST: api/ProcessOrdre
        public bool Post(ProcessOrdre processOrdre)
        {
            bool retValue;

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(INSERT, connection);
            cmd.Parameters.AddWithValue("@Process_Ordre_Nr", processOrdre.ProcessOrdreNr);
            cmd.Parameters.AddWithValue("@Faerdigvare_Nr", processOrdre.FaerdigVareNr);
            cmd.Parameters.AddWithValue("@Dato", processOrdre.Dato);
            cmd.Parameters.AddWithValue("@Kolonne", processOrdre.Kolonne);


            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1;
            connection.Close();


            return retValue;
        }

        // Delete api/ProcessOrdre/5
        public bool Delete(int processOrdreNr)
        {
            bool sucesss = true;

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(DELETE, connection);
            command.Parameters.AddWithValue("@No", processOrdreNr);

            int rowsAffected = command.ExecuteNonQuery();
            sucesss = rowsAffected == 1;

            return sucesss;
        }


        //Hjælpemetode
        private ProcessOrdre ReadProcessOrdre(SqlDataReader reader)
        {
            ProcessOrdre processOrdre = new ProcessOrdre(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2));
            processOrdre.Kolonne = reader.GetInt32(3);
            return processOrdre;
        }

    }
}