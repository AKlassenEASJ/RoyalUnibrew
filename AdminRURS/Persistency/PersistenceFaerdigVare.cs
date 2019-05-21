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
    class PersistenceFaerdigVare
    {
        private const string URI = "http://localhost:60096/api/FaerdigVares";

        public async static Task<FaerdigVare> GetOne(int Nummer)
        {
            FaerdigVare faerdigVare = new FaerdigVare();

            using (HttpClient client = new HttpClient())
            {
                string resTask = await client.GetStringAsync(URI + "/" + Nummer);

                faerdigVare = JsonConvert.DeserializeObject<FaerdigVare>(resTask);
            }

            return faerdigVare;
        }

        public async static Task<List<FaerdigVare>> GetAll()
        {
            List<FaerdigVare> faerdigVares = new List<FaerdigVare>();

            using (HttpClient client = new HttpClient())
            {
                string resTask = await client.GetStringAsync(URI);

                faerdigVares = JsonConvert.DeserializeObject<List<FaerdigVare>>(resTask);
            }

            return faerdigVares;
        }

        public async static Task<bool> Post(FaerdigVare faerdigVare)
        {
            bool ok = true;

            using (HttpClient client = new HttpClient())
            {
                string jsonStr = JsonConvert.SerializeObject(faerdigVare);
                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(URI, content);

                
                if (response.IsSuccessStatusCode)
                {
                    string jsonResStr = response.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonResStr);
                }
                else
                {
                    ok = false;
                }
            }

            return ok;
        }

        public async static Task<bool> Put(int Nummer, FaerdigVare faerdigVare)
        {
            bool ok = true;

            using (HttpClient client = new HttpClient())
            {
                string jsonStr = JsonConvert.SerializeObject(faerdigVare);
                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(URI+ "/" +Nummer, content);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResStr = response.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonResStr);
                }
                else
                {
                    ok = false;
                }

                return ok;
            }
        }

        public async static Task<bool> Delete(int Nummer)
        {
            bool ok = true;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(URI + "/" + Nummer);

                if (response.IsSuccessStatusCode)
                {
                    string jsonStr = response.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonStr);
                }
                else
                {
                    ok = false;
                }
            }

            return ok;
        }
    }
}



