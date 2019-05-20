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

        private DateTimeOffset _startTime;
        private DateTimeOffset _endTime;
        private Bemanding _nyBemanding;
        private ICommand _addCommand;


        #endregion

        #region Properties

        public DateTimeOffset StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value; 
                OnPropertyChanged();
            }
        }

        public DateTimeOffset EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public Bemanding Bemanding
        {
            get { return _nyBemanding; }
            set { _nyBemanding = value; }
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
