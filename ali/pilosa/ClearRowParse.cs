using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class ClearRowParse
    {
        private string result;
        public ClearRowParse(string Result)
        {
            this.result = Result;
            var clearRowQuery = JsonConvert.DeserializeObject<dynamic>(result);
            Console.WriteLine("results: ");
            foreach (var data in clearRowQuery.results)
            {
                Console.WriteLine("{0}", data);
            }
        }
    }
}