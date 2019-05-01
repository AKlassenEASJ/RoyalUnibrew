using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
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

        public void Clear()
        {
            for (int i = 0; i < _viewModel.CheckHelpers.Count; i++)
            {
                _viewModel.CheckHelpers[i] = false;
            }
        }

        public void HelhedOK()
        {
            _viewModel.CheckboxHelhedOK = true;
            _viewModel.CheckboxHelhedIkkeOK = false;
        }

        public void HelhedIkkeOk()
        {
            _viewModel.CheckboxHelhedIkkeOK = true;
            _viewModel.CheckboxHelhedOK = false;
        }
    }
}
