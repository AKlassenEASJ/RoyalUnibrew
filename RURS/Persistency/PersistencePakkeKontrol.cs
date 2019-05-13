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
        /// Metode til at overføre en TappeKontrol til database
        /// </summary>
        /// <param name="NewTappeKontrol">En ny tappeKontrol</param>
        /// <returns>Retunere en bool, om den er gået igennem til databasen </returns>
        public static bool Post(PakkeKontrol NewTappeKontrol)
        {
            bool ok = true;
            using (HttpClient client = new HttpClient())
            {
                string serializeObject = JsonConvert.SerializeObject(NewTappeKontrol);
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
