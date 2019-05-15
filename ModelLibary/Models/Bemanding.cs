using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibary.Models
{
    public class Bemanding
    {

        #region InstanceFields

        private int _process_Ordre_Nr;
        private DateTime _tidspunkt_Start;
        private DateTime _tidspunkt_Slut;
        private int _antal_Bemanding;
        private string _signatur;
        private int _pauser;

        #endregion

        #region Properties

        public int ProcessOrdre_Nr
        {
            get => _process_Ordre_Nr;
            set => _process_Ordre_Nr = value;
        }

        public DateTime Tidspunkt_Start
        {
            get => _tidspunkt_Start;
            set => _tidspunkt_Start = value;
        }

        public DateTime Tidspunkt_Slut
        {
            get => _tidspunkt_Slut;
            set => _tidspunkt_Slut = value;
        }

        public int Antal_Bemanding
        {
            get => _antal_Bemanding;
            set => _antal_Bemanding = value;
        }

        public string Signatur
        {
            get => _signatur;
            set => _signatur = value;
        }

        public int Pauser
        {
            get => _pauser;
            set => _pauser = value;
        }

        #endregion

        #region Constructor

        public Bemanding()
        {
            
        }

        public Bemanding(int processOrdreNr, DateTime tidspunktStart, DateTime tidspunktSlut, int antalBemanding, string signatur, int pauser)
        {
            _process_Ordre_Nr = processOrdreNr;
            _tidspunkt_Start = tidspunktStart;
            _tidspunkt_Slut = tidspunktSlut;
            _antal_Bemanding = antalBemanding;
            _signatur = signatur;
            _pauser = pauser;
        }

        #endregion

        #region Methods



        #endregion

    }
}
