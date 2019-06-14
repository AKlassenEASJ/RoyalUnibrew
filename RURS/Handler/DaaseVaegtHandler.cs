using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using RURS.Common;
using RURS.Model;
using RURS.Persistency;
using RURS.ViewModel;

namespace RURS.Handler
{
    class DaaseVaegtHandler
    {
        private DaaseVaegtViewModel _viewModel;
        private int x1;
        private double y1;
        private int x2;
        private double y2;

        public DaaseVaegtHandler(DaaseVaegtViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void add()
        {

            if (_viewModel.SelectedVaegt >= 100)
            {
                DaaseVaegt daase = new DaaseVaegt
                {
                    ProcessOrderNr = _viewModel.NewSelectedVaegtKontrol.VaegtKontrol.ProcessOrdreNr,
                    KontrolOrderNr = _viewModel.NewSelectedVaegtKontrol.VaegtKontrol.KontrolNr,
                    DaaseNr = _viewModel.SelectedNr,
                    DasseVaegt = _viewModel.SelectedVaegt
                };
                if (PersistenceDaaseVaegt.Post(daase))
                {
                    _viewModel.Vaegts.Add(new Record(daase.DaaseNr, daase.DasseVaegt));
                    _viewModel.SelectedVaegt = 0;
                    _viewModel.SelectedNr = _viewModel.SelectedNr + 1;
                    ClearImage();
                    _viewModel.NewSelectedVaegtKontrol.Update();
                    GetEstement();
                }
            }
            else
            {
                MessageDialogHelper.Show("Vægten skal være over 100 g", "Ugyldig værdi");
            }


        }

        public void Tjek()
        {
            if (_viewModel.SelectedVaegt > 100)
            {
                if (_viewModel.SelectedVaegt > _viewModel.MaxVaegt || _viewModel.SelectedVaegt < _viewModel.MinVaegt)
                {
                    _viewModel.Image = "/Assets/NOTOK.png";
                }
                else
                {
                    _viewModel.Image = "/Assets/OK.png";
                }
            }
            else
            {
                ClearImage();
            }
        }

        public void ClearImage()
        {
            _viewModel.Image = null;
        }

        public void TilføjVægtKontrol()
        {
            _viewModel.VaegtKontrolHandler.CreateVaegtKontrol();
            GetVægtKontrol();
        }

        #region Gets

        public async void GetVægtKontrol()
        {
            _viewModel.IsLoading = true;
            //_viewModel.DisplayVaegtKontrols = new ObservableCollection<VaegtKontrol>();
            _viewModel.VaegtKontrols = new ObservableCollection<UdviddetVaegtKontrol>();
            List<VaegtKontrol> vaegtkontrols = await PersistenceDaaseVaegt.GET_VeagtsKontrol(SelectedPOSingleton.GetInstance().ActiveProcessOrdre.ProcessOrdreNr);
            foreach (VaegtKontrol kontrol in vaegtkontrols)
            {
                //_viewModel.DisplayVaegtKontrols.Add(kontrol);
                _viewModel.VaegtKontrols.Add(new UdviddetVaegtKontrol(kontrol));
            }
            //_viewModel.SelectedIndex = _viewModel.DisplayVaegtKontrols.Count - 1;
            _viewModel.SelectedIndex = _viewModel.VaegtKontrols.Count - 1;
            _viewModel.IsLoading = false;
        }

        public async void GetDasser()
        {
            _viewModel.IsLoading = true;
            //_viewModel.DaaseVaegts = new ObservableCollection<DaaseVaegt>();

            List<DaaseVaegt> daases = await PersistenceDaaseVaegt.GET_ALL(_viewModel.NewSelectedVaegtKontrol.VaegtKontrol.ProcessOrdreNr, _viewModel.NewSelectedVaegtKontrol.VaegtKontrol.KontrolNr);
            _viewModel.Vaegts.Clear();
            foreach (DaaseVaegt daase in daases)
            {
                //_viewModel.DaaseVaegts.Add(daase);
                _viewModel.Vaegts.Add(new Record(daase.DaaseNr, daase.DasseVaegt));
            }

            _viewModel.SelectedNr = _viewModel.Vaegts.Count + 1;
            GetEstement();
            _viewModel.IsLoading = false;
        }

        public async void GetMaxAndMin()
        {
            FaerdigVare FV  = await PersistenceFaerdigVare.GetOne(SelectedPOSingleton.GetInstance().ActiveProcessOrdre.FaerdigVareNr);
            _viewModel.MaxVaegt = FV.Max;
            _viewModel.MinVaegt = FV.Min;
            _viewModel.SnitVaegt = FV.Snit;
            GetDiagram();

        }

        #endregion

        #region GetValues

        public void GetDiagram()
        {
            bool help = true;
            while (help)
            {
                if (_viewModel.SnitVaegt > 0)
                {
                    GetMax();
                    GetMin();
                    GetSnit();
                    help = false;
                }
            }

           
        }

        private void GetMax()
        {
            _viewModel.Maximum.Clear();
            _viewModel.Maximum.Add(new Record(1, _viewModel.MaxVaegt));
            _viewModel.Maximum.Add(new Record(24, _viewModel.MaxVaegt));
        }

        private void GetMin()
        {
            _viewModel.Minimum.Clear();
            _viewModel.Minimum.Add(new Record(1, _viewModel.MinVaegt));
            _viewModel.Minimum.Add(new Record(24, _viewModel.MinVaegt));
        }

        private void GetSnit()
        {
            _viewModel.Snit.Clear();
            _viewModel.Snit.Add(new Record(1, _viewModel.SnitVaegt));
            _viewModel.Snit.Add(new Record(24, _viewModel.SnitVaegt));
        }

        #endregion


        #region Estemering

        private void getKoordinater()
        {
            x1 = _viewModel.Vaegts[_viewModel.Vaegts.Count - 1].Name;
            y1 = _viewModel.Vaegts[_viewModel.Vaegts.Count - 1].Amount;
            x2 = _viewModel.Vaegts[_viewModel.Vaegts.Count - 2].Name;
            y2 = _viewModel.Vaegts[_viewModel.Vaegts.Count - 2].Amount;
        }

        private double GetHældningstallet()
        {

            double t = y2 - y1;
            int n = x2 - x1;

            return t / n;
        }

        private double getB()
        {
            return y1 - (GetHældningstallet() * x1);
        }

        public void GetEstement()
        {
            _viewModel.Expted.Clear();

            if (_viewModel.Vaegts.Count >= 2)
            {
                getKoordinater();

                _viewModel.Expted.Add(_viewModel.Vaegts.Last());

                double a = GetHældningstallet();
                double B = getB();

                double y = (a * _viewModel.Vaegts.Count) + B;

                for (int i = _viewModel.Vaegts.Count + 1; i <= 24; i++)
                {
                    if (y > _viewModel.MinVaegt || y < _viewModel.MaxVaegt)
                    {
                        y = (a * i) + B;

                        _viewModel.Expted.Add(new Record(i, y));
                    }
                }
            }
        }

        #endregion
    }
}
