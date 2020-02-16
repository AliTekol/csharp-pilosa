namespace ali.pilosa
{
    class ShiftQuery : IQuery
    {
        private string PQL;     
        public int getType()
        {
            return 18;
        }
        public string getPQL()
        {
            return PQL;
        }
        public ShiftQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}