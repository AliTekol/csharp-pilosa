using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class MaxParse
    {
        private string result;
        public MaxParse(string Result)
        {
            this.result = Result;
            var maxQuery = JsonConvert.DeserializeObject<QueryRootObject>(result);
            Console.WriteLine("results: ");
            foreach (var data in maxQuery.results)
            {
                Console.WriteLine("value: {0}", data.value);
                Console.WriteLine("count: {0}", data.count);
            }
        }
    }
}