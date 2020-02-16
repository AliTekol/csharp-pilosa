namespace ali.pilosa
{
    class StoreQuery : IQuery
    {
        private string PQL;     
        public int getType()
        {
            return 11;
        }
        public string getPQL()
        {
            return PQL;
        }
        public StoreQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}