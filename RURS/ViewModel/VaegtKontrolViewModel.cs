using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLibary.Models;
using RURS.Common;
using RURS.Handler;

namespace RURS.ViewModel
{
    class VaegtKontrolViewModel : VMBase
    {





        private ObservableCollection<VaegtKontrol> _displayVaegtKontrols;
        public ObservableCollection<VaegtKontrol> DisplayVaegtKontrols
        {
            get => _displayVaegtKontrols;
            set => _displayVaegtKontrols = value;
        }

        //private VaegtKontrol _nyVaegtKontrol;
        private VaegtKontrol _selectedVaegtKontrol;
       


        public VaegtKontrolViewModel()
        {
            VaegtKontrolHandler = new VaegtKontrolHandler(this);
            OpretNyVaegtKontrolCommand = new RelayCommand(VaegtKontrolHandler.CreateVaegtKontrol);
            _displayVaegtKontrols = new ObservableCollection<VaegtKontrol>(Persistency.PersistencyVaegtKontrol.GetAll().Result);
        }


        public VaegtKontrolHandler VaegtKontrolHandler
        {
            get;
            set;
        }
        
        public ICommand OpretNyVaegtKontrolCommand
        {
            get;
            set;
        }
        
        #region Operatorer
        public VaegtKontrol SelectedVaegtKontrol
        {
            get { return _selectedVaegtKontrol; }
            set
            {
                _selectedVaegtKontrol = value;
                OnPropertyChanged();
            }
        }
        #endregion


    }
}
