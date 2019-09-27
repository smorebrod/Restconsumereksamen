using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestEksamenConsumer
{
    class Program
    {
        private static string Parkeringuri = "https://localhost:44351/api/Eksamen";

        public static async Task<IList<Parkering>> GetParkingAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(Parkeringuri);
                IList<Parkering> cList = JsonConvert.DeserializeObject<IList<Parkering>>(content);
                return cList;
            }
        }

        public static async Task<Parkering> GetOneParkingAsync(int id)
        {
            string requestUri = Parkeringuri + "/" + id;
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(requestUri);
                Parkering c = JsonConvert.DeserializeObject<Parkering>(content);
                return c;
            }
        }

        //public static async Task<Parkering> AddParkeringAsync(Parkering newParkering)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        var jsonString = JsonConvert.SerializeObject(newParkering);
        //        Console.WriteLine("JSON: " + jsonString);
        //        StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await client.PostAsync(Parkeringuri, content);

        //        string str = await response.Content.ReadAsStringAsync();
        //        Parkering copyOfNewParkering = JsonConvert.DeserializeObject<Parkering>(str);
        //        return copyOfNewParkering;

        //    }



            static void Main(string[] args)
        {


             // får hele listen ud 
            IList<Parkering> cList = GetParkingAsync().Result;
            for (int i = 0; i < cList.Count; i++)
                Console.WriteLine(cList[i].ToString());
            Console.WriteLine();


            // giv et id og få 1 ud
            Console.WriteLine("giv et customer id, for at få oplysninger ud");
            string idStr = Console.ReadLine();
            int id = int.Parse(idStr);
            Parkering parkering = GetOneParkingAsync(id).Result;
            Console.WriteLine(parkering.ToString());
            Console.WriteLine();
            Console.ReadLine();


                // insert ny parkering
                //Parkering newCustomer = new Parkering(id, NrPlade, AntalTimer, timepris, totalpris, dato);
                //Parkering parkering = AddParkeringAsync(newCustomer).Result;
                //Console.WriteLine("Parkering inserted");
                //Console.WriteLine(parkering.ToString());
                //Console.WriteLine("------------------------------------------");
                //IList<Parkering> cList1 = GetParkingAsync().Result;

                //for (int i = 0; i < cList1.Count; i++)
                //    Console.WriteLine(cList1[i].ToString());
                //Console.WriteLine();
                //Console.ReadLine();

            }

    }
}

