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
            string valiRes = IntToSmall(tjek);

            if (valiRes == null)
            {
                if (tjek <= 100000)
                {
                    valiRes = "Tallet skal være mindst 6 cifre";
                }
                else if (tjek >= 10000000)
                {
                    valiRes = "tallet er for stort";
                } 
            }

            return valiRes;
        }


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
