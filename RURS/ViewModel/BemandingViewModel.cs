using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLibary.Models;

namespace RURS.ViewModel
{
    class BemandingViewModel : VMBase
    {
        #region InstanceFields

        private DateTimeOffset _date;
        private Bemanding _bemanding;
        private ICommand _addCommand;


        #endregion

        #region Properties

        public DateTimeOffset Date
        {
            get { return _date; }
            set
            {
                _date = value; 
                OnPropertyChanged();
            }
        }

        public Bemanding Bemanding
        {
            get { return _bemanding; }
            set { _bemanding = value; }
        }




        #endregion

        #region Constructor

        public BemandingViewModel()
        {
            
        }


        #endregion

        #region Methods

        

        #endregion

    }
}
