using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class SumParse
    {
        private string result;
        public SumParse(string Result)
        {
            this.result = Result;
            var sumQuery = JsonConvert.DeserializeObject<QueryRootObject>(result);
            Console.WriteLine("results: ");
            foreach (var data in sumQuery.results)
            {
                Console.WriteLine("value: {0}", data.value);
                Console.WriteLine("count: {0}", data.count);
            }
        }
    }
}