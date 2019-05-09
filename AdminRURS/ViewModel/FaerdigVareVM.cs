using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdminRURS.Annotations;
using AdminRURS.Common;

namespace AdminRURS.ViewModel
{
    public class FaerdigVareVM 
    {

        #region Instancefields

        private ICommand _createCommand;



        #endregion

        #region Properties      

        public ICommand CreateCommand { get; set; }

        #endregion

        #region Constructer

        public FaerdigVareVM()
        {
            CreateCommand = new RelayCommand();
        }

        #endregion

        #region Methods

        
        #endregion







    }
}
 