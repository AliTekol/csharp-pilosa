using System.Collections.Generic;

namespace ali.pilosa
{
    public class QueryRootObject
    {
        public List<ColumnAttrs> columnAttrs { get; set; }
        public List<Result> results { get; set; }
    }
}