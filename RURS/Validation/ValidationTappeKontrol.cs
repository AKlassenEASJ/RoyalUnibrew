using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using RURS.Model;
using RURS.Persistency;

namespace RURS.Validation
{
    class ValidationTappeKontrol : ValidationBase
    {

        public string TjekNr(int tjek)
        {
            string test = tjek.ToString();
            string valiRes = Empty(test);

                if (valiRes == null)
                {

                    if (test.Length < 6)
                    {
                        valiRes = "Tallet skal være mindst 6 cifre";
                    }
                    else if (test.Length > 8)
                    {
                        valiRes = "tallet er for stort";
                    }
                }
            return valiRes;
        }

        //public string TjekForBogstaver(string tjek)
        //{

        //    foreach (char c in tjek)
        //    {
        //        if (!char.IsDigit(c))
        //        {
        //            return "Der må kun være tal";
        //        }
        //    }

        //    return null;
        //}

        public string TjekTemperatur(double tjek)
        {
            string valiRes = DoubleToSmall(tjek);

            if (valiRes == null)
            {
                if (tjek > 95)
                {
                    valiRes = "Flygt det brænder!!";
                }
            }

            return valiRes;
        }

        public bool TjekPrimærNøgle(int PONR, DateTime Tid)
        {
            return PersistenceTappeKontrol.GET_ONE(PONR, Tid);

        }
    }
}
