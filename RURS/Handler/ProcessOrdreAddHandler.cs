using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using RURS.Model;
using RURS.ViewModel;
using RURS.Validation;
using RURS.Common;
using RURS.Persistency;

namespace RURS.Handler
{
    public class ProcessOrdreAddHandler
    {
        private ProcessOrdreAddViewModel _vM;
        private List<ProcessOrdre> _loadedProcessOrdrer;
        private Dictionary<int, ProcessOrdre> _loadedDictionary;
        private ValidationProcessOrdre validater;

        public ProcessOrdreAddHandler(ProcessOrdreAddViewModel vM)
        {
            _vM = vM;
            validater = new ValidationProcessOrdre();
            _loadedProcessOrdrer = new List<ProcessOrdre>();
            _loadedDictionary = new Dictionary<int, ProcessOrdre>();
        }


        public void Upload()
        {
            List<string> errormessages=InternalValidate();

            if (errormessages.Count()==0)
            {
                ProcessOrdre processOrdre = _vM.OpretningProcessOrdre;
                Persistency.PersistencyProcessOrdre.Post(processOrdre);
                InternalOpen();
            }
            else
            {
                string errormessage="";
                foreach (string s in errormessages)
                {
                    errormessage = $"{errormessage}{s} \n";
                }
                errormessage = $"{errormessage} \n Procesordren blev ikke oprettet. Ingen procesordre blev åbnet.";
                MessageDialogHelper.Show(errormessage, "Fejl:");
            }
        }
        public async void Load()
        {

            _loadedProcessOrdrer = await Persistency.PersistencyProcessOrdre.GetAll();
            foreach (ProcessOrdre p in _loadedProcessOrdrer)
            {
                _loadedDictionary.Add(p.ProcessOrdreNr,p);
            }

        }
        public void TjekPONr()
        {
            string result = validater.TjekPONr(_loadedDictionary, _vM.OpretningProcessOrdre.ProcessOrdreNr);
            _vM.ValMessagePONr = result;
            

        }

        public void TjekDate()
        {
            string result = validater.DateSanityCheck(_vM.OpretningsProcessOrdreDate.DateTime);
            _vM.ValMessageDate = result;
        }


        private void InternalOpen()
        {
            //_vM.OpenOrdreDisplay.ActiveProcessOrdre = _vM.OpretningProcessOrdre;
            SelectedPOSingleton.GetInstance().ActiveProcessOrdre = _vM.OpretningProcessOrdre;

        }

        private List<string> InternalValidate()
        {
            string pONr = "Procesordre Nummer: ";
            string fVNr = "Færdigvare Nummer: ";
            string date = "Dato: ";

            List<string> errormessages = new List<string>();
            if(validater.SanityCheckInt(_vM.OpretningProcessOrdre.ProcessOrdreNr).Length>0)
            {
                errormessages.Add(pONr+validater.SanityCheckInt(_vM.OpretningProcessOrdre.ProcessOrdreNr));
            }
            if (validater.SanityCheckInt(_vM.OpretningProcessOrdre.FaerdigVareNr).Length > 0)
            {
                errormessages.Add(fVNr+validater.SanityCheckInt(_vM.OpretningProcessOrdre.ProcessOrdreNr));
            }

            if (!(validater.IntToSmall(_vM.OpretningProcessOrdre.ProcessOrdreNr)==null))
            {
                errormessages.Add(pONr+validater.IntToSmall(_vM.OpretningProcessOrdre.ProcessOrdreNr));
            }
            if (!(validater.Empty(_vM.OpretningProcessOrdre.ProcessOrdreNr.ToString()) == null ))
            {
                errormessages.Add(pONr+validater.Empty(_vM.OpretningProcessOrdre.ProcessOrdreNr.ToString()));
            }
            if (validater.TjekPONr(_loadedDictionary, _vM.OpretningProcessOrdre.ProcessOrdreNr).Length > 0)
            {
                errormessages.Add(pONr + validater.TjekPONr(_loadedDictionary, _vM.OpretningProcessOrdre.ProcessOrdreNr));
            }


            if (!(validater.IntToSmall(_vM.OpretningProcessOrdre.FaerdigVareNr) == null))
            {
                errormessages.Add(fVNr + validater.IntToSmall(_vM.OpretningProcessOrdre.FaerdigVareNr));
            }
            if (!(validater.Empty(_vM.OpretningProcessOrdre.ProcessOrdreNr.ToString()) == null))
            {
                errormessages.Add(fVNr + validater.Empty(_vM.OpretningProcessOrdre.ProcessOrdreNr.ToString()));
            }


            if (validater.DateSanityCheck(_vM.OpretningsProcessOrdreDate.DateTime).Length>0)
            {
                errormessages.Add(date + validater.DateSanityCheck(_vM.OpretningsProcessOrdreDate.DateTime));
            }

            if(errormessages.Count==0)
            {
                InternalDatabaseValidate();
            }
            

            return errormessages; 
        }

        private string InternalDatabaseValidate()
        {
            return validater.DatabaseInputCheck(_vM.OpretningProcessOrdre.ProcessOrdreNr);
        }
    }
}
