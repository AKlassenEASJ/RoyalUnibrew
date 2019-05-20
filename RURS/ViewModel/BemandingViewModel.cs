using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLibary.Models;
using RURS.Common;
using RURS.Handler;

namespace RURS.ViewModel
{
    class BemandingViewModel : VMBase
    {
        #region InstanceFields

        private TimeSpan _startTime;
        private TimeSpan _endTime;
        private Bemanding _nyBemanding = new Bemanding();
        private ICommand _addCommand;


        #endregion

        #region Properties

        public TimeSpan StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value; 
                OnPropertyChanged();
            }
        }

        public TimeSpan EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value; 
                OnPropertyChanged();
            }
        }

        public Bemanding Bemanding
        {
            get { return _nyBemanding; }
            set
            {
                _nyBemanding = value; 
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        public BemandingHandler BemandingHandler { get; set; }


        #endregion

        #region Constructor

        public BemandingViewModel()
        {
            BemandingHandler = new BemandingHandler(this);
            _addCommand = new RelayCommand(BemandingHandler.AddAsync);

        }


        #endregion

        #region Methods

        

        #endregion

    }
}
