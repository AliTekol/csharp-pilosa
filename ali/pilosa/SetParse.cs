using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class SetParse
    {
        private string result;
        public SetParse(string Result)
        {
            this.result = Result;
            var setQuery = JsonConvert.DeserializeObject<dynamic>(result);
            Console.WriteLine("results: ");
            foreach (var data in setQuery.results)
            {
                Console.WriteLine("{0}", data);
            }
        }
    }
}