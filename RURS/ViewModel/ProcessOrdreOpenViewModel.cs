using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class ProcessOrdreOpenViewModel: VMBase
    {
        private ProcessOrdreOpenHandler handler;

        private ObservableCollection<ProcessOrdre> _displayProcessOrdres;

        private ProcessOrdre _selectedProcessOrdre;
        private SelectedPOSingleton _openOrdreDisplay;


        public ICommand OpenCommand { get; set; }


        public ProcessOrdre SelectedProcessOrdre
        {
            get => _selectedProcessOrdre;
            set
            {
                _selectedProcessOrdre = value;
                OnPropertyChanged();
            }
        }
        
        public ObservableCollection<ProcessOrdre> DisplayProcessOrdres
        {
            get => _displayProcessOrdres;
            set
            {
                _displayProcessOrdres = value;
                OnPropertyChanged();
            }
        }

        public SelectedPOSingleton OpenOrdreDisplay
        {
            get { return _openOrdreDisplay; }
            set
            {
                _openOrdreDisplay = value;
                OnPropertyChanged();
            }
        }


        public ProcessOrdreOpenViewModel()
        {
            handler = new ProcessOrdreOpenHandler(this);
            _openOrdreDisplay = SelectedPOSingleton.GetInstance();

            _displayProcessOrdres = new ObservableCollection<ProcessOrdre>();
            
            OpenCommand = new RelayCommand(handler.Open);
            handler.Load();


        }
    }
}
