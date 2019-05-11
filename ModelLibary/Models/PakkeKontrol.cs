using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibary.Models
{
    /// <summary>
    /// Klasse til Pakke kontrollen
    /// </summary>
    class PakkeKontrol
    {
        #region InstanceFields
        private int _prosessOrderNr;
        private DateTime _tidspunkt;
        private string _paaBanerPaller;
        private int _folieRaavareNr;
        private int _katonRåvareNr;
        private DateTime _holdbarhedsDato;
        private DateTime _produktionsDato;
        private string _print1ProDato;
        private string _print1HolDato;
        private string _print2ProDato;
        private string _print2HolDato;
        private string _fyldeHojdeKontrol;
        private string _skridlimKarton;
        private string _kontrolStabelMonster;
        private string _kontrolAverylable;
        private double _puTunnelV;
        private double _puTunnelM;
        private double _puTunnelH;
        private string _helhedsIndtryk;
        private int _kontrolPalleNr;
        private string _fremmedDaaserKarton;
        private string _signatur;

        #endregion

        #region Propperties

        public int ProsessOrderNr
        {
            get => _prosessOrderNr;
            set => _prosessOrderNr = value;
        }

        public DateTime Tidspunkt
        {
            get => _tidspunkt;
            set => _tidspunkt = value;
        }

        public string PaaBanerPaller
        {
            get => _paaBanerPaller;
            set => _paaBanerPaller = value;
        }

        public int FolieRaavareNr
        {
            get => _folieRaavareNr;
            set => _folieRaavareNr = value;
        }

        public int KatonRåvareNr
        {
            get => _katonRåvareNr;
            set => _katonRåvareNr = value;
        }

        public DateTime HoldbarhedsDato
        {
            get => _holdbarhedsDato;
            set => _holdbarhedsDato = value;
        }

        public DateTime ProduktionsDato
        {
            get => _produktionsDato;
            set => _produktionsDato = value;
        }

        public string Print1ProDato
        {
            get => _print1ProDato;
            set => _print1ProDato = value;
        }

        public string Print1HolDato
        {
            get => _print1HolDato;
            set => _print1HolDato = value;
        }

        public string Print2ProDato
        {
            get => _print2ProDato;
            set => _print2ProDato = value;
        }

        public string Print2HolDato
        {
            get => _print2HolDato;
            set => _print2HolDato = value;
        }

        public string FyldeHojdeKontrol
        {
            get => _fyldeHojdeKontrol;
            set => _fyldeHojdeKontrol = value;
        }

        public string SkridlimKarton
        {
            get => _skridlimKarton;
            set => _skridlimKarton = value;
        }

        public string KontrolStabelMonster
        {
            get => _kontrolStabelMonster;
            set => _kontrolStabelMonster = value;
        }

        public string KontrolAverylable
        {
            get => _kontrolAverylable;
            set => _kontrolAverylable = value;
        }

        public double PuTunnelV
        {
            get => _puTunnelV;
            set => _puTunnelV = value;
        }

        public double PuTunnelM
        {
            get => _puTunnelM;
            set => _puTunnelM = value;
        }

        public double PuTunnelH
        {
            get => _puTunnelH;
            set => _puTunnelH = value;
        }

        public string HelhedsIndtryk
        {
            get => _helhedsIndtryk;
            set => _helhedsIndtryk = value;
        }

        public int KontrolPalleNr
        {
            get => _kontrolPalleNr;
            set => _kontrolPalleNr = value;
        }

        public string FremmedDaaserKarton
        {
            get => _fremmedDaaserKarton;
            set => _fremmedDaaserKarton = value;
        }

        public string Signatur
        {
            get => _signatur;
            set => _signatur = value;
        }


        #endregion

        #region Constructors

        public PakkeKontrol()
        {
        }

        public PakkeKontrol(int prosessOrderNr, DateTime tidspunkt, string paaBanerPaller, int folieRaavareNr, int katonRåvareNr, DateTime holdbarhedsDato, DateTime produktionsDato, string print1ProDato, string print1HolDato, string print2ProDato, string print2HolDato, string fyldeHojdeKontrol, string skridlimKarton, string kontrolStabelMonster, string kontrolAverylable, double puTunnelV, double puTunnelM, double puTunnelH, string helhedsIndtryk, int kontrolPalleNr, string fremmedDaaserKarton, string signatur)
        {
            ProsessOrderNr = prosessOrderNr;
            Tidspunkt = tidspunkt;
            PaaBanerPaller = paaBanerPaller;
            FolieRaavareNr = folieRaavareNr;
            KatonRåvareNr = katonRåvareNr;
            HoldbarhedsDato = holdbarhedsDato;
            ProduktionsDato = produktionsDato;
            Print1ProDato = print1ProDato;
            Print1HolDato = print1HolDato;
            Print2ProDato = print2ProDato;
            Print2HolDato = print2HolDato;
            FyldeHojdeKontrol = fyldeHojdeKontrol;
            SkridlimKarton = skridlimKarton;
            KontrolStabelMonster = kontrolStabelMonster;
            KontrolAverylable = kontrolAverylable;
            PuTunnelV = puTunnelV;
            PuTunnelM = puTunnelM;
            PuTunnelH = puTunnelH;
            HelhedsIndtryk = helhedsIndtryk;
            KontrolPalleNr = kontrolPalleNr;
            FremmedDaaserKarton = fremmedDaaserKarton;
            Signatur = signatur;
        }

        #endregion

    }
}
