using System;
using System.Threading.Tasks;

namespace ali.pilosa
{
    class Program
    {
        public static async Task Main(string[] args)
        {   
            var client = new PilosaClient();
            var index = new ali.pilosa.Index("stargazer");   
            var schema = await client.createField("myindex", "myfield", "type", -1000, 5000);
            //var data = index.Intersect(index.Row(1), index.Row(2), index.Row(3));
            //var data = index.Row(1);
            //var data = index.Set(10, 2);
            //var data = index.Clear(10, 1);
            //var data = index.Count(index.Row(1));
            //var data = index.TopN();
            var data = index.Union(index.Row(1), index.Row(2), index.Row(3));
            //var data = index.Difference(index.Row(1), index.Row(2));
            //var data = index.Min();
            //var data = index.Max();
            //var data = index.Store(index.Row(1), 2);
            //var data = index.Store(index.Intersect(index.Row(10), index.Row(11)), 20);
            //var data = index.Rows();
            //var data = index.GroupBy(index.Rows("language"));
            //var data = index.Xor(index.Row(1), index.Row(2));
            //var data = index.Not(index.Row(1));
            //var data = index.Sum();
            //var data = index.ClearRow(1);
            //var data = index.Shift(index.Row(1), 2);


          
            var query = await client.query("repository", data);
        }
    }
}