using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibary.Models
{
    class FaerdigvareKontrol
    {

        #region Instances
        private int _processOrdreNr;
        private int _faerdigvareNr;
        private string _faerdigvareNavn;
        private int _laagNr;
        private int _daaseNr;
        private int _multipackNr;
        private int _kartonNr;
        private int _palleNr;
        #endregion

        #region Constructors
        //Default Constructor
        public FaerdigvareKontrol()
        {
        }
        //Constructor
        public FaerdigvareKontrol(int processOrdreNr, int faerdigvareNr, string faerdigvareNavn, int laagNr, int daaseNr, int multipackNr, int kartonNr, int palleNr)
        {
            ProcessOrdreNr = processOrdreNr;
            FaerdigvareNr = faerdigvareNr;
            FaerdigvareNavn = faerdigvareNavn;
            LaagNr = laagNr;
            DaaseNr = daaseNr;
            MultipackNr = multipackNr;
            KartonNr = kartonNr;
            PalleNr = palleNr;
        }
        #endregion

        #region Properties
        public int ProcessOrdreNr
        {
            get { return _processOrdreNr; }
            set { _processOrdreNr = value; }
        }

        public int FaerdigvareNr
        {
            get { return _faerdigvareNr; }
            set { _faerdigvareNr = value; }
        }

        public string FaerdigvareNavn
        {
            get { return _faerdigvareNavn; }
            set { _faerdigvareNavn = value; }
        }

        public int LaagNr
        {
            get { return _laagNr; }
            set { _laagNr = value; }
        }

        public int DaaseNr
        {
            get { return _daaseNr; }
            set { _daaseNr = value; }
        }

        public int MultipackNr
        {
            get { return _multipackNr; }
            set { _multipackNr = value; }
        }

        public int KartonNr
        {
            get { return _kartonNr; }
            set { _kartonNr = value; }
        }

        public int PalleNr
        {
            get { return _palleNr; }
            set { _palleNr = value; }
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return $"{nameof(ProcessOrdreNr)}: {ProcessOrdreNr}, {nameof(FaerdigvareNr)}: {FaerdigvareNr}, {nameof(FaerdigvareNavn)}: {FaerdigvareNavn}, {nameof(LaagNr)}: {LaagNr}, {nameof(DaaseNr)}: {DaaseNr}, {nameof(MultipackNr)}: {MultipackNr}, {nameof(KartonNr)}: {KartonNr}, {nameof(PalleNr)}: {PalleNr},";
        }

        #endregion
    }
}
