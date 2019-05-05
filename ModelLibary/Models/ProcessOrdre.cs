using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibary.Models
{
    public class ProcessOrdre
    {
        #region InstanceFields
        private int _processOrdreNr;
        private int _faerdigVareNr;
        private DateTime _dato;
        private int _kolonne;
        #endregion


        #region constructors

        public ProcessOrdre()
        {
            _kolonne = 4;
        }

        public ProcessOrdre(int processOrdre, int faerdigVareNr, DateTime dato)
        {
            _processOrdreNr = processOrdre;
            _faerdigVareNr = faerdigVareNr;
            _dato = dato;
            _kolonne = 4;
        }
        #endregion

        #region Properties

        public int ProcessOrdreNr
        {
            get => _processOrdreNr;
            set => _processOrdreNr = value;
        }
        public int FaerdigVareNr
        {
            get => _faerdigVareNr;
            set => _faerdigVareNr = value;
        }
        public DateTime Dato
        {
            get => _dato;
            set => _dato = value;
        }

        public int Kolonne
        {
            get => _kolonne;
            set => _kolonne = value;
        }
        #endregion


        #region Methods

        public override string ToString()
        {
            return $"PO#: {ProcessOrdreNr}, FV#: {FaerdigVareNr}, Dato: {Dato}, Kolonne: {Kolonne} ";
        }

        #endregion Methods

    }
}
