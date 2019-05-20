using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RURS.Handler;
using RURS.Model;

namespace RURS.ViewModel
{
    class DaaseVaegtViewModel : VMBase
    {
        private double _selectedVaegt;

        public double SelectedVaegt
        {
            get { return _selectedVaegt;}
            set
            {
                _selectedVaegt = value;
                OnPropertyChanged();
            }
        }

        public DaaseVaegtHandler Handler { get; set; }
        public ObservableCollection<Record> Maximum { get; set; }
        public ObservableCollection<Record> Snit { get; set; }
        public ObservableCollection<Record> Minimum { get; set; }
        public ObservableCollection<Record> Expted { get; set; }
        public ObservableCollection<Record> Vaegts { get; set; }
        public ICommand AddCommand { get; set; }

        public DaaseVaegtViewModel()
        {
            Handler = new DaaseVaegtHandler(this);
            Handler.GetValues();
            Expted = new ObservableCollection<Record>();
            Vaegts = new ObservableCollection<Record>();
        }
    }
}
