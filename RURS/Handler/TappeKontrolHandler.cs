using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using RURS.Persistency;
using RURS.ViewModel;

namespace RURS.Handler
{
    /// <summary>
    /// Handler til TappekontrolViewModel, hvor metoder som skal bruge i view ligger
    /// </summary>
    class TappeKontrolHandler
    {
        private TappeKontrolViewModel _viewModel;
        

        public TappeKontrolHandler(TappeKontrolViewModel viewModel)
        {
            _viewModel = viewModel;
            
        }

        //private Stopwatch _stopwatch = new Stopwatch();

        public void Add()
        {
            //Indsætter ProcessOrderNr
            _viewModel.SelectedTappeKontrol.ProcessOrderNr = 1;
            //Indsætter tid
            _viewModel.SelectedTappeKontrol.Tidspunkt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            _viewModel.SelectedTappeKontrol.Tidspunkt = _viewModel.SelectedTappeKontrol.Tidspunkt + _viewModel.TimeSpan;

            //Sætter Vægtkontrol til null
            if (_viewModel.SelectedTappeKontrol.VaegtKontrol == 0)
            {
                _viewModel.SelectedTappeKontrol.VaegtKontrol = -1;
            }

            //Sætter SmagsTestNr til Null
            if (_viewModel.SelectedTappeKontrol.SmagsTestNr == 0)
            {
                _viewModel.SelectedTappeKontrol.SmagsTestNr = -1;
            }
            //Sætter C02 til Null
            if (_viewModel.SelectedTappeKontrol.Co2Kontrol == 0)
            {
                _viewModel.SelectedTappeKontrol.Co2Kontrol = -1;
            }

            if (PersistenceTappeKontrol.Post(_viewModel.SelectedTappeKontrol))
            {
                Clear();
                //_viewModel.MiniutesLeft = 15;
            }
        }
        /// <summary>
        /// Metode til at clear de fleste i tappekontrollen
        /// </summary>
        public void Clear()
        {
            _viewModel.SelectedTappeKontrol.KontrolTemp = 0;
            _viewModel.SelectedTappeKontrol.VaeskeTemp = 0;
            _viewModel.SelectedTappeKontrol.VaegtKontrol = 0;
            _viewModel.SelectedTappeKontrol.SmagsTestNr = 0;
            _viewModel.SelectedTappeKontrol.KviterProve = null;
            _viewModel.SelectedTappeKontrol.Co2Kontrol = 0;
            for (int i = 0; i < _viewModel.CheckHelpers.Count; i++)
            {
                _viewModel.CheckHelpers[i].Index = -1;
            }
        }

        //private void TimeLeft()
        //{
        //    _viewModel.MiniutesLeft = 0;

        //    _stopwatch.Start();
        //    while (_stopwatch.IsRunning)
        //    {
        //        //_stopwatch.
        //        //if ()
        //        //{
                    
        //        //}
        //    }




        //}
    }
}
