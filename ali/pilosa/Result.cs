using System.Collections.Generic;

namespace ali.pilosa
{
    public class Result
    {
        public List<object> insideOfArray { get; set; }
        public int id { get; set; }
        public int value { get; set; }
        public int count { get; set; }
        public object attrs { get; set; }
        public List<object> columns { get; set; }
        public string userName { get; set; }
        public List<Result> innerResult { get; set; }
        public List<object>  rows { get; set; }
        public List<object> keys { get; set; }
        public bool? active { get; set; }
    }
}