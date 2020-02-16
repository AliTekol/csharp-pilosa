using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class ClearParse
    {
        private string result;
        public ClearParse(string Result)
        {
            this.result = Result;
            var clearQuery = JsonConvert.DeserializeObject<dynamic>(result);
            Console.WriteLine("results: ");
            foreach (var data in clearQuery.results)
            {
                Console.WriteLine("{0}", data);
            }
        }
    }
}