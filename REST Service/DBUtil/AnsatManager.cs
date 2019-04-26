using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibary.Models;

namespace REST_Service.DBUtil
{
    public class AnsatManager
    {


        #region ConnectionString

        private const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""RURS TestDatabase"";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #endregion

        #region SqlStatements

        private const string Insert = "Insert into Ansatte (Initialer, Navn, ID) Values (@Initialer, @Navn, @ID)";
        private const string DeleteStatement = "Delete from Ansatte where Initialer = @Initialer";
        

        #endregion

        public bool Post(Ansat ansat)
        {
            bool status = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(Insert, connection);

            command.Parameters.AddWithValue("@Initialer", ansat.Initial);
            command.Parameters.AddWithValue("@Navn", ansat.Navn);
            command.Parameters.AddWithValue("@ID", ansat.Id);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                status = true;
            }

            connection.Close();

            return status;
        }

        public bool Delete(string initialer)
        {
            bool status = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(DeleteStatement, connection);
            command.Parameters.AddWithValue("@Initialer", initialer);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                status = true;
            }

            connection.Close();

            return status;

        }



    }
}