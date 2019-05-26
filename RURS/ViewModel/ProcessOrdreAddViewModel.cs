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
    public class ProcessOrdreAddViewModel : VMBase
    {


        private ProcessOrdreAddHandler handler;
        
        
        private ProcessOrdre _opretningProcessOrdre;
        private SelectedPOSingleton _openOrdreDisplay;
        private string _valMessagePONr;
        private string _valMessageDate;

        public ICommand UploadCommand { get; set; }
        public ICommand TjekPONrCommand { get; set; }
        public ICommand TjekDateCommand { get; set; }
        

        public ProcessOrdre OpretningProcessOrdre
        {
            get => _opretningProcessOrdre;
            set
            {
                _opretningProcessOrdre = value;
                OnPropertyChanged();
            }
        }
        public DateTimeOffset OpretningsProcessOrdreDate
        {
            get => OpretningProcessOrdre.Dato;
            set
            {
                OpretningProcessOrdre.Dato = value.DateTime;
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

        public string ValMessagePONr
        {
            get { return _valMessagePONr; }
            set
            {
                _valMessagePONr = value;
                OnPropertyChanged();
            }
        }

        public string ValMessageDate
        {
            get {   return _valMessageDate; }
            set
            {
                _valMessageDate = value;
                OnPropertyChanged();
            }
        }



        public ProcessOrdreAddViewModel()
        {
            handler = new ProcessOrdreAddHandler(this);
            _openOrdreDisplay = SelectedPOSingleton.GetInstance();


            _opretningProcessOrdre = new ProcessOrdre
            {
                Dato = DateTime.Today
            };
            handler.Load();
            
            UploadCommand = new RelayCommand(handler.Upload);
            TjekPONrCommand = new RelayCommand(handler.TjekPONr);
            TjekDateCommand = new RelayCommand(handler.TjekDate);
        }
    }
}
