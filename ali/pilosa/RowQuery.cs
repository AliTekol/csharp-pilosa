using Newtonsoft.Json;
using System;

namespace ali.pilosa
{
    class RowQuery : IQuery
    {
        private string PQL;
        public int getType()
        {
            return 1;
        }
        public string getPQL()
        {
            return PQL;
        }
        public RowQuery(string pql)
        {
            this.PQL = pql;
        }
    }
}