using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RURS.Validation
{
    class ValidationBemanding : ValidationBase
    {

        public string BemandingTooSmall(int tjek)
        {
            if (tjek < 1)
            {
                return "Antal medarbejdere kan ikke være 0";
            }

            return null;
        }

    }
}
