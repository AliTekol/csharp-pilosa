namespace ali.pilosa
{
    class DifferenceQuery : IQuery
    {
        private string PQL;  
        public int getType()
        {
            return 8;
        }
        public string getPQL()
        {
            return PQL;
        }
        public DifferenceQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}