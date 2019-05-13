using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RURS.Model;
using RURS.Persistency;
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

        public void Add()
        {
            _viewModel.SelectedPakkeKontrol.ProsessOrderNr = 1;
            _viewModel.SelectedPakkeKontrol.Tidspunkt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            _viewModel.SelectedPakkeKontrol.Tidspunkt = _viewModel.SelectedPakkeKontrol.Tidspunkt + _viewModel.TimeSpan;

            _viewModel.SelectedPakkeKontrol.ProduktionsDato = new DateTime(_viewModel.ProduktionsDato.Year, _viewModel.ProduktionsDato.Month, _viewModel.ProduktionsDato.Day);
            _viewModel.SelectedPakkeKontrol.HoldbarhedsDato = new DateTime(_viewModel.HoldbarhedsDato.Year, _viewModel.HoldbarhedsDato.Month, _viewModel.HoldbarhedsDato.Day);

            if (PersistencePakkeKontrol.Post(_viewModel.SelectedPakkeKontrol))
            {
                Clear();
            }

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
            _viewModel.Getdate();

        }
    }
}
