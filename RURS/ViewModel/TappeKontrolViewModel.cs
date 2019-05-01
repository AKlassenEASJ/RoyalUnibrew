using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLibrary.Models;
using RURS.Common;
using RURS.Handler;
using RURS.Model;

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

        public List<bool> CheckHelpers { get; set; }

        public ICommand ClearCommand { get; set; }
        public ICommand helhedokCommand { get; set; }
        public ICommand helhedikkeCommand { get; set; }

        public TappeKontrolViewModel()
        {
            Handler = new TappeKontrolHandler(this);
            SelectedTappeKontrol = new TappeKontrol() {Tidspunkt = DateTime.Now};
            CheckHelpers = new List<bool>() { CheckboxHelhedOK, CheckboxHelhedIkkeOK };
            ClearCommand = new RelayCommand(Handler.Clear);
            helhedokCommand = new RelayCommand(Handler.HelhedOK);

        }

        private bool _checkboxHelhedOK = true;
        private bool _checkboxHelhedIkkeOK = false;

        public bool CheckboxHelhedOK
        {
            get { return _checkboxHelhedOK;}
            set { _checkboxHelhedOK = value;
                OnPropertyChanged(); }
        }
        public bool CheckboxHelhedIkkeOK
        {
            get { return _checkboxHelhedIkkeOK; }
            set
            {
                _checkboxHelhedIkkeOK = value;
                OnPropertyChanged();
            }
        }
    }
}
