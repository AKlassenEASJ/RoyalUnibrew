using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibary.Models
{
    public class ActivePOSingleton
    {

        private static ActivePOSingleton _processOrdreSingleTonInstans = null;
        private ProcessOrdre _processOrdre;

        private ActivePOSingleton()
        { }

        public ProcessOrdre ActiveProcessOrdre
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


        public static ActivePOSingleton GetInstance()
        {
            if (_processOrdreSingleTonInstans == null)
            {
                _processOrdreSingleTonInstans = new ActivePOSingleton();
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
