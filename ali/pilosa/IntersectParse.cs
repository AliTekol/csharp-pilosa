using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class IntersectParse
    {
        private string result;
        public IntersectParse(string Result)
        {
            this.result = Result;
            var intersectQuery = JsonConvert.DeserializeObject<QueryRootObject>(result);
            Console.WriteLine("results: ");
            foreach (var data in intersectQuery.results)
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