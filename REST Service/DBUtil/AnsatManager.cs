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

        private const string GetOne = "Select * from Ansatte where Initialer = @Initialer";
        private const string Insert = "Insert into Ansatte (Initialer, Navn, ID) Values (@Initialer, @Navn, @ID)";
        private const string DeleteStatement = "Delete from Ansatte where Initialer = @Initialer";
        private const string Update = "Update Ansatte Set Initialer = @Initialer, Navn = @Navn, ID = @ID Where Initialer = @Ini";


        #endregion


        #region Methods

        public Ansat Get(string initialer)
        {
            Ansat tempAnsat = new Ansat();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(GetOne, connection);
            command.Parameters.AddWithValue("@Initialer", initialer);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                tempAnsat = ReadAnsat(reader);
            }

            connection.Close();

            return tempAnsat;

        }


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

        public bool Put(string initialer, Ansat ansatToPut)
        {
            bool status = false;

            SqlConnection connection = new SqlConnection();

            connection.Open();

            SqlCommand command = new SqlCommand(Update, connection);
            command.Parameters.AddWithValue("@Initialer", ansatToPut.Initial);
            command.Parameters.AddWithValue("@Navn", ansatToPut.Navn);
            command.Parameters.AddWithValue("@ID", ansatToPut.Id);
            command.Parameters.AddWithValue("@Ini", initialer);

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

        private Ansat ReadAnsat(SqlDataReader reader)
        {
            Ansat tempAnsat = new Ansat();

            tempAnsat.Initial = reader.GetString(0);
            tempAnsat.Navn = reader.GetString(1);
            tempAnsat.Id = reader.GetInt32(2);

            return tempAnsat;

        }

        #endregion





    }
}