using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using RURS.Persistency;

namespace RURS.Validation
{
    class ValidationProcessOrdre: ValidationBase
    {
        public string TjekPONr(Dictionary<int, ProcessOrdre> liste, int s)
        {
            string valiRes="";

           if (liste.ContainsKey(s))
                {
                    valiRes = "Procesordrenummeret findes. Vælg et unikt nummer.";
                }

           

                return valiRes;
        }

        public string TjekFvNr(Dictionary<int, ProcessOrdre> liste, int s)
        {
            string valiRes = "";

            if (liste.ContainsKey(s))
            {
                valiRes = "Færdigvarenummeret findes ikke i databasen. Brug et eksisterende færdigvarenummer.";
            }



            return valiRes;
        }
        public string SanityCheckInt(int number)
        {
            string valiRes = "";

            if(number < 1)
            {
                valiRes = "Nummeret skal være større end 0.";
            }
            return valiRes;
        }

        public string DateSanityCheck(DateTime date)
        {
            string valiRes = "";

            if(date<DateTime.Today)
            {
                valiRes="Dette er ikke en tidsmaskine.";
            }

            return valiRes;
        }

        public string DatabaseInputCheck(int processOrdreNr)
        {
            string result="";
            ProcessOrdre processOrdre = PersistencyProcessOrdre.Get(processOrdreNr);
            if(!(processOrdre == null))
            {
                result="Procesordre Nummer: Der findes allerede en processordre med dette nummer.";
            }


            return result;
        }



    }
}
