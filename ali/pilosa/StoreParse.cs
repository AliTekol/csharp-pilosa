using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class StoreParse
    {
        private string result;
        public StoreParse(string Result)
        {
            this.result = Result;
            var storeQuery = JsonConvert.DeserializeObject<dynamic>(result);
            Console.WriteLine("results: ");
            foreach (var data in storeQuery.results)
            {
                Console.WriteLine("{0}", data);
            }
        }
    }
}