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
    public class PersistencyProcessOrdre
    {
        private const string URI = "http://localhost:60096/api/ProcessOrdre";


        public static bool Post(ProcessOrdre processOrdre)
        {
            bool sucess=true;

            using (HttpClient client = new HttpClient())
            {
                String SerializedProcessOrdre = JsonConvert.SerializeObject(processOrdre);
                StringContent content = new StringContent(SerializedProcessOrdre, Encoding.UTF8, "application/json");

                Task<HttpResponseMessage> postAsync = client.PostAsync(URI, content);


                HttpResponseMessage resps = postAsync.Result;
                if (resps.IsSuccessStatusCode)
                {
                    string jsonResString = resps.Content.ReadAsStringAsync().Result;
                    sucess = JsonConvert.DeserializeObject<bool>(jsonResString);
                }
                else
                {
                    sucess = false;
                }
            }

            return sucess;
        }

        public async static Task<List<ProcessOrdre>> GetAll()
        {
            List<ProcessOrdre> processOrdrer = new List<ProcessOrdre>();
            

            using (HttpClient client = new HttpClient())
            {
                Task<string> resTask = client.GetStringAsync(URI);
                await resTask;
                string jsonStr = resTask.Result;

                processOrdrer = JsonConvert.DeserializeObject<List<ProcessOrdre>>(jsonStr);
            }

            return processOrdrer;
        }
    }
}
