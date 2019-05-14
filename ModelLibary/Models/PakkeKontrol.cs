using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Annotations;

namespace ModelLibary.Models
{
    /// <summary>
    /// Klasse til Pakke kontrollen
    /// </summary>
    public class PakkeKontrol : INotifyPropertyChanged
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
            get { return _holdbarhedsDato; }
            set
            {
                _holdbarhedsDato = value;
                OnPropertyChanged();
            }
        }

        public DateTime ProduktionsDato
        {
            get
            {
                return _produktionsDato;
            }
            set
            {
                _produktionsDato = value;
                OnPropertyChanged();
            }

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
            get
            {
                return _kontrolStabelMonster;
            }
            set
            {
                _kontrolStabelMonster = value;
                OnPropertyChanged();
            }
        }

        public string KontrolAverylable
        {
            get { return _kontrolAverylable; }
            set
            {
                _kontrolAverylable = value;
                OnPropertyChanged();
            }
        }

        public double PuTunnelV
        {
            get
            {
                return _puTunnelV;
            }
            set
            {
                _puTunnelV = value;
                OnPropertyChanged();
            }
        }

        public double PuTunnelM
        {
            get
            {
                return _puTunnelM;
            }
            set
            {
                _puTunnelM = value;
                OnPropertyChanged();
            }
        }

        public double PuTunnelH
        {
            get
            {
                return _puTunnelH;
            }
            set
            {
                _puTunnelH = value;
                OnPropertyChanged();
            }
        }

        public string HelhedsIndtryk
        {
            get => _helhedsIndtryk;
            set => _helhedsIndtryk = value;
        }

        public int KontrolPalleNr
        {
            get { return _kontrolPalleNr; }
            set
            {
                _kontrolPalleNr = value;
                OnPropertyChanged();
            }
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


        //public int Process_Ordre_Nr { get; set; }


        //public DateTime Tidspunkt { get; set; }


        //public string Paa_Baner_Paller { get; set; }

        //public int Folie_Raavare_Nr { get; set; }

        //public int Karton_Raavare_Nr { get; set; }


        //public DateTime Holdbarheds_Dato { get; set; }


        //public DateTime Produktions_Dato { get; set; }


        //public string Printer1_Produktion_Dato { get; set; }


        //public string Printer1_Holdbarheds_Dato { get; set; }


        //public string Printer2_Produktion_Dato { get; set; }


        //public string Printer2_Holdbarheds_Dato { get; set; }


        //public string FyldeHojde_Kontrol { get; set; }


        //public string Skridlim_Karton { get; set; }


        //public string Kontrol_StabelMonster { get; set; }


        //public string Kontrol_Averylabel { get; set; }

        //public double? Pu_Tunnelpasteur_V { get; set; }

        //public double? Pu_Tunnelpasteur_M { get; set; }

        //public double? Pu_Tunnelpasteur_H { get; set; }


        //public string Helhedsindtryk { get; set; }

        //public int? Kontrol_Palle_Nr { get; set; }


        //public string Fremmede_Daaser_Karton { get; set; }


        //public string Signatur { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
