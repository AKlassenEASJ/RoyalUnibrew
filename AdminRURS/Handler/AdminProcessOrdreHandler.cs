using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using AdminRURS.ViewModel;
namespace AdminRURS.Handler
{
    public class AdminProcessOrdreHandler
    {
        private AdminProcessOrdreViewModel _vM;
        private List<ProcessOrdre> _loadedProcessOrdrer;



        public AdminProcessOrdreHandler(AdminProcessOrdreViewModel vM)
        {
            _vM =vM;
        }


        public void LoadAll()
        {
            InternalAllClear();
            _loadedProcessOrdrer = Persistency.PersistenceAdminProcessOrdre.GetAll();

            foreach(ProcessOrdre p in _loadedProcessOrdrer)
            {
                _vM.DisplayProcessOrdrer.Add(p);
            }

        }

        public void LoadByDate()
        {

            DateTime date = _vM.DatePicked.DateTime;

            InternalDateClear();
            _loadedProcessOrdrer = Persistency.PersistenceAdminProcessOrdre.GetAll();
            foreach (ProcessOrdre p in _loadedProcessOrdrer)
            {
                if(p.Dato==date)
                { 
                _vM.DisplayOrdrerByDate.Add(p);
                }
            }
        }


        private void InternalDateClear()
        {
            _vM.DisplayOrdrerByDate.Clear();
        }

        private void InternalAllClear()
        {
            _vM.DisplayProcessOrdrer.Clear();
        }
    }
}
