using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLibary.Models;
using RURS.Common;

namespace RURS.ViewModel
{
    class VaegtKontrolViewModel : VMBase
    {
        
        private VaegtKontrol _selectedVaegtKontrol;



        public VaegtKontrolViewModel()
        {
            //OpretNyVaegtKontrolCommand = new RelayCommand(OpretVaegtKontrol);
        }



        public ICommand OpretNyVaegtKontrolCommand
        {
            get;
            set;
        }


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





        #region Operatorer
        public VaegtKontrol OpretVaegtKontrol
        {
            get;
            set;
        }
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
