using System;
using System.Collections.Generic;
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
        public VaegtKontrolHandler VaegtKontrolHandler
        {
            get;
            set;
        }
        
        private VaegtKontrol _selectedVaegtKontrol;
        
        public VaegtKontrolViewModel()
        {
            VaegtKontrolHandler = new VaegtKontrolHandler(this);
            OpretNyVaegtKontrolCommand = new RelayCommand(VaegtKontrolHandler.CreateVaegtKontrol);
        }




        public ICommand OpretNyVaegtKontrolCommand
        {
            get;
            set;
        }

        /*
        #region Bindings
        public int nyProcessOrdreNr
        {
            get;
            set;
        }

        public int nyKontrolNr
        {
            get;
            set;
        }

        public DateTime nyDatoTid
        {
            get;
            set;
        }
        #endregion
        */

        private VaegtKontrol _nyVaegtKontrol;

        public VaegtKontrol NyVaegtKontrol
        {
            get { return _nyVaegtKontrol; }
            set { _nyVaegtKontrol = value; }

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
