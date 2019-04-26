using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;

namespace RURS.ViewModel
{
    public class VMBase
    {
        #region InstanceFields
        protected ProcessOrdre _processOrdre;
        #endregion

        #region Constructors
        protected VMBase()
        {
        }

        protected VMBase(int processOrdre, int faerdigVareNr, DateTime dato)
        {
            _processOrdre=new ProcessOrdre(processOrdre, faerdigVareNr, dato);
        }
        #endregion

        #region Properties
        public ProcessOrdre ProcessOrdre
        {
            get => _processOrdre;
            set => _processOrdre = value;
        }
        #endregion
    }
}
