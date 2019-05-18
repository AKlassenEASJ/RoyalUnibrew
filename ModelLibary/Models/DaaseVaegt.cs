using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibary.Models
{
    class DaaseVaegt
    {
        private int _processOrderNr;
        private int _kontrolOrderNr;
        private int _daaseNr;
        private double _dasseVaegt;

        public DaaseVaegt()
        {
            
        }

        public DaaseVaegt(int processOrderNr, int kontrolOrderNr, int daaseNr, double dasseVaegt)
        {
            ProcessOrderNr = processOrderNr;
            KontrolOrderNr = kontrolOrderNr;
            DaaseNr = daaseNr;
            DasseVaegt = dasseVaegt;
        }

        public int ProcessOrderNr
        {
            get => _processOrderNr;
            set => _processOrderNr = value;
        }

        public int KontrolOrderNr
        {
            get => _kontrolOrderNr;
            set => _kontrolOrderNr = value;
        }

        public int DaaseNr
        {
            get => _daaseNr;
            set => _daaseNr = value;
        }

        public double DasseVaegt
        {
            get => _dasseVaegt;
            set => _dasseVaegt = value;
        }
    }
}
