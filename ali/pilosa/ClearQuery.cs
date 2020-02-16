namespace ali.pilosa
{
    public class ClearQuery : IQuery
    {
        private string PQL;
       
        public int getType()
        {
            return 3;
        }
        public string getPQL()
        {
            return PQL;
        }
        public ClearQuery(string pql)
        {
            this.PQL = pql;   
        }
    }
}