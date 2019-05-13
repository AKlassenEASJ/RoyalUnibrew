using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RURS.Model;
using RURS.ViewModel;

namespace RURS.Handler
{
    class PakkeKontrolHandler
    {
        private PakkeKontrolViewModel _viewModel;

        public PakkeKontrolHandler(PakkeKontrolViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Clear()
        {
            foreach (CheckboxHelper checkboxHelper in _viewModel.Helpers.Values)
            {
                checkboxHelper.clear();
            }

            _viewModel.SelectedPakkeKontrol.PuTunnelH = 0;
            _viewModel.SelectedPakkeKontrol.PuTunnelM = 0;
            _viewModel.SelectedPakkeKontrol.PuTunnelV = 0;
            _viewModel.SelectedPakkeKontrol.KontrolPalleNr = 0;
            _viewModel.SelectedPakkeKontrol.KontrolAverylable = null;
            _viewModel.SelectedPakkeKontrol.KontrolStabelMonster = null;
            _viewModel.TimeSpan = DateTime.Now.TimeOfDay;

        }
    }
}
