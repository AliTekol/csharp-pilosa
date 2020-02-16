namespace ali.pilosa
{
    class SumQuery : IQuery
    {
        private string PQL;   
        public int getType()
        {
            return 16;
        }
        public string getPQL()
        {
            return PQL;
        }
        public SumQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}