using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using Newtonsoft.Json;

namespace RURS.Persistency
{
    class PersistenceDaaseVaegt
    {
        private const string URI = "http://localhost:60096/api/";

        public static async Task<ObservableCollection<DaaseVaegt>> GET_ALL(int processordernr, int kontrolnr)
        {
            ObservableCollection<DaaseVaegt> liste = new ObservableCollection<DaaseVaegt>();

            using (HttpClient client = new HttpClient())
            {
                Task<string> resTask = client.GetStringAsync($"{ URI}/DaaseVaegts/{processordernr}/{kontrolnr}");
                await resTask;
                string jsonStr = resTask.Result;
                liste = JsonConvert.DeserializeObject<ObservableCollection<DaaseVaegt>>(jsonStr);
            }

            return liste;
        }

        public static bool Post(DaaseVaegt NewDaaseVaegt)
        {
            bool ok = true;
            using (HttpClient client = new HttpClient())
            {
                string serializeObject = JsonConvert.SerializeObject(NewDaaseVaegt);
                StringContent content = new StringContent(serializeObject, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> postAsync = client.PostAsync($"{URI}/DaaseVaegts", content);
                HttpResponseMessage resps = postAsync.Result;
                if (resps.IsSuccessStatusCode)
                {
                    string jsonStr = resps.Content.ReadAsStringAsync().Result;
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
