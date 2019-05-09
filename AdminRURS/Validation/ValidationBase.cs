using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminRURS.Validation
{
    public class ValidationBase
    {

        #region Methods

        public string NotEmpty(string validationString)
        {

            if (validationString == null || validationString == "")
            {
                return "Dette felt må ikke være tomt";
            }

            return null;


        }

        public string NumberMustBeOverZeroInt(int validationInt)
        {
            if (validationInt < 1)
            {
                return "Tal skal være større end 0";
            }

            return null;
        }

        public string NumberMustBeOverZeroDouble(double validationDouble)
        {
            if (validationDouble < 1)
            {
                return "Tal skal være større end 0";
            }

            return null;
        }




        #endregion



    }
}
