namespace ali.pilosa
{
    class IntersectQuery : IQuery
    {
        private string PQL;    
        public int getType()
        {
            return 7;
        }
        public string getPQL()
        {
            return PQL;
        }
        public IntersectQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}