using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RURS.Annotations;
using ModelLibary.Models;

namespace RURS.Model
{
    public class SlectedProcessOrdreSingleton: INotifyPropertyChanged
    {

        private static ProcessOrdre _processOrdreSingleTonInstans=null;

        private SlectedProcessOrdreSingleton()
        {}


        public static ProcessOrdre ProcessOrdreSingleTonInstans
        {
            get
            {
                if (_processOrdreSingleTonInstans == null)
                {
                    _processOrdreSingleTonInstans=new ProcessOrdre();
                }
                return _processOrdreSingleTonInstans;
            }
        }

        public void setDato(DateTime dato)
        {
            _processOrdreSingleTonInstans.Dato=dato;
        }
        public void setPONr(int processOrdreNummer)
        {
            _processOrdreSingleTonInstans.ProcessOrdreNr = processOrdreNummer;
        }
        public void setFVNr(int faerdigVareNummer)
        {
            _processOrdreSingleTonInstans.FaerdigVareNr = faerdigVareNummer;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
