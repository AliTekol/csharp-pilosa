namespace ali.pilosa
{
    class TopNQuery : IQuery
    {
        private string PQL;    
        public int getType()
        {
            return 5;
        }
        public string getPQL()
        {
            return PQL;
        }
        public TopNQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}