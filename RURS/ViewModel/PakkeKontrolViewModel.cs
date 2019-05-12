using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;

namespace RURS.ViewModel
{
    class PakkeKontrolViewModel : VMBase
    {
        private PakkeKontrol _selectedPakkeKontrol;

        private TimeSpan _timeSpan;

        public PakkeKontrol SelectedPakkeKontrol
        {
            get { return _selectedPakkeKontrol; }
            set
            {
                _selectedPakkeKontrol = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan TimeSpan
        {
            get { return _timeSpan; }
            set
            {
                _timeSpan = value;
                OnPropertyChanged();
            }
        }



    }
}
