using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibary.Models
{
    public class FaerdigVare
    {
        #region InstanceFields
        private int _faerdigvare_Nr;
        #endregion


        #region Properties
        public int FaerdigVare_Nr
        {
            get => _faerdigvare_Nr;
            set => _faerdigvare_Nr = value;
        }
        #endregion

        #region Constructor

        public FaerdigVare()
        {

        }

        public FaerdigVare(int faerdigvareNr)
        {
            _faerdigvare_Nr = FaerdigVare_Nr;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{nameof(FaerdigVare_Nr)}: {FaerdigVare_Nr}";
        }

        #endregion
    }
}
