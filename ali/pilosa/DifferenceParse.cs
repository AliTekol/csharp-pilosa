using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class DifferenceParse
    {
        private string result;
        public DifferenceParse(string Result)
        {
            this.result = Result;
            var differenceQuery = JsonConvert.DeserializeObject<QueryRootObject>(result);
            Console.WriteLine("results: ");
            foreach (var data in differenceQuery.results)
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