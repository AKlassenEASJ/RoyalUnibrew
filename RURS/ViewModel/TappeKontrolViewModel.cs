using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
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

        private int _minituesLeft;

        public int MiniutesLeft
        {
            get { return _minituesLeft; }
            set
            {
                _minituesLeft = value;
                OnPropertyChanged();
            }
        }

        public List<CheckboxHelper> CheckHelpers { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand ClearCommand { get; set; }


        public TappeKontrolViewModel()
        {
            Handler = new TappeKontrolHandler(this);
            SelectedTappeKontrol = new TappeKontrol();
            CheckHelpers = new List<CheckboxHelper>() { new CheckboxHelper(), new CheckboxHelper(), new CheckboxHelper(), new CheckboxHelper(), new CheckboxHelper()};
            AddCommand = new RelayCommand(Handler.Add);
            ClearCommand = new RelayCommand(Handler.Clear);
            TimeSpan = DateTime.Now.TimeOfDay;
            TimeSpan.FromMinutes(15);
        }

        private TimeSpan _time;

        public TimeSpan TimeSpan
        {
            get { return _time;}
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }
    }
}
