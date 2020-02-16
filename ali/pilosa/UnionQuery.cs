namespace ali.pilosa
{
    class UnionQuery : IQuery
    {
        private string PQL;    
        public int getType()
        {
            return 6;
        }
        public string getPQL()
        {
            return PQL;
        }
        public UnionQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}