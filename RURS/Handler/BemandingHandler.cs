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
            

            DateTime tempStartDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, BemandingViewModel.StartTime.Hours, BemandingViewModel.StartTime.Minutes, 00, DateTimeKind.Local);
            DateTime tempEndDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, BemandingViewModel.EndTime.Hours, BemandingViewModel.EndTime.Minutes, 00, DateTimeKind.Local);

            if (BemandingViewModel.EndTime.CompareTo(BemandingViewModel.StartTime) == -1)
            {
                tempStartDateTime = tempStartDateTime.AddDays(1);
            }


            BemandingViewModel.Bemanding.Tidspunkt_Start = tempStartDateTime;
            BemandingViewModel.Bemanding.Tidspunkt_Slut = tempEndDateTime;

            
            

            BemandingViewModel.Bemanding.ProcessOrdre_Nr = 1;

            await _persistence.PostAsync(BemandingViewModel.Bemanding);

            BemandingViewModel.Bemanding = new Bemanding();
            BemandingViewModel.StartTime = new TimeSpan();
            BemandingViewModel.EndTime = new TimeSpan();
        }
        

        #endregion
    }
}
