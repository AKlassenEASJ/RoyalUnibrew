using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using RURS.Annotations;

namespace RURS.ViewModel
{
    public class VMBase: INotifyPropertyChanged
    {
        #region InstanceFields
        protected ProcessOrdre _processOrdre;
        private bool _isLoading;
        #endregion

        #region Constructors
        protected VMBase()
        {
        }

        protected VMBase(int processOrdre, int faerdigVareNr, DateTime dato)
        {
            _processOrdre=new ProcessOrdre(processOrdre, faerdigVareNr, dato);
        }
        #endregion

        #region Properties
        public ProcessOrdre ProcessOrdre
        {
            get => _processOrdre;
            set => _processOrdre = value;
        }

        public bool IsLoading
        {
            get { return _isLoading;}
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }
        
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
