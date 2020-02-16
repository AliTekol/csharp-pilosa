namespace ali.pilosa
{
    class NotQuery : IQuery
    {
        private string PQL;    
        public int getType()
        {
            return 15;
        }
        public string getPQL()
        {
            return PQL;
        }
        public NotQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}