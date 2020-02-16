namespace ali.pilosa
{
    class SetQuery : IQuery
    {
        private string PQL;   
        public int getType()
        {
            return 2;
        }
        public string getPQL()
        {
            return PQL;
        }
        public SetQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}