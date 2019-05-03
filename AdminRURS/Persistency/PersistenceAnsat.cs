using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<bool> Post(Ansat ansatToPost)
        {
            bool status;

            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(ansatToPost);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                Task<HttpResponseMessage> responseTask = client.PostAsync($"{URI}Ansats", content);

                await responseTask;

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


        #endregion

    }
}
