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
    class PersistencePakkeKontrol
    {
        private const string URI = "http://localhost:60096/api/";

        /// <summary>
        /// Post metode til at tilføje en PakkeKontrol til Databasen
        /// </summary>
        /// <param name="NewPakkeKontrol"></param>
        /// <returns>bool </returns>
        public static bool Post(PakkeKontrol NewPakkeKontrol)
        {
            bool ok = true;
            using (HttpClient client = new HttpClient())
            {
                string serializeObject = JsonConvert.SerializeObject(NewPakkeKontrol);
                StringContent content = new StringContent(serializeObject, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> postAsync = client.PostAsync($"{URI}/PakkeKontrols", content);
                HttpResponseMessage resps = postAsync.Result;
                if (resps.IsSuccessStatusCode)
                {
                    string jsonStr = resps.Content.ReadAsStringAsync().Result;
                    var pk = JsonConvert.DeserializeObject<PakkeKontrol>(jsonStr);
                    ok = pk != null;
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
