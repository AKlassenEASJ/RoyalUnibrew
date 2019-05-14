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


        public static bool Post(FaerdigVare faerdigVare)
        {
            bool ok = true;

            using (HttpClient client = new HttpClient())
            {
                string jsonStr = JsonConvert.SerializeObject(faerdigVare);
                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> postAsync = client.PostAsync(URI, content);

                HttpResponseMessage resp = postAsync.Result;
                if (resp.IsSuccessStatusCode)
                {
                    string jsonResStr = resp.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonResStr);
                }
                else
                {
                    ok = false;
                }
            }

            return ok;
        }

        public static bool Put(int FaerdigVare_Nr, FaerdigVare faerdigVare)
        {
            bool ok = true;

            using (HttpClient client = new HttpClient())
            {
                string jsonStr = JsonConvert.SerializeObject(faerdigVare);
                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

                Task<HttpResponseMessage> putAsync = client.PutAsync(URI+ "/" +FaerdigVare_Nr, content);

                HttpResponseMessage resp = putAsync.Result;
                if (resp.IsSuccessStatusCode)
                {
                    string jsonResStr = resp.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonResStr);
                }
                else
                {
                    ok = false;
                }

                return ok;
            }
        }
    }
}



