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
    class ProcessOrdreOpenHandler
    {
        private ProcessOrdreOpenViewModel _vM;
        private List<ProcessOrdre> _loadedProcessOrdrer;
        private ValidationProcessOrdre validater;


        public List<ProcessOrdre> LoadedProcessOrdrer
        {
            set => _loadedProcessOrdrer = value;
            get { return _loadedProcessOrdrer; }
        }


        public ProcessOrdreOpenHandler(ProcessOrdreOpenViewModel vM)
        {
            _vM = vM;
            validater = new ValidationProcessOrdre();
        }

        public async void Load()
        {
            InternalClear();
            _loadedProcessOrdrer = await Persistency.PersistencyProcessOrdre.GetAll();

            foreach (ProcessOrdre p in _loadedProcessOrdrer)
            {
                _vM.DisplayProcessOrdres.Add(p);
            }

        }


        public void Open()
        {
            _vM.OpenOrdreDisplay.ActiveProcessOrdre = _vM.SelectedProcessOrdre;
        }
        
        private void InternalClear()
        {
            _vM.DisplayProcessOrdres.Clear();
        }
    }
}
