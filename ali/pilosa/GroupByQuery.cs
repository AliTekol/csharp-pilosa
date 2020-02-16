namespace ali.pilosa
{
    class GroupByQuery : IQuery
    {
        private string PQL;   
        public int getType()
        {
            return 13;
        }
        public string getPQL()
        {
            return PQL;
        }
        public GroupByQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}