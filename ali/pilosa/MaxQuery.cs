namespace ali.pilosa
{
    class MaxQuery : IQuery
    {
        private string PQL;   
        public int getType()
        {
            return 10;
        }
        public string getPQL()
        {
            return PQL;
        }
        public MaxQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}