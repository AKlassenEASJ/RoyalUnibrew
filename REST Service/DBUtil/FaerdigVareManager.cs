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
        private const string Insert = "Insert into FaerdigVare (FaerdigVare_Nr) Values (@FaerdigVare_Nr)";
        #endregion

        #region Methods
        public bool Post(FaerdigVare faerdigVare)
        {
            bool status = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(Insert, connection);

            command.Parameters.AddWithValue("@FaerdigVare_Nr", faerdigVare.FaerdigVare_Nr);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                status = true;
            }

            connection.Close();

            return status;
        }


        #endregion
    }
}