using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;

namespace RURS.ViewModel
{
    class ProcessOrdreViewModel:VMBase
    {
        private ProcessOrdre _selectedProcessOrdre;

        public ProcessOrdre SelectedProcessOrdre
        {
            get => _selectedProcessOrdre;
            set
            {
                _selectedProcessOrdre = value;
                OnPropertyChanged();
            }
        }

        public ProcessOrdreViewModel()
        {

        }
    }
}