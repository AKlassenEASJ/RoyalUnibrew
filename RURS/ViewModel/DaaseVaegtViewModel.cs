using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RURS.Handler;

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
        public DaaseVaegtViewModel()
        {
            Handler = new DaaseVaegtHandler(this);
        }
    }
}
