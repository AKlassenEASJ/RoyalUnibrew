using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using RURS.ViewModel;

namespace RURS.Handler
{
    public class ProcessOrdreHandler
    {
        private ProcessOrdreViewModel _vM;

        public ProcessOrdreHandler(ProcessOrdreViewModel vM)
        {
            _vM = vM;
        }

        public void Load()
        {
            List<ProcessOrdre> LoadedProcessOrdrer;
            LoadedProcessOrdrer=Persistency.PersistencyProcessOrdre.GetAll();

            foreach (ProcessOrdre p in LoadedProcessOrdrer)
            {
                _vM.DisplayProcessOrdres.Add(p);
            }

        }


        public void Open()
        {
            OpenInternal(_vM.SelectedProcessOrdre);
        }


        public void Upload()
        {
            ProcessOrdre processOrdre=_vM.OpretningProcessOrdre;

            if (Persistency.PersistencyProcessOrdre.Post(processOrdre))
            {
                OpenInternal(_vM.OpretningProcessOrdre);
            }

        }

        public void OpenInternal(ProcessOrdre processOrdre)
        {
            Model.SelectedPOSingleton.POSingletonInstans = processOrdre;
            _vM.OpenOrdreDisplay = Model.SelectedPOSingleton.POSingletonInstans;
        }



    }
}
