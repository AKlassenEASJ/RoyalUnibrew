using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using RURS.Model;
using RURS.Persistency;
using RURS.ViewModel;

namespace RURS.Handler
{
    class DaaseVaegtHandler
    {
        private DaaseVaegtViewModel _viewModel;

        public DaaseVaegtHandler(DaaseVaegtViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void add()
        {
            DaaseVaegt daase = new DaaseVaegt
            {
                ProcessOrderNr = 1,
                KontrolOrderNr = _viewModel.NewSelectedVaegtKontrol.KontrolNr,
                DaaseNr = _viewModel.SelectedNr,
                DasseVaegt = _viewModel.SelectedVaegt
            };
            if (PersistenceDaaseVaegt.Post(daase))
            {
               _viewModel.Vaegts.Add(new Record(daase.DaaseNr, daase.DasseVaegt));
                _viewModel.SelectedVaegt = 0;
                ClearImage();
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

        #region Gets

        public async void GetVægtKontrol()
        {
            _viewModel.IsLoading = true;
            _viewModel.DisplayVaegtKontrols = new ObservableCollection<VaegtKontrol>();
            List<VaegtKontrol> vaegtkontrols = await PersistenceDaaseVaegt.GET_VeagtsKontrol(1);
            foreach (VaegtKontrol kontrol in vaegtkontrols)
            {
                _viewModel.DisplayVaegtKontrols.Add(kontrol);
            }
            _viewModel.SelectedIndex = _viewModel.DisplayVaegtKontrols.Count - 1;
            _viewModel.IsLoading = false;
        }

        public async void GetDasser()
        {
            _viewModel.IsLoading = true;
            //_viewModel.DaaseVaegts = new ObservableCollection<DaaseVaegt>();

            List<DaaseVaegt> daases = await PersistenceDaaseVaegt.GET_ALL(1, _viewModel.NewSelectedVaegtKontrol.KontrolNr);
            _viewModel.Vaegts.Clear();
            foreach (DaaseVaegt daase in daases)
            {
                //_viewModel.DaaseVaegts.Add(daase);
                _viewModel.Vaegts.Add(new Record(daase.DaaseNr, daase.DasseVaegt));
            }

            _viewModel.SelectedNr = _viewModel.Vaegts.Count + 1;
            _viewModel.IsLoading = false;
        }

        public async void GetMaxAndMin()
        {
            FaerdigVare FV  = await PersistenceFaerdigVare.GetOne(SelectedPOSingleton.GetInstance().ActiveProcessOrdre.FaerdigVareNr);
            _viewModel.MaxVaegt = FV.Max;
            _viewModel.MinVaegt = FV.Min;
            _viewModel.SnitVaegt = FV.Snit;
            //GetMin(FV.Min);
            //GetSnit(FV.Snit);
            //GetMax(FV.Max);

        }

        #endregion

        #region GetValues

        //public async void GetValues()
        //{
        //    await GetVægtKontrol();
        //    await GetMaxAndMin();
        //    //GetDiagram();
        //}

        //private void addValues(ObservableCollection<Record> list, double tal)
        //{
        //    list = new ObservableCollection<Record>();
        //    list.Add(new Record(1, tal));
        //    list.Add(new Record(24, tal));
        //}

        public void GetDiagram()
        {
            GetMax();
            GetMin();
            GetSnit();
        }

        public void GetMax()
        {
            _viewModel.Maximum = new ObservableCollection<Record>();
            _viewModel.Maximum.Add(new Record(1, _viewModel.MaxVaegt));
            _viewModel.Maximum.Add(new Record(24, _viewModel.MaxVaegt));
        }

        private void GetMin()
        {
            _viewModel.Minimum = new ObservableCollection<Record>();
            _viewModel.Minimum.Add(new Record(1, _viewModel.MinVaegt));
            _viewModel.Minimum.Add(new Record(24, _viewModel.MinVaegt));
        }

        private void GetSnit()
        {
            _viewModel.Snit = new ObservableCollection<Record>();
            _viewModel.Snit.Add(new Record(1, _viewModel.SnitVaegt));
            _viewModel.Snit.Add(new Record(24, _viewModel.SnitVaegt));
        }

        #endregion

    }
}
