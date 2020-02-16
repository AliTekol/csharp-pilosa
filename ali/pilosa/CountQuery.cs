namespace ali.pilosa
{
    class CountQuery : IQuery
    {
        private string PQL;   
        public int getType()
        {
            return 4;
        }
        public string getPQL()
        {
            return PQL;
        }
        public CountQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}