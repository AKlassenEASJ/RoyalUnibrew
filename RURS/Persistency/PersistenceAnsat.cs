using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using Newtonsoft.Json;

namespace RURS.Persistency
{
    class PersistenceAnsat
    {


        #region URI

        private const string URI = "http://localhost:60096/api/";
        #endregion

        #region Methods

        public static async Task<List<Ansat>> GetAllAsync()
        {
            List<Ansat> tempAnsatte = new List<Ansat>();

            using (HttpClient client = new HttpClient())
            {

                string jsonStringRead = await client.GetStringAsync($"{URI}Ansats");

                tempAnsatte = JsonConvert.DeserializeObject<List<Ansat>>(jsonStringRead);

            }

            return tempAnsatte;
        }
        

        #endregion

    }
}
