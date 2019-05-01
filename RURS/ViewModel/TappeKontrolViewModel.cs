using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Models;

namespace RURS.ViewModel
{
    class TappeKontrolViewModel : VMBase
    {
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

        public TappeKontrolViewModel()
        {
            SelectedTappeKontrol = new TappeKontrol() {Tidspunkt = DateTime.Now};
        }
    }
}
