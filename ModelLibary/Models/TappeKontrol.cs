using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ModelLibary.Annotations;

namespace ModelLibrary.Models
{
    public class TappeKontrol : INotifyPropertyChanged
    {
        private int _processOrderNr;
        private DateTime _tidspunkt;
        private int _daasenr;
        private int _laagnr;
        private string _helhed;
        private string _kameraTjek;
        private string _ccp;
        private double _vaeskeTemp;
        private double _kontrolTemp;
        private string _tunnelPHTjek;
        private double _vaegtKontrol;
        private int _smagsTestNr;
        private string _smagsTest;
        private string _kviterProve;
        private string _sukkerTjek;
        private double _co2Kontrol;
        private string _signatur;

        public TappeKontrol()
        {
            
        }

        public TappeKontrol(int processOrderNr, DateTime tidspunkt, int daasenr, int laagnr, string helhed, string kameraTjek, string ccp, double vaeskeTemp, double kontrolTemp, string tunnelPhTjek, double vaegtKontrol, int smagsTestNr, string smagsTest, string kviterProve, string sukkerTjek, double co2Kontrol, string signatur)
        {
            ProcessOrderNr = processOrderNr;
            Tidspunkt = tidspunkt;
            Daasenr = daasenr;
            Laagnr = laagnr;
            Helhed = helhed;
            KameraTjek = kameraTjek;
            Ccp = ccp;
            VaeskeTemp = vaeskeTemp;
            KontrolTemp = kontrolTemp;
            TunnelPhTjek = tunnelPhTjek;
            VaegtKontrol = vaegtKontrol;
            SmagsTestNr = smagsTestNr;
            SmagsTest = smagsTest;
            KviterProve = kviterProve;
            SukkerTjek = sukkerTjek;
            Co2Kontrol = co2Kontrol;
            Signatur = signatur;
        }

        public int ProcessOrderNr
        {
            get => _processOrderNr;
            set => _processOrderNr = value;
        }

        public DateTime Tidspunkt
        {
            get => _tidspunkt;
            set
            {
                _tidspunkt = value;
                OnPropertyChanged();
            }
        }

        public int Daasenr
        {
            get => _daasenr;
            set => _daasenr = value;
        }

        public int Laagnr
        {
            get => _laagnr;
            set => _laagnr = value;
        }

        public string Helhed
        {
            get => _helhed;
            set => _helhed = value;
        }

        public string KameraTjek
        {
            get => _kameraTjek;
            set => _kameraTjek = value;
        }

        public string Ccp
        {
            get => _ccp;
            set => _ccp = value;
        }

        public double VaeskeTemp
        {
            get => _vaeskeTemp;
            set => _vaeskeTemp = value;
        }

        public double KontrolTemp
        {
            get => _kontrolTemp;
            set => _kontrolTemp = value;
        }

        public string TunnelPhTjek
        {
            get => _tunnelPHTjek;
            set => _tunnelPHTjek = value;
        }

        public double VaegtKontrol
        {
            get => _vaegtKontrol;
            set => _vaegtKontrol = value;
        }

        public int SmagsTestNr
        {
            get => _smagsTestNr;
            set => _smagsTestNr = value;
        }

        public string SmagsTest
        {
            get => _smagsTest;
            set => _smagsTest = value;
        }

        public string KviterProve
        {
            get => _kviterProve;
            set => _kviterProve = value;
        }

        public string SukkerTjek
        {
            get => _sukkerTjek;
            set => _sukkerTjek = value;
        }

        public double Co2Kontrol
        {
            get => _co2Kontrol;
            set => _co2Kontrol = value;
        }

        public string Signatur
        {
            get => _signatur;
            set => _signatur = value;
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
