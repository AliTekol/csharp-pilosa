using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class RowParse
    {
        private string result;
        public RowParse(string Result)
        {
            this.result = Result;
            var rowQuery = JsonConvert.DeserializeObject<QueryRootObject>(result);
            foreach (var data in rowQuery.results)
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