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
        private string _faerdigvareNavn;
        private double _min;
        private double _max;
        private double _snit;
        #endregion


        #region Properties
        public int FaerdigVare_Nr
        {
            get => _faerdigvare_Nr;
            set => _faerdigvare_Nr = value;
        }
        public string FaerdigVareNavn
        {
            get => _faerdigvareNavn;
            set => _faerdigvareNavn = value;
        }
        public double Min
        {
            get => _min;
            set => _min = value;
        }
        public double Max
        {
            get => _max;
            set => _max = value;
        }
        public double Snit
        {
            get => _snit;
            set => _snit = value;
        }
        #endregion

        #region Constructor

        public FaerdigVare()
        {

        }

        public FaerdigVare(int faerdigvareNr, string faerdigvareNavn, double Min, double Max, double Snit)
        {
            _faerdigvare_Nr = FaerdigVare_Nr;
            _faerdigvareNavn = FaerdigVareNavn;
            _min = Min;
            _max = Max;
            _snit = Snit;
        }

        #endregion

        #region Methods

        //Måske toostring

        #endregion
    }
}
