using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;

namespace RURS.ViewModel
{
    class ProcessOrdreViewModel:VMBase
    {
        private ObservableCollection<ProcessOrdre> _displayProcessOrdres;

        private ProcessOrdre _selectedProcessOrdre;
        private ProcessOrdre _opretningProcessOrdre;

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

        public ProcessOrdreViewModel()
        {
            _opretningProcessOrdre = new ProcessOrdre();
            _selectedProcessOrdre = new ProcessOrdre();
            _displayProcessOrdres = new ObservableCollection<ProcessOrdre>();
            SelectedProcessOrdre.Dato = DateTime.Today;


            //WIP input.
            DateTime date1=new DateTime(2019, 1, 1);
            DateTime date2 = new DateTime(2019, 1, 1);
            DateTime date3 = new DateTime(2019, 1, 1);
            ProcessOrdre p1 = new ProcessOrdre(1, 1, date1);
            ProcessOrdre p2 = new ProcessOrdre(2, 1, date2);
            ProcessOrdre p3 = new ProcessOrdre(3, 1, date3);
            DisplayProcessOrdres.Add(p1);
            DisplayProcessOrdres.Add(p2);
            DisplayProcessOrdres.Add(p3);
        }
    }
}