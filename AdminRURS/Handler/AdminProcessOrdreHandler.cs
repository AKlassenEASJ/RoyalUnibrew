using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using AdminRURS.ViewModel;
using AdminRURS.Validation;
namespace AdminRURS.Handler
{
    public class AdminProcessOrdreHandler
    {
        private AdminProcessOrdreViewModel _vM;
        private List<ProcessOrdre> _loadedProcessOrdrer;
        private ValidationAdminProcessOrdre validater;



        public AdminProcessOrdreHandler(AdminProcessOrdreViewModel vM)
        {
            _vM =vM;
            validater = new ValidationAdminProcessOrdre();
        }


        public void LoadAll()
        {
            InternalClear();
            _loadedProcessOrdrer = Persistency.PersistenceAdminProcessOrdre.GetAll();

            foreach(ProcessOrdre p in _loadedProcessOrdrer)
            {
                _vM.DisplayProcessOrdrer.Add(p);
            }
            _vM.Header = "Viser alle processordrer";
        }

        //public void LoadByDate()
        //{

        //    DateTime date = _vM.DatePicked.DateTime;

        //    InternalClear();
        //    _loadedProcessOrdrer = Persistency.PersistenceAdminProcessOrdre.GetAll();
        //    foreach (ProcessOrdre p in _loadedProcessOrdrer)
        //    {
        //        if(p.Dato==date)
        //        { 
        //        _vM.DisplayProcessOrdrer.Add(p);
        //        }
        //    }
        //    _vM.Header = $"Viser processordrer for {date.Day}/{date.Month}/{date.Year}";
        //}
        public void LoadByDate()
        {

            DateTime date = _vM.DatePicked.DateTime;

            InternalClear();
            _loadedProcessOrdrer = Persistency.PersistenceAdminProcessOrdre.GetByDate(date);
            foreach (ProcessOrdre p in _loadedProcessOrdrer)
            {
                //if (p.Dato == date)
                //{
                    _vM.DisplayProcessOrdrer.Add(p);
                //}
            }
            _vM.Header = $"Viser processordrer for {date.Day}/{date.Month}/{date.Year}";
            validater.TjekListe(_loadedProcessOrdrer);

        }
        public void TjekListe()
        {

        }

        private void InternalClear()
        {
            _vM.DisplayProcessOrdrer.Clear();
        }
    }
}
