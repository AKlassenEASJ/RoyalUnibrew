using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminRURS.Persistency;
using AdminRURS.ViewModel;

namespace AdminRURS.Handler
{
    public class AnsatHandler
    {

        #region InstanceFields

        private PersistenceAnsat persistence = new PersistenceAnsat();

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

        public async void Add()
        {
            AnsatViewModel.ProgressRingIsActive = true;
            await persistence.Post(AnsatViewModel.NyAnsat);
            AnsatViewModel.ProgressRingIsActive = false;
        }
        

        #endregion

    }
}
