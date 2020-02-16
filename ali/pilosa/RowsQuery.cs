namespace ali.pilosa
{
    class RowsQuery : IQuery
    {
        private string PQL;    
        public int getType()
        {
            return 12;
        }
        public string getPQL()
        {
            return PQL;
        }
        public RowsQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}