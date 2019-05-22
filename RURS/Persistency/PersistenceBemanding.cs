using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RURS.Persistency
{
    class PersistenceBemanding<T>
    {
        #region InstanceFields

        private const string URI = "http://localhost:60096/api/";


        #endregion

        #region Methods

        public async Task<bool> PostAsync(T item)
        {
            bool status;

            using (HttpClient client = new HttpClient())
            {

                string jsonString = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{URI}{typeof(T).Name}s", content);

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
