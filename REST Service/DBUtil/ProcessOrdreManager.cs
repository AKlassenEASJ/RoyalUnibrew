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
        private const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RURS TestDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string GETAll = "GET * FROM ProcessOrdre";
        private const string GETONE = "GET * FROM ProcessOrdre WHERE Process_Ordre_Nr = @No ";
        private const string INSERT = "INSERT INTO ProcessOrdre VALUES (@Process_Ordre_Nr, @Faerdigvare_Nr, @Dato, @Kolonne)";

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

        //GETONE: api/ProcessOrdre/1
        public ProcessOrdre Get(int pONr)
        {
            ProcessOrdre processOrdre = null;

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(GETONE, connection);
            cmd.Parameters.AddWithValue("@No", pONr);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                processOrdre = ReadProcessOrdre(reader);
            }
            connection.Close();
            return processOrdre;
        }

        // POST: api/Bookings
        public bool Post(ProcessOrdre processOrdre)
        {
            bool retValue;

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(INSERT, connection);
            cmd.Parameters.AddWithValue("@Process_Ordre_Nr", processOrdre.ProcessOrdreNr);
            cmd.Parameters.AddWithValue("@Faerdivare_Nr", processOrdre.FaerdigVareNr);
            cmd.Parameters.AddWithValue("@Dato", processOrdre.Dato);
            cmd.Parameters.AddWithValue("@Kolonne", processOrdre.Kolonne);


            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1;
            connection.Close();


            return retValue;
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