using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibary.Models;


namespace REST_Service.DBUtil
{
    public class DaaseVaegtManger
    {
        private const string ConnString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LokalRoyalUnibrew;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string INSERT = "INSERT INTO VaegtDaase (Process_Ordre_Nr, Kontrol_Nr, Daase_Nr, Vaegt) VALUES (@PONR, @KNR, @DNR, @Vaegt";

        public bool Post(DaaseVaegt daaseVeVaegt)
        {
            bool retValue = false;

            SqlConnection conn = new SqlConnection(ConnString);

            conn.Open();

            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@PONR", daaseVeVaegt.ProcessOrderNr);
            cmd.Parameters.AddWithValue("@KNR", daaseVeVaegt.KontrolOrderNr);
            cmd.Parameters.AddWithValue("@DNR", daaseVeVaegt.DaaseNr);
            cmd.Parameters.AddWithValue("@Vaegt", daaseVeVaegt.DasseVaegt);

            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1 ? true : false;

            conn.Close();

            return retValue;
        }


       
    }
}