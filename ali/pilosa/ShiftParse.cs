using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class ShiftParse
    {
        private string result;
        public ShiftParse(string Result)
        {
            this.result = Result;
            var shiftQuery = JsonConvert.DeserializeObject<QueryRootObject>(result);
            Console.WriteLine("results: ");
            foreach (var data in shiftQuery.results)
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