using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLibary.Models;
using RURS.Common;
using RURS.Handler;
using RURS.Model;

namespace RURS.ViewModel
{
    class PakkeKontrolViewModel : VMBase
    {
        private PakkeKontrol _selectedPakkeKontrol;

        private TimeSpan _timeSpan;

        private DateTimeOffset _produktionsDato;

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

        public DateTimeOffset ProduktionsDato
        {
            get { return _produktionsDato; }
            set
            {
                _produktionsDato = value;
                OnPropertyChanged();
            }
        }

        public Dictionary<string, CheckboxHelper> Helpers { get; set; }
        public PakkeKontrolHandler Handler { get; set; }
        public ICommand ClearCommand { get; set; }

        public PakkeKontrolViewModel()
        {
            Handler = new PakkeKontrolHandler(this);
            SelectedPakkeKontrol = new PakkeKontrol();
            Helpers = new Dictionary<string, CheckboxHelper>();
            addHeplers();
            TimeSpan = DateTime.Now.TimeOfDay;
            TimeSpan.FromMinutes(15);
            ProduktionsDato = DateTimeOffset.Now;
            ClearCommand = new RelayCommand(Handler.Clear);
        }

        private void addHeplers()
        {
            Helpers.Add("helhed", new CheckboxHelper());
            Helpers.Add("FyldeHøjde", new CheckboxHelper());
            Helpers.Add("SkridLim", new CheckboxHelper());
            Helpers.Add("FremDPaller", new CheckboxHelper());
            Helpers.Add("FremDkarton", new CheckboxHelper());
        }

    }
}
