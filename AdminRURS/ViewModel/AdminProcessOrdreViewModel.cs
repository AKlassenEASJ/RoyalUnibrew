using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLibary.Models;
using AdminRURS.Common;
using AdminRURS.Handler;
using System.ComponentModel;
using AdminRURS.Annotations;
using System.Runtime.CompilerServices;

namespace AdminRURS.ViewModel
{
    public class AdminProcessOrdreViewModel: INotifyPropertyChanged
    {

        private ObservableCollection<ProcessOrdre> _displayAllProcessOrdrer;
        private ObservableCollection<ProcessOrdre> _displayOrdrerByDate;
        private ProcessOrdre _selectedProcessOrdre;
        private DateTime _datePicked;
        private AdminProcessOrdreHandler _handler;
        private string _header;

        public ICommand LoadByDateCommand { get; set; }
        public ICommand LoadAllCommand { get; set; }
        public ICommand TjekListeCommand { get; set; }

        public ObservableCollection<ProcessOrdre> DisplayProcessOrdrer
        {
            get => _displayAllProcessOrdrer;
            set
            {
                _displayAllProcessOrdrer = value;
                OnPropertyChanged();
            }
        }
        public ProcessOrdre SelectedProcessOrdre
        {
            get => _selectedProcessOrdre;
            set
            {
                _selectedProcessOrdre = value;
                OnPropertyChanged();
            }
        }

        public string Header
        {
            get => _header;
            set
            {
                _header = value;
                OnPropertyChanged();
            }
        }

        public DateTimeOffset DatePicked
        {
            get => _datePicked;
            set
            {
                _datePicked = value.DateTime;
                _handler.LoadByDate();
                OnPropertyChanged();

            }
        }


        public AdminProcessOrdreViewModel()
        {
            _handler = new AdminProcessOrdreHandler(this);
            _displayAllProcessOrdrer = new ObservableCollection<ProcessOrdre>();
            _displayOrdrerByDate = new ObservableCollection<ProcessOrdre>();
            _datePicked = DateTime.Today;

            LoadByDateCommand = new RelayCommand(_handler.LoadByDate);
            LoadAllCommand = new RelayCommand(_handler.LoadAll);
            _handler.LoadAll();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
