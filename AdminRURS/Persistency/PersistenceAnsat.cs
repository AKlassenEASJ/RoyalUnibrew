using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AdminRURS.Common;
using ModelLibary.Models;
using Newtonsoft.Json;

namespace AdminRURS.Persistency
{
    class PersistenceAnsat
    {

        #region InstanceFields

        private const string URI = "http://localhost:60096/api/";


        #endregion


        #region Methods

        public Ansat GetOne(string initialer)
        {
            Ansat tempAnsat = new Ansat();

            using (HttpClient client = new HttpClient())
            {
                Task<string> task = client.GetStringAsync($"{URI}Ansats/{initialer}");
                string jsonString = task.Result;

                tempAnsat = JsonConvert.DeserializeObject<Ansat>(jsonString);
            }

            return tempAnsat;
        }

        /// <summary>
        /// Formålet er at gemme en ansat i databasen
        /// </summary>
        /// <param name="ansatToPost"> Ansat der skal gemmes i databasen</param>
        /// <returns>Returnerer en bool</returns>
        public async Task<bool> PostAsync(Ansat ansatToPost)
        {
            bool status = false;

            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(ansatToPost);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                
                    HttpResponseMessage response = await client.PostAsync($"{URI}Ansats", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonStringRead = response.Content.ReadAsStringAsync().Result;
                        status = JsonConvert.DeserializeObject<bool>(jsonStringRead);
                    }
                    else
                    {
                        status = false;
                    }

            }

            return status;

        }

        public bool Delete(string initialer)
        {
            bool status;

            using (HttpClient client = new HttpClient())
            {

                Task<HttpResponseMessage> responseTask = client.DeleteAsync($"{URI}Ansats/{initialer}");

                HttpResponseMessage response = responseTask.Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonStringRead = response.Content.ReadAsStringAsync().Result;
                    status = JsonConvert.DeserializeObject<bool>(jsonStringRead);
                }
                else
                {
                    status = false;
                }

            }

            return status;
        }

        /// <summary>
        /// Formålet er at ændre på en ansat i databasen.
        /// </summary>
        /// <param name="initialer">Initialer for den ansatte i databasen, der skal opdateres</param>
        /// <param name="ansatToPut">Det nye ansat objekt der skal erstatte, det valgte i databasen</param>
        /// <returns>Returnerer en bool</returns>
        public async Task<bool> PutAsync(string initialer, Ansat ansatToPut)
        {
            bool status;

            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(ansatToPut);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"{URI}Ansats/{initialer}", content);
                
                if (response.IsSuccessStatusCode)
                {
                    string jsonStringRead = response.Content.ReadAsStringAsync().Result;
                    status = JsonConvert.DeserializeObject<bool>(jsonStringRead);
                }
                else
                {
                    status = false;
                }

                return status;

            }
        }



        #endregion

    }
}
