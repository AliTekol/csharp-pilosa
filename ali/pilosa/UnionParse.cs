using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class UnionParse
    {
        private string result;
        public UnionParse(string Result)
        {
            this.result = Result;
            var unionQuery = JsonConvert.DeserializeObject<QueryRootObject>(result);
            Console.WriteLine("results: ");
            foreach (var data in unionQuery.results)
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