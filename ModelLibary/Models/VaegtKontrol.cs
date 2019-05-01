using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibary.Models
{
    public class VaegtKontrol
    {

        #region Instances
        private int _processOrdreNr;
        private int _kontrolNr;
        private DateTime _datoTid;
        #endregion

        #region Constructors
        //Default Constructor
        public VaegtKontrol()
        {
        }
        //Constructor
        public VaegtKontrol(int processOrdreNr, int kontrolNr, DateTime datoTid)
        {
            ProcessOrdreNr = processOrdreNr;
            KontrolNr = kontrolNr;
            DatoTid = datoTid;
        }
        #endregion
        
        #region Properties
        public int ProcessOrdreNr
        {
            get { return _processOrdreNr; }
            set { _processOrdreNr = value; }
        }

        public int KontrolNr
        {
            get { return _kontrolNr; }
            set { _kontrolNr = value; }
        }

        public DateTime DatoTid
        {
            get { return _datoTid; }
            set { _datoTid = value; }
        }
        #endregion

        #region ToString

        public override string ToString()
        {
            return $"{nameof(ProcessOrdreNr)}: {ProcessOrdreNr}, {nameof(KontrolNr)}: {KontrolNr}, {nameof(DatoTid)}: {DatoTid}";
        }
       
        #endregion
    }
}
