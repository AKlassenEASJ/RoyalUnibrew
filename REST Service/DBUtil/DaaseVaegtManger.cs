using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_Service.DBUtil
{
    public class DaaseVaegtManger
    {
        private const string ConnString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LokalRoyalUnibrew;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string INSERT = "INSERT INTO VaegtDaase (Process_Ordre_Nr, Kontrol_Nr, Daase_Nr, Vaegt) VALUES (@PONR, @KNR, @DNR, @Vaegt";

        public bool Post()
    }
}