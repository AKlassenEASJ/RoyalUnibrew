using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using RURS.Persistency;

namespace RURS.Model
{
    class UdviddetVaegtKontrol : INotyfiClass
    {
        private int _antal;
        private double _snit;

        public int Antal
        {
            get { return _antal;}
            set
            {
                _antal = value;
                OnPropertyChanged();
            }
        }

        public double Snit
        {
            get { return _snit;}
            set
            {
                _snit = value;
                OnPropertyChanged();
            }
        }

        public VaegtKontrol VaegtKontrol { get; set; }

        public UdviddetVaegtKontrol(VaegtKontrol vaegtKontrol)
        {
            VaegtKontrol = vaegtKontrol;
            Update();
        }

        public async void Update()
        {
            List<DaaseVaegt> daaser = await PersistenceDaaseVaegt.GET_ALL(VaegtKontrol.ProcessOrdreNr, VaegtKontrol.KontrolNr);
            Antal = daaser.Count;
            
            
            if (Antal > 0)
            {
                double sum = 0;
                foreach (DaaseVaegt vaegt in daaser)
                {
                    sum = sum + vaegt.DasseVaegt;
                }
                Snit = sum / Antal;
            }
            
        }
    }
}
