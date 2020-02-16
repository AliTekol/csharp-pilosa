using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class RowsParse
    {
        private string result;
        public RowsParse(string Result)
        {
            this.result = Result;
            var rowsQuery = JsonConvert.DeserializeObject<QueryRootObject>(result);
            Console.WriteLine("results: ");
            foreach (var data in rowsQuery.results)
            {
                try
                {
                    Console.WriteLine("rows: ");
                    foreach (var innerdata1 in data.rows)
                    {
                        Console.WriteLine(innerdata1);
                    }
                    Console.WriteLine("keys: ");
                    foreach (var innerdata2 in data.keys)
                    {
                        Console.WriteLine(innerdata2);
                    }
                }
                catch (NullReferenceException ex)
                {
                    System.Console.WriteLine("Innerdata is null !", ex);
                }
            }
        }
    }
}