using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RURS.Validation
{
    class ValidationBase
    {
        public string IntToSmall(int tjek)
        {
            if (tjek < 0)
            {
                return "Værdien skal være større";
            }

            return null;
        }

        public string DoubleToSmall(double tjek)
        {
            if (tjek < 0)
            {
                return "Værdien skal være større";
            }

            return null;
        }

        public string Empty(string tjek)
        {
            if (tjek.Length < 1 || tjek == "")
            {
                return "Denne må ikke være tom";
            }

            return null;
        }
    }
}
