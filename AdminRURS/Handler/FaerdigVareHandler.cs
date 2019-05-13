using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminRURS.ViewModel;
using ModelLibary.Models;
using RURS.Persistency;

namespace AdminRURS.Handler
{
    public class FaerdigVareHandler
    {
        #region InstanceFields

        private FaerdigVareVM _viewModel;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public FaerdigVareHandler(FaerdigVareVM vm)
        {
            _viewModel = vm;
        }

        #endregion

        #region Methods

        public void Create()
        {
           

            if (PersistenceFaerdigVare.Post(_viewModel.SelectedFaerdigVare))
            {
                _viewModel.SelectedFaerdigVare = new FaerdigVare();
            }
        }

        #endregion
    }
}
