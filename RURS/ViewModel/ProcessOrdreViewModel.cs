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
    public class ProcessOrdreViewModel:VMBase
    {

        private ProcessOrdreHandler handler;

        private ObservableCollection<ProcessOrdre> _displayProcessOrdres;

        private ProcessOrdre _selectedProcessOrdre;
        private ProcessOrdre _opretningProcessOrdre;
        private SelectedPOSingleton _openOrdreDisplay;

        public ICommand UploadCommand { get; set; }
        public ICommand OpenCommand {get; set; }
        public ICommand LoadCommand { get; set; }


        public ProcessOrdre SelectedProcessOrdre
        {
            get => _selectedProcessOrdre;
            set
            {
                _selectedProcessOrdre = value;
                OnPropertyChanged();
            }
        }

        public ProcessOrdre OpretningProcessOrdre
        {
            get => _opretningProcessOrdre;
            set
            {
                _opretningProcessOrdre = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ProcessOrdre> DisplayProcessOrdres
        {
            get => _displayProcessOrdres;
            set
            {
                _displayProcessOrdres=value;
                OnPropertyChanged();
            }
        }

        public SelectedPOSingleton OpenOrdreDisplay
        {
            get { return _openOrdreDisplay;}
            set
            {
                _openOrdreDisplay = value;
                OnPropertyChanged();
            }
        }
        

        public ProcessOrdreViewModel()
        {
            handler = new ProcessOrdreHandler(this);
            _openOrdreDisplay=SelectedPOSingleton.GetInstance();
            
            _opretningProcessOrdre = new ProcessOrdre();
            _displayProcessOrdres = new ObservableCollection<ProcessOrdre>();
            _opretningProcessOrdre.Dato = DateTime.Today;

            LoadCommand=new RelayCommand(handler.Load);
            UploadCommand = new RelayCommand(handler.Upload);
            OpenCommand = new RelayCommand(handler.Open);
            handler.Load();


            //WIP input.
            //DateTime date1=new DateTime(2019, 1, 1);
            //DateTime date2 = new DateTime(2019, 1, 1);
            //DateTime date3 = new DateTime(2019, 1, 1);
            //ProcessOrdre p1 = new ProcessOrdre(1, 1, date1);
            //ProcessOrdre p2 = new ProcessOrdre(2, 1, date2);
            //ProcessOrdre p3 = new ProcessOrdre(3, 1, date3);
            //DisplayProcessOrdres.Add(p1);
            //DisplayProcessOrdres.Add(p2);
            //DisplayProcessOrdres.Add(p3);
        }
    }
}