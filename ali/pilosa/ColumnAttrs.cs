using System.Collections.Generic;

namespace ali.pilosa
{
    public class ColumnAttrs
    {
        public ColumnAttrsAttrs columnAttrsAttrs { get; set; }
        public int id { get; set; }
        public List<object> columns { get; set; }
        public Attrs attrs { get; set; }
    }
}