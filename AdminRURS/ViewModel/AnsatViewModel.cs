using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdminRURS.Common;
using AdminRURS.Handler;
using ModelLibary.Models;


namespace AdminRURS.ViewModel
{
    public class AnsatViewModel
    {

        #region InstanceFields

        private ICommand _addCommand;

        private Ansat _nyAnsat = new Ansat();


        #endregion

        #region Properties

        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        public Ansat NyAnsat
        {
            get { return _nyAnsat; }
            set { _nyAnsat = value; }
        }

        public AnsatHandler AnsatHandler { get; set; }


        #endregion


        #region Constructor

        public AnsatViewModel()
        {
            AnsatHandler = new AnsatHandler(this);
            _addCommand = new RelayCommand(AnsatHandler.Add);
            
        }


        #endregion

        #region Methods

        

        #endregion






    }
}
