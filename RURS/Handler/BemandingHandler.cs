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
            

            //DateTime tempStartDateTime = BemandingViewModel.StartTime.LocalDateTime;
            //tempStartDateTime = tempStartDateTime.AddDays(DateTime.Now.Day);
            //tempStartDateTime = tempStartDateTime.AddMonths(DateTime.Now.Month);
            //tempStartDateTime = tempStartDateTime.AddYears(DateTime.Now.Year);

            //DateTime temp2DateTime = BemandingViewModel.EndTime.LocalDateTime;
            //temp2DateTime = temp2DateTime.AddDays(DateTime.Now.Day).AddMonths(DateTime.Now.Month).AddYears(DateTime.Now.Year);

            DateTime tempStartDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, BemandingViewModel.StartTime.Hours, BemandingViewModel.StartTime.Minutes, 00, DateTimeKind.Local);
            DateTime temp2DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, BemandingViewModel.EndTime.Hours, BemandingViewModel.EndTime.Minutes, 00, DateTimeKind.Local);

            BemandingViewModel.Bemanding.Tidspunkt_Start = tempStartDateTime;
            BemandingViewModel.Bemanding.Tidspunkt_Slut = temp2DateTime;

            BemandingViewModel.Bemanding.ProcessOrdre_Nr = 1;

            await _persistence.PostAsync(BemandingViewModel.Bemanding);
        }
        

        #endregion
    }
}
