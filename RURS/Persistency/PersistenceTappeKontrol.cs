using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Models;
using Newtonsoft.Json;

namespace RURS.Persistency
{
    class PersistenceTappeKontrol
    {
        private const string URI = "http://localhost:60096/api/";


        public static bool Post(TappeKontrol NewTappeKontrol)
        {
            bool status;

            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(NewTappeKontrol);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        

                Task<HttpResponseMessage> responseTask = client.PostAsync($"{URI}TappeKontrols", content);

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
    }
}
