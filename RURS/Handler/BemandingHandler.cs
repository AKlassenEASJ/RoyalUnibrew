using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using RURS.Persistency;
using RURS.ViewModel;

namespace RURS.Handler
{
    class BemandingHandler
    {
        #region InstanceFields

        private PersistenceBemanding<Bemanding> _persistence = new PersistenceBemanding<Bemanding>();

        #endregion

        #region Properties

        public BemandingViewModel BemandingViewModel { get; set; }

        #endregion

        #region Contructor

        public BemandingHandler(BemandingViewModel viewModel)
        {
            BemandingViewModel = viewModel;
        }


        #endregion

        #region Methods

        public async void AddAsync()
        {
            DateTime tempStartDateTime = BemandingViewModel.StartTime.LocalDateTime;
            tempStartDateTime.AddDays(DateTime.Now.Day);
            tempStartDateTime.AddMonths(DateTime.Now.Month);
            tempStartDateTime.AddYears(DateTime.Now.Year);

            DateTime temp2DateTime = BemandingViewModel.EndTime.LocalDateTime;
            temp2DateTime.AddDays(DateTime.Now.Day).AddMonths(DateTime.Now.Month).AddYears(DateTime.Now.Year);

            BemandingViewModel.Bemanding.Tidspunkt_Start = tempStartDateTime;
            BemandingViewModel.Bemanding.Tidspunkt_Slut = temp2DateTime;


            await _persistence.PostAsync(BemandingViewModel.Bemanding);
        }
        

        #endregion
    }
}
