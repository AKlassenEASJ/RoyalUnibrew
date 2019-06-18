using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibary.Models;

namespace REST_Service.DBUtil
{
    public class FaerdigVareManager
    {

        #region ConnectionString

        //private const string ConnectionString =
        //@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Testu;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string ConnectionString =
            "Data Source=aklassen-zeland2019.database.windows.net;Initial Catalog=RoyalUniBrew;User ID=Line644s;Password=Database123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #endregion

        #region sqlStatements
        private const string GET_ALL = "select * from FaerdigVare";
        private const string GET_ONE = "select * from FaerdigVare where FaerdigVare_Nr = @Nummer";      
        private const string INSERT = "Insert into FaerdigVare (FaerdigVare_Nr, Navn, Minimum, Maximum, Gennemsnit) Values (@FaerdigVare_Nr, @FaerdigVareNavn, @Min, @Max, @Snit)";
        private const string UPDATE = "Update FaerdigVare " + "set FaerdigVare_Nr = @Nummer, Navn = @Navn, Minimum = @Min, Maximum = @Max, Gennemsnit = @Snit" + " where FaerdigVare_Nr = @FVNummer";
        private const string DELETE = "Delete from FaerdigVare where FaerdigVare_Nr = @Nummer";
        #endregion

        #region Methods

        public IEnumerable<FaerdigVare> Get()
        {
            List<FaerdigVare> liste = new List<FaerdigVare>();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GET_ALL, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                FaerdigVare faerdigVare = ReadFaerdigVare(reader);
                liste.Add(faerdigVare);
            }
            conn.Close();
            return liste;
        }

        public FaerdigVare Get(int Nummer)
        {
            FaerdigVare faerdigVare = new FaerdigVare();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@Nummer", Nummer);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                faerdigVare = ReadFaerdigVare(reader);
            }
            conn.Close();
            return faerdigVare;
        }


        public bool Post(FaerdigVare faerdigVare)
        {
            bool status = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(INSERT, connection);

            command.Parameters.AddWithValue("@FaerdigVare_Nr", faerdigVare.FaerdigVare_Nr);
            command.Parameters.AddWithValue("@FaerdigVareNavn", faerdigVare.FaerdigVareNavn);
            command.Parameters.AddWithValue("@Min", faerdigVare.Min);
            command.Parameters.AddWithValue("@Max", faerdigVare.Max);
            command.Parameters.AddWithValue("@Snit", faerdigVare.Snit);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                status = true;
            }

            connection.Close();

            return status;
        }

        public bool Put(int Nummer, FaerdigVare faerdigVare)
        {
            bool retValue = false;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@Nummer", faerdigVare.FaerdigVare_Nr);
            cmd.Parameters.AddWithValue("@FVNummer", Nummer);
            cmd.Parameters.AddWithValue("@Navn", faerdigVare.FaerdigVareNavn);
            cmd.Parameters.AddWithValue("@Min", faerdigVare.Min);
            cmd.Parameters.AddWithValue("@Max", faerdigVare.Max);
            cmd.Parameters.AddWithValue("@Snit", faerdigVare.Snit);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                retValue = true;
            }

            else
            {
                retValue = false;
            }

            return retValue;
        }

        public bool Delete(int Nummer)
        {
            bool retValue = false;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DELETE, conn);
            cmd.Parameters.AddWithValue("@Nummer", Nummer);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                retValue = true;
            }

            else
            {
                retValue = false;
            }

            return retValue;
        }
        #endregion

        #region HelpMethods

        private FaerdigVare ReadFaerdigVare(SqlDataReader reader)
        {
            FaerdigVare tempFaerdigVare = new FaerdigVare();

            tempFaerdigVare.FaerdigVare_Nr = reader.GetInt32(0);
            tempFaerdigVare.FaerdigVareNavn = reader.GetString(1);
            tempFaerdigVare.Min = reader.GetDouble(2);
            tempFaerdigVare.Snit = reader.GetDouble(3);
            tempFaerdigVare.Max = reader.GetDouble(4);

            return tempFaerdigVare;
        }
        #endregion
    }
}