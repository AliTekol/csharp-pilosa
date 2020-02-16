using System;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class GroupByParse
    {
        private string result;
        public GroupByParse(string Result)
        {
            this.result = Result;
            var groupByQuery = JsonConvert.DeserializeObject<dynamic>(result);
            Console.WriteLine("results: ");
            foreach (var data in groupByQuery.results)
            {
                string indata = data.ToString();
                try
                {
                    for (int i = 0; i < indata.Length; i++)
                    {
                        Console.WriteLine("group: ");
                        foreach (var innerdata in data[i].group)
                        {
                            Console.WriteLine("field: {0}", innerdata.field);
                            Console.WriteLine("rowID: {0}", innerdata.rowID);
                        }
                        Console.WriteLine("count: {0}", data[i].count);
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