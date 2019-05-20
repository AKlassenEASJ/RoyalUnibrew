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

        public ICommand UploadCommand { get; set; }

        

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


        public ProcessOrdreAddViewModel()
        {
            handler = new ProcessOrdreAddHandler(this);
            _openOrdreDisplay = SelectedPOSingleton.GetInstance();

            _opretningProcessOrdre = new ProcessOrdre();
            _opretningProcessOrdre.Dato = DateTime.Today;
            
            UploadCommand = new RelayCommand(handler.Upload);
        }
    }
}
