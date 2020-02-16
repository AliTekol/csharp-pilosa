using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class XorParse
    {
        private string result;
        public XorParse(string Result)
        {
            this.result = Result;
            var xorQuery = JsonConvert.DeserializeObject<QueryRootObject>(result);
            Console.WriteLine("results: ");
            foreach (var data in xorQuery.results)
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