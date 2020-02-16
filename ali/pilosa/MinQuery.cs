namespace ali.pilosa
{
    class MinQuery : IQuery
    {
        private string PQL;    
        public int getType()
        {
            return 9;
        }
        public string getPQL()
        {
            return PQL;
        }
        public MinQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}