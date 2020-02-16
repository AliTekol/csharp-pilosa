namespace ali.pilosa
{
    public interface IQuery
    {
        public const int ROW = 1;
        public const int SET = 2;
        public const int CLEAR = 3;
        public const int COUNT = 4;
        public const int TOPN = 5;
        public const int UNION = 6;
        public const int INTERSECT = 7;
        public const int DIFFERENCE = 8;
        public const int MIN = 9;
        public const int MAX = 10;
        public const int STORE = 11;
        public const int ROWS = 12;
        public const int GROUPBY = 13;
        public const int XOR = 14;
        public const int NOT = 15;
        public const int SUM = 16;  
        public const int CLEAR_ROW = 17; 
        public const int SHIFT = 18;            
        public int getType();
        public string getPQL();
    }
}