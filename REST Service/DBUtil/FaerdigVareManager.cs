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

        private const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Testu;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #endregion

        #region sqlStatements
        private const string Insert = "Insert into FaerdigVare (FaerdigVare_Nr, FaerdigVareNavn, Min, Max, Snit) Values (@FaerdigVare_Nr, @FaerdigVareNavn, @Min, @Max, @Snit)";
        #endregion

        #region Methods
        public bool Post(FaerdigVare faerdigVare)
        {
            bool status = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(Insert, connection);

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
        #endregion

        #region HelpMethods

        private FaerdigVare ReadFaerdigVare(SqlDataReader reader)
        {
            FaerdigVare tempFaerdigVare = new FaerdigVare();

            tempFaerdigVare.FaerdigVare_Nr = reader.GetInt32(0);
            tempFaerdigVare.FaerdigVareNavn = reader.GetString(1);
            tempFaerdigVare.Min = reader.GetDouble(2);
            tempFaerdigVare.Max = reader.GetDouble(3);
            tempFaerdigVare.Snit = reader.GetDouble(4);

            return tempFaerdigVare;
        }
        #endregion
    }
}