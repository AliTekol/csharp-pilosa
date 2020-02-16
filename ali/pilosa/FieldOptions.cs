namespace ali.pilosa
{
    public class FieldOptions
    {
        public string type { get; set; }
        public string cacheType { get; set; }
        public int cacheSize { get; set; }
        public bool keys { get; set; }
        public string timeQuantum { get; set; }
        public bool? noStandardView { get; set; }
    }
}