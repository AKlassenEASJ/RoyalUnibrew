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
        private List<ProcessOrdre> _loadedProcessOrdrer;

        public List<ProcessOrdre> LoadedProcessOrdrer
        {
            set => _loadedProcessOrdrer=value;
            get {return _loadedProcessOrdrer;}
        }


        public ProcessOrdreHandler(ProcessOrdreViewModel vM)
        {
            _vM = vM;
        }

        public void Load()
        {
            _loadedProcessOrdrer=Persistency.PersistencyProcessOrdre.GetAll();

            foreach (ProcessOrdre p in LoadedProcessOrdrer)
            {
                _vM.DisplayProcessOrdres.Add(p);
            }

        }


        public void Open()
        {
            foreach (ProcessOrdre p in LoadedProcessOrdrer)
            {
                if (p.ToString()==_vM.SelectedProcessOrdre)
                {
                    Model.SelectedPOSingleton.POSingletonInstans = p;
                    _vM.OpenOrdreDisplay = Model.SelectedPOSingleton.POSingletonInstans;
                }
            }
        }


        public void Upload()
        {
            ProcessOrdre processOrdre=_vM.OpretningProcessOrdre;
            Persistency.PersistencyProcessOrdre.Post(processOrdre);

        }

        public void OpenInternal(ProcessOrdre processOrdre)
        {
            Model.SelectedPOSingleton.POSingletonInstans = processOrdre;
            _vM.OpenOrdreDisplay = Model.SelectedPOSingleton.POSingletonInstans;
        }



    }
}
