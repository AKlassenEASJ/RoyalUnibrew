using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibary.Models
{
    class ProcessOrdre
    {
        private int _processOrdreNr;
        private int _faerdigVareNr;
        private DateTime _dato;
        private int _kolonne;

        ProcessOrdre(int processOrdre, int faerdigVareNr, DateTime dato)
        {
            _processOrdreNr = processOrdre;
            _faerdigVareNr = faerdigVareNr;
            _dato = dato;
            _kolonne = 4;
        }

    }
}
