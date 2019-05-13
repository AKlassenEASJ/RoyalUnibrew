using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminRURS.Persistency;
using AdminRURS.ViewModel;
using ModelLibary.Models;

namespace AdminRURS.Handler
{
    public class AnsatHandler
    {

        #region InstanceFields

        private PersistenceAnsat _persistence = new PersistenceAnsat();

        #endregion

        #region Properties

        public AnsatViewModel AnsatViewModel { get; set; }


        #endregion

        #region Constructor

        public AnsatHandler(AnsatViewModel ansatViewModel)
        {
            AnsatViewModel = ansatViewModel;
        }


        #endregion

        #region Methods

        public async void AddAsync()
        {
            AnsatViewModel.ProgressRingIsActive = true;
            await _persistence.PostAsync(AnsatViewModel.NyAnsat);
            AnsatViewModel.ProgressRingIsActive = false;
            ClearNyAnsat();
            
        }

        public async void UpdateAsync()
        {
            AnsatViewModel.ProgressRingIsActive = true;
            await _persistence.PutAsync(AnsatViewModel.NyAnsat.Initial, AnsatViewModel.NyAnsat);
            AnsatViewModel.ProgressRingIsActive = false;
            ClearNyAnsat();
        }


        #endregion

        #region HelpMethods

        private void ClearNyAnsat()
        {
            AnsatViewModel.NyAnsat.Initial = null;
            AnsatViewModel.NyAnsat.Navn = null;
            AnsatViewModel.NyAnsat.Id = 0;
        }

        #endregion

    }
}
