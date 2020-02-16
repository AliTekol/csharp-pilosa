using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class CountParse
    {
        private string result;
        public CountParse(string Result)
        {
            this.result = Result;
            var countQuery = JsonConvert.DeserializeObject<dynamic>(result);
            Console.WriteLine("results: ");
            foreach (var data in countQuery.results)
            {
                Console.WriteLine("{0}", data);
            }
        }
    }
}