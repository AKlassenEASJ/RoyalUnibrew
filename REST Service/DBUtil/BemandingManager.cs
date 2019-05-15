using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibary.Models;

namespace REST_Service.DBUtil
{
    public class BemandingManager
    {


        #region ConnectionString

        private const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""RURS TestDatabase"";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



        #endregion

        #region SqlStatements

        private const string Insert = "Insert into Bemanding (Process_Order_Nr, Tidspunkt_Start, Tidspunkt_Slut, Antal_Bemanding, Signatur, Pauser) Values (@Process_Order_Nr, @Tidspunkt_Start, @Tidspunkt_Slut, @Antal_Bemanding, @Signatur, @Pauser)";


        #endregion

        #region Methods

        public bool Post(Bemanding bemanding)
        {
            bool status;

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(Insert, connection);
            command.Parameters.AddWithValue("@Process_Order_Nr", bemanding.ProcessOrdre_Nr);
            command.Parameters.AddWithValue("@Tidspunkt_Start", bemanding.Tidspunkt_Start);
            command.Parameters.AddWithValue("@Tidspunkt_Slut", bemanding.Tidspunkt_Slut);
            command.Parameters.AddWithValue("@Antal_Bemanding", bemanding.Antal_Bemanding);
            command.Parameters.AddWithValue("@Signatur", bemanding.Signatur);
            command.Parameters.AddWithValue("@Pauser", bemanding.Pauser);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                status = true;

            }
            else
            {
                status = false;
            }

            connection.Close();

            return status;

        }

        #endregion

        #region HelpMethods



        #endregion


    }
}