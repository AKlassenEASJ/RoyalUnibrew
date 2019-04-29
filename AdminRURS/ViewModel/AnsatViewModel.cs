using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdminRURS.Handler;
using ModelLibary.Models;


namespace AdminRURS.ViewModel
{
    class AnsatViewModel
    {

        #region InstanceFields

        private ICommand _addCommand;

        private Ansat NyAnsat = new Ansat();


        #endregion

        #region Properties

        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }




        #endregion


        #region Constructor

        public AnsatViewModel()
        {
            AnsatHandler ansatHandler = new AnsatHandler(this);

            
        }


        #endregion

        #region Methods

        

        #endregion






    }
}
