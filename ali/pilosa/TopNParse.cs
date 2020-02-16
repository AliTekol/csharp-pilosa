using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class TopNParse
    {
        private string result;
        public TopNParse(string Result)
        {
            this.result = Result;
            var topnQuery = JsonConvert.DeserializeObject<dynamic>(result);
            Console.WriteLine("results: ");
            foreach (var data in topnQuery.results)
            {
                string indata = data.ToString();
                try
                {
                    for (int i = 0; i < indata.Length; i++)
                    {
                        Console.WriteLine("id: {0}, count: {1}", data[i].id, data[i].count);
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("The argument is out of range !", ex);
                }
            }
        }
    }
}