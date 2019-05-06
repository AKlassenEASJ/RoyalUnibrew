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
    public class SelectedPOSingleton : INotifyPropertyChanged
    {

        private static SelectedPOSingleton _processOrdreSingleTonInstans = null;
        private ProcessOrdre _processOrdre;

        private SelectedPOSingleton()
        { }

        private SelectedPOSingleton(ProcessOrdre processOrdre)
        {
            _processOrdre.Dato = processOrdre.Dato;
            _processOrdre.FaerdigVareNr = processOrdre.FaerdigVareNr;
            _processOrdre.ProcessOrdreNr = processOrdre.ProcessOrdreNr;
        }

        public ProcessOrdre ProcessOrdre2
        {
            get
            {
                return _processOrdre;
            }
            set
            {
                _processOrdre = value;
                OnPropertyChanged();
            }
        }
        

        public static SelectedPOSingleton GetInstance()
        {
            if (_processOrdreSingleTonInstans == null)
            {
                _processOrdreSingleTonInstans=new SelectedPOSingleton();
            }

            return _processOrdreSingleTonInstans;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [ModelLibary.Annotations.NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
