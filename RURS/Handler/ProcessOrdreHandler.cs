﻿using System;
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

            foreach (ProcessOrdre p in _loadedProcessOrdrer)
            {
                _vM.DisplayProcessOrdres.Add(p);
            }

        }


        public void Open()
        {
            _vM.OpenOrdreDisplay.ProcessOrdre2 = _vM.SelectedProcessOrdre;
        }


        public void Upload()
        {
            ProcessOrdre processOrdre=_vM.OpretningProcessOrdre;
            Persistency.PersistencyProcessOrdre.Post(processOrdre);

        }
        



    }
}