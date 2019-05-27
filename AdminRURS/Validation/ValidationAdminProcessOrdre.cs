using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using AdminRURS.Common;

namespace AdminRURS.Validation
{
    public class ValidationAdminProcessOrdre: ValidationBase
    {

        public ValidationAdminProcessOrdre()
        {
        }

        public string TjekListe(List<ProcessOrdre> liste)
        {

            
            string valiRes = "";

            if(liste.Count==0)
            {
                valiRes = "Der er ingen ordrer for den valgte dato.";
            }
            return valiRes;

        }
    }
}
