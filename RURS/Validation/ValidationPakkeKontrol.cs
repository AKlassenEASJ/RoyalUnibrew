using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RURS.Validation
{
    class ValidationPakkeKontrol : ValidationBase
    {
        public string TjekNr(int tjek)
        {
            string res = IntToSmall(tjek);

            if (res == null)
            {
                string tjekString = tjek.ToString();

                if (tjekString.Length < 6)
                {
                    res = "Nummeret er for lille";
                }
                else if (tjekString.Length < 10)
                {
                    res = "Tallet er forstort";
                }

            }

            return res;
        }

        public string TjekHoldDato(DateTime dato)
        {
            if (dato <= DateTime.Now)
            {
                return "HoldbarhedsDatoen må ikke være i dag";
            }

            return null;
        }

        public string TjekProduDato(DateTime dato)
        {
            if (dato != DateTime.Now)
            {
                return "ProduktionsDatoen skal være i dag";
            }

            return null;
        }

        //public string TjekPrintHold(string tjek)
        //{
        //    string res = null;
        //    if (!tjek.StartsWith("E: "))
        //    {
        //        res = "Koden skal starte med E:";
        //    }


        //    if (res == null)
        //    {
        //        if (tjek.Length > 11)
        //        {
        //            res = "Skriv hel dato";
        //        }
        //        else if (expr)
        //        {
                    
        //        }
               
        //    }
        //}
    }
}
