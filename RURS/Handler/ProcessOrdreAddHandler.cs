using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using RURS.Model;
using RURS.ViewModel;
using RURS.Validation;

namespace RURS.Handler
{
    public class ProcessOrdreAddHandler
    {
        private ProcessOrdreAddViewModel _vM;
        private ValidationProcessOrdre validater;

        public ProcessOrdreAddHandler(ProcessOrdreAddViewModel vM)
        {
            _vM = vM;
            validater = new ValidationProcessOrdre();
        }


        public void Upload()
        {
            ProcessOrdre processOrdre = _vM.OpretningProcessOrdre;
            Persistency.PersistencyProcessOrdre.Post(processOrdre);
            InternalOpen();
        }
        

        private void InternalOpen()
        {
            //_vM.OpenOrdreDisplay.ActiveProcessOrdre = _vM.OpretningProcessOrdre;
            SelectedPOSingleton.GetInstance().ActiveProcessOrdre = _vM.OpretningProcessOrdre;

        }
    }
}
