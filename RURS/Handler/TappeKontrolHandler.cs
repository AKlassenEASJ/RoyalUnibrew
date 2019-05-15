using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using RURS.Common;
using RURS.Model;
using RURS.Persistency;
using RURS.Validation;
using RURS.ViewModel;

namespace RURS.Handler
{
    /// <summary>
    /// Handler til TappekontrolViewModel, hvor metoder som skal bruge i view ligger
    /// </summary>
    class TappeKontrolHandler
    {
        private TappeKontrolViewModel _viewModel;
        private ValidationTappeKontrol _validation;

        public string ErrorMessage { get; set; }

        public TappeKontrolHandler(TappeKontrolViewModel viewModel)
        {
            _viewModel = viewModel;
            _validation = new ValidationTappeKontrol();
        }

        //private Stopwatch _stopwatch = new Stopwatch();

        public void Add()
        {
            ErrorMessage = null;
            //Indsætter ProcessOrderNr
            _viewModel.SelectedTappeKontrol.ProcessOrderNr = 1;
            //Indsætter tid
            _viewModel.SelectedTappeKontrol.Tidspunkt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            _viewModel.SelectedTappeKontrol.Tidspunkt = _viewModel.SelectedTappeKontrol.Tidspunkt + _viewModel.TimeSpan;

            foreach (FejlTjek f in _viewModel.Validatons.Values)
            {
                if (f.Bedsked != null)
                {
                    addToMessage(f.Bedsked);
                }
            }

            if (ErrorMessage != null)
            {
                MessageDialogHelper.Show(ErrorMessage, "Der mangler oplysninger");
            }
            else
            {
                if (_validation.TjekPrimærNøgle(_viewModel.SelectedTappeKontrol.ProcessOrderNr, _viewModel.SelectedTappeKontrol.Tidspunkt))
                {
                    MessageDialogHelper.Show("Du har allerede lavet en på dette tidspunkt", "Tappe Kontrollen findes allerede");
                }
                else
                {
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

              
            }
            
            
        }
        /// <summary>
        /// Metode til at clear de fleste i tappekontrollen
        /// </summary>
        public void Clear()
        {
            ErrorMessage = null;
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

        #region Validations

        public void TjekDasseNr()
        {
            _viewModel.Validatons["Daasenr"].Bedsked = _validation.TjekNr(_viewModel.SelectedTappeKontrol.DaaseNr);
        }

        public void TjekLaagNr()
        {
            _viewModel.Validatons["laagNr"].Bedsked = _validation.TjekNr(_viewModel.SelectedTappeKontrol.LaagNr);
        }

        public void TjekSignatur()
        {
            _viewModel.Validatons["Signatur"].Bedsked = _validation.Empty(_viewModel.SelectedTappeKontrol.Signatur);
        }

        public void TjekKontrolTemp()
        {
            _viewModel.Validatons["KontrolTemp"].Bedsked =
                _validation.TjekTemperatur(_viewModel.SelectedTappeKontrol.KontrolTemp);
        }

        public void TjekVæskeTemp()
        {
            _viewModel.Validatons["VæskeTemp"].Bedsked =
                _validation.TjekTemperatur(_viewModel.SelectedTappeKontrol.VaeskeTemp);
        }

        #endregion

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


        private void addToMessage(string bedsked)
        {
            ErrorMessage = ErrorMessage + $"\n{bedsked}";
        }



    }
}
