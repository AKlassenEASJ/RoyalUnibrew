using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using RURS.Model;
using RURS.ViewModel;

namespace RURS.Handler
{
    public class ProcessOrdreAddHandler
    {
        private ProcessOrdreAddViewModel _vM;
        
        public ProcessOrdreAddHandler(ProcessOrdreAddViewModel vM)
        {
            _vM = vM;
        }


        public void Upload()
        {
            ProcessOrdre processOrdre = _vM.OpretningProcessOrdre;
            Persistency.PersistencyProcessOrdre.Post(processOrdre);
            InternalOpen();
        }
        

        private void InternalOpen()
        {
            _vM.OpenOrdreDisplay.ActiveProcessOrdre = _vM.OpretningProcessOrdre;
        }
    }
}
