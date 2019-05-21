using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
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

        public async void CreateVaegtKontrol()
        {
            //skal oprettes async
            int processOrdreNr = Model.SelectedPOSingleton.GetInstance().ActiveProcessOrdre.ProcessOrdreNr;
            int maxKontrol = await PersistencyVaegtKontrol.GetMax(processOrdreNr);
            int kontrolNr = ++maxKontrol;
            DateTime datoTid = DateTime.Now;
            VaegtKontrol aVaegtKontrol = new VaegtKontrol(processOrdreNr,kontrolNr,datoTid);
            PersistencyVaegtKontrol pVaegtKontrol = new PersistencyVaegtKontrol();
            bool success = pVaegtKontrol.Post(aVaegtKontrol);
            if (success)
            {
                //feedback på succes.
                MessageDialog messageDialog = new MessageDialog($"Den nye VægtKontrol med nummer:{maxKontrol} blev oprettet", "Succes");
                await messageDialog.ShowAsync();
                
            }
            else
            {
                //feedback på fejl. message dialog
                MessageDialog messageDialog = new MessageDialog("Vægtkontrollen blev ikke oprettet", "Fejl");
                await messageDialog.ShowAsync();

            }
        }
        /*
        //ikke implementeret listview til view

        public List<VaegtKontrol> LoadedVaegtKontroller
        {
            set => _loadedVaegtKontroller = value;
            get { return _loadedVaegtKontroller; }
        }

        
        public void Load()
        {
            _loadedVaegtKontroller = Persistency.PersistencyVaegtKontrol.GetAll();

            foreach (VaegtKontrol i in _loadedVaegtKontroller)
            {
                VaegtKontrolViewModel.DisplayVaegtKontrol.Add(i);
            }

        }


        public void Open()
        {
            _loadedVaegtKontroller.OpenOrdreDisplay.ActiveProcessOrdre = _loadedVaegtKontroller.;
        }
        */
    }
}
