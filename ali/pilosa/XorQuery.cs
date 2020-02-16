namespace ali.pilosa
{
    class XorQuery : IQuery
    {
        private string PQL;     
        public int getType()
        {
            return 14;
        }
        public string getPQL()
        {
            return PQL;
        }
        public XorQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}