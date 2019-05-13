using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using ModelLibary.Models;
using RURS.Persistency;
using RURS.ViewModel;

namespace RURS.Handler
{
    class VaegtKontrolHandler
    {
        public VaegtKontrolViewModel VaegtKontrolViewModel { get; set; }
        private List<VaegtKontrol> _loadedVaegtKontroller;

        public VaegtKontrolHandler(VaegtKontrolViewModel vaegtKontrolViewModel)
        {
            VaegtKontrolViewModel = vaegtKontrolViewModel;
        }

        public void CreateVaegtKontrol()
        {
            //skal oprettes async
            int processOrdreNr = Model.SelectedPOSingleton.GetInstance().ActiveProcessOrdre.ProcessOrdreNr;
            int kontrolNr = 4;
            DateTime datoTid = DateTime.Now;
            VaegtKontrol aVaegtKontrol = new VaegtKontrol(processOrdreNr,kontrolNr,datoTid);
            PersistencyVaegtKontrol pVaegtKontrol = new PersistencyVaegtKontrol();
            bool success = pVaegtKontrol.Post(aVaegtKontrol);
            if (success)
            { //feedback på oprettelse
            }
            else
            {
                //feedback på fejl. message dialog
            }
        }


        public List<VaegtKontrol> LoadedVaegtKontroller
        {
            set => _loadedVaegtKontroller = value;
            get { return _loadedVaegtKontroller; }
        }


        public void Load()
        {
            _loadedVaegtKontroller = Persistency.PersistencyProcessOrdre.GetAll();

            foreach (VaegtKontrol i in _loadedVaegtKontroller)
            {
                VaegtKontrolViewModel.DisplayProcessOrdres.Add(p);
            }

        }


        public void Open()
        {
            _vM.OpenOrdreDisplay.ActiveProcessOrdre = _vM.SelectedProcessOrdre;
        }


        public void Upload()
        {
            ProcessOrdre processOrdre = _vM.OpretningProcessOrdre;
            Persistency.PersistencyProcessOrdre.Post(processOrdre);

        }


    }
}
