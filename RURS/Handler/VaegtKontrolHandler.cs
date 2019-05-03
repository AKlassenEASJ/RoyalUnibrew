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

        public VaegtKontrolHandler(VaegtKontrolViewModel vaegtKontrolViewModel)
        {
            VaegtKontrolViewModel = vaegtKontrolViewModel;
        }

        public void CreateVaegtKontrol()
        {
            //skal oprettes async
            int processOrdreNr = VaegtKontrolViewModel.ProcessOrdre.ProcessOrdreNr;
            int kontrolNr = VaegtKontrolViewModel.NyVaegtKontrol.KontrolNr;
            DateTime datoTid = DateTime.Now;
            VaegtKontrol aVaegtKontrol = new VaegtKontrol(processOrdreNr,kontrolNr,datoTid);



        }



    }
}
