using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Background;
using AdminRURS.Common;
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
            bool status = await _persistence.PostAsync(AnsatViewModel.NyAnsat);
            AnsatViewModel.ProgressRingIsActive = false;

            if (status)
            {
                MessageDialogHelper.Show("Den nye bruger blev oprette", "Succes");
            }
            else
            {
                MessageDialogHelper.Show("Brugeren blev ikke oprettet", "Fejl");
            }


            ClearNyAnsat();
            
        }

        public async void UpdateAsync()
        {
            AnsatViewModel.ProgressRingIsActive = true;
            bool status = await _persistence.PutAsync(AnsatViewModel.NyAnsat.Initial, AnsatViewModel.NyAnsat);
            AnsatViewModel.ProgressRingIsActive = false;

            if (status)
            {
                MessageDialogHelper.Show("Brugeren blev opdateret", "Succes");
            }
            else
            {
                MessageDialogHelper.Show("Brugeren blev ikke opdateret", "Fejl");
            }

            ClearNyAnsat();
        }


        #endregion

        #region HelpMethods

        private void ClearNyAnsat()
        {
            AnsatViewModel.NyAnsat = new Ansat();
        }

        #endregion

    }
}
