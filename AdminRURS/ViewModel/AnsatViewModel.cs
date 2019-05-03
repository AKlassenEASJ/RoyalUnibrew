using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdminRURS.Annotations;
using AdminRURS.Common;
using AdminRURS.Handler;
using ModelLibary.Models;


namespace AdminRURS.ViewModel
{
    public class AnsatViewModel : INotifyPropertyChanged
    {

        #region InstanceFields

        private ICommand _addCommand;

        private Ansat _nyAnsat = new Ansat();

        private bool _progressRingIsActive = false;


        #endregion

        #region Properties

        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        public Ansat NyAnsat
        {
            get { return _nyAnsat; }
            set { _nyAnsat = value; }
        }

        public bool ProgressRingIsActive
        {
            get { return _progressRingIsActive; }
            set
            {
                _progressRingIsActive = value;
                OnPropertyChanged();
            }
        }

        public AnsatHandler AnsatHandler { get; set; }


        #endregion


        #region Constructor

        public AnsatViewModel()
        {
            AnsatHandler = new AnsatHandler(this);
            _addCommand = new RelayCommand(AnsatHandler.Add);
            
        }


        #endregion

        #region Methods

        

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
