using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using RURS.Annotations;

namespace RURS.Model
{
    class SelectedPOSingleton
    {

        private static ProcessOrdre _processOrdreSingleTonInstans = null;

        private SelectedPOSingleton(ProcessOrdre processOrdre)
        {
            _processOrdreSingleTonInstans.Dato = processOrdre.Dato;
            _processOrdreSingleTonInstans.FaerdigVareNr = processOrdre.FaerdigVareNr;
            _processOrdreSingleTonInstans.ProcessOrdreNr = processOrdre.ProcessOrdreNr;
        }
        

        public static ProcessOrdre POSingletonInstans
        {
            get
            {
                return _processOrdreSingleTonInstans;
            }
            set
            {
                if (_processOrdreSingleTonInstans == null)
                {
                    new SelectedPOSingleton(value);
                }
                else
                {
                    _processOrdreSingleTonInstans = value;
                }
                
            }
        }

        public void setDato(DateTime dato)
        {
            _processOrdreSingleTonInstans.Dato = dato;
        }
        public void setPONr(int processOrdreNummer)
        {
            _processOrdreSingleTonInstans.ProcessOrdreNr = processOrdreNummer;
        }
        public void setFVNr(int faerdigVareNummer)
        {
            _processOrdreSingleTonInstans.FaerdigVareNr = faerdigVareNummer;
        }
        
    }
}
