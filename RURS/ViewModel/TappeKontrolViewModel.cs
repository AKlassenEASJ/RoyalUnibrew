using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLibrary.Models;
using RURS.Common;
using RURS.Handler;

namespace RURS.ViewModel
{
    class TappeKontrolViewModel : VMBase
    {
        public TappeKontrolHandler Handler { get; set; }

        private TappeKontrol _selectedTappeKontrol;

        public TappeKontrol SelectedTappeKontrol
        {
            get { return _selectedTappeKontrol; }
            set
            {
                _selectedTappeKontrol = value; 
                OnPropertyChanged();
            }
        }

        public ICommand ClearCommand { get; set; }

        public TappeKontrolViewModel()
        {
            Handler = new TappeKontrolHandler(this);
            SelectedTappeKontrol = new TappeKontrol() {Tidspunkt = DateTime.Now};
            //ClearCommand = new RelayCommand();

        }
    }
}
