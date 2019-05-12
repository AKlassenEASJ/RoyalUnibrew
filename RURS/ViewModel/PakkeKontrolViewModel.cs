using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using RURS.Handler;
using RURS.Model;

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

        public Dictionary<string, CheckboxHelper> Helpers { get; set; }
        public PakkeKontrolHandler Handler { get; set; }

        public PakkeKontrolViewModel()
        {
            Handler = new PakkeKontrolHandler(this);
            SelectedPakkeKontrol = new PakkeKontrol() {ProduktionsDato = DateTime.Now.Date};
            Helpers = new Dictionary<string, CheckboxHelper>();
            addHeplers();
            TimeSpan = DateTime.Now.TimeOfDay;
            TimeSpan.FromMinutes(15);
        }

        private void addHeplers()
        {
            Helpers.Add("helhed", new CheckboxHelper());
            Helpers.Add("FyldeHøjde", new CheckboxHelper());
            Helpers.Add("SkridLim", new CheckboxHelper());
        }

    }
}
