using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class MinParse
    {
        private string result;
        public MinParse(string Result)
        {
            this.result = Result;
            var minQuery = JsonConvert.DeserializeObject<QueryRootObject>(result);
            Console.WriteLine("results: ");
            foreach (var data in minQuery.results)
            {
                Console.WriteLine("value: {0}", data.value);
                Console.WriteLine("count: {0}", data.count);
            }
        }
    }
}