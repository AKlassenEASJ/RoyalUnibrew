using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using RURS.Persistency;
using RURS.ViewModel;

namespace RURS.Handler
{
    class TappeKontrolHandler
    {
        private TappeKontrolViewModel _viewModel;

        public TappeKontrolHandler(TappeKontrolViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Add()
        {
            _viewModel.SelectedTappeKontrol.ProcessOrderNr = 1;
            
            _viewModel.SelectedTappeKontrol.Tidspunkt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            _viewModel.SelectedTappeKontrol.Tidspunkt = _viewModel.SelectedTappeKontrol.Tidspunkt + _viewModel.TimeSpan;
            if (PersistenceTappeKontrol.Post(_viewModel.SelectedTappeKontrol))
            {
                Clear();
            }

            
        }

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
    }
}
