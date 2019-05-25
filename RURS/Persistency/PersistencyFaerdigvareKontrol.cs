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
    class PersistencyFaerdigvareKontrol
    {
        private const string URI = "http://localhost:60096/api/FaerdigvareKontrol";



        public async static Task<List<FaerdigvareKontrol>> GetAll()
        {
            List<FaerdigvareKontrol> faerdigvareKontrols = new List<FaerdigvareKontrol>();
            using (HttpClient client = new HttpClient())
            {
                Task<string> resTask = client.GetStringAsync(URI);
                await resTask;
                String jsonStr = resTask.Result;
                faerdigvareKontrols = JsonConvert.DeserializeObject<List<FaerdigvareKontrol>>(jsonStr);
            }
            return faerdigvareKontrols;
        }


        public async static Task<FaerdigvareKontrol> GetFaerdigvareKontrol(int ponid)
        {
            FaerdigvareKontrol faerdigvareKontrol = new FaerdigvareKontrol();
            using (HttpClient client = new HttpClient())
            {
                Task<string> resTask = client.GetStringAsync(URI + "/max/" + ponid);
                await resTask;
                String jsonStr = resTask.Result;
                faerdigvareKontrol = JsonConvert.DeserializeObject<FaerdigvareKontrol>(jsonStr);
            }

            return faerdigvareKontrol;
        }




        public static FaerdigvareKontrol GetOne(int id)
        {
            FaerdigvareKontrol faerdigvareKontrol = new FaerdigvareKontrol();
            using (HttpClient client = new HttpClient())
            {
                Task<string> resTask = client.GetStringAsync(URI + $"/{id}");
                string jsonStr = resTask.Result;
                faerdigvareKontrol = JsonConvert.DeserializeObject<FaerdigvareKontrol>(jsonStr);
            }

            return faerdigvareKontrol;
        }
    }
}
