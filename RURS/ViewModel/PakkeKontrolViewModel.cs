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

        private DateTimeOffset _holdbarhedsDato;

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

        public DateTimeOffset HoldbarhedsDato
        {
            get { return _holdbarhedsDato; }
            set
            {
                _holdbarhedsDato = value;
                OnPropertyChanged();
            }
        }

        public Dictionary<string, CheckboxHelper> Helpers { get; set; }
        public PakkeKontrolHandler Handler { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public PakkeKontrolViewModel()
        {
            Handler = new PakkeKontrolHandler(this);
            SelectedPakkeKontrol = new PakkeKontrol() {Print1HolDato = "P: ", Print1ProDato = "E: "};
            Helpers = new Dictionary<string, CheckboxHelper>();
            addHeplers();
            Getdate();
            TimeSpan.FromMinutes(15);
            ClearCommand = new RelayCommand(Handler.Clear);
            AddCommand = new RelayCommand(Handler.Add);
        }

        private void addHeplers()
        {
            Helpers.Add("helhed", new CheckboxHelper());
            Helpers.Add("FyldeHøjde", new CheckboxHelper());
            Helpers.Add("SkridLim", new CheckboxHelper());
            Helpers.Add("FremDPaller", new CheckboxHelper());
            Helpers.Add("FremDkarton", new CheckboxHelper());
        }

        public void Getdate()
        {
            TimeSpan = DateTime.Now.TimeOfDay;
            TimeSpan.FromMinutes(15);
            ProduktionsDato = DateTimeOffset.Now;
            HoldbarhedsDato = DateTime.Now.AddYears(1).AddMonths(6).AddDays(1);
        }

    }
}
