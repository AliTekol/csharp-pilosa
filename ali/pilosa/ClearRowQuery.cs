namespace ali.pilosa
{
    class ClearRowQuery : IQuery
    {
        private string PQL;
       
        public int getType()
        {
            return 17;
        }
        public string getPQL()
        {
            return PQL;
        }
        public ClearRowQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}