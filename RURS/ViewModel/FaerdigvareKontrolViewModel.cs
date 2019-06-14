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

namespace RURS.ViewModel
{
    class FaerdigvareKontrolViewModel : VMBase
    {


        private FaerdigvareKontrol _nyFaerdigvareKontrol;

        public FaerdigvareKontrol NyFaerdigvareKontrol
        {
            get { return _nyFaerdigvareKontrol; }
            set
            {
                _nyFaerdigvareKontrol = value;
                OnPropertyChanged();
            }
        }

        
       public FaerdigvareKontrolViewModel()
        {
            _nyFaerdigvareKontrol = new FaerdigvareKontrol();
            FaerdigvareKontrolHandler = new FaerdigvareKontrolHandler(this);
            FaerdigvareKontrolHandler.LoadFKontrol();
            //LoadFKCommand = new RelayCommand(FaerdigvareKontrolHandler.LoadFKontrol);
        }



        public FaerdigvareKontrolHandler FaerdigvareKontrolHandler
        {
            get;
            set;
        }

        public ICommand LoadFKCommand
        {
            get;
            set;
        }
    }
}
