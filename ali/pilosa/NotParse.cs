using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class NotParse
    {
        private string result;
        public NotParse(string Result)
        {
            this.result = Result;
            var notQuery = JsonConvert.DeserializeObject<QueryRootObject>(result);
            Console.WriteLine("results: ");
            foreach (var data in notQuery.results)
            {
                Console.WriteLine("attrs :{0}", data.attrs);
                foreach (var column in data.columns)
                {
                    Console.WriteLine("columns :{0}", column);
                }
            }
        }
    }
}