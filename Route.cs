namespace diamondFkSqlGen
{
    public class Route
    {
        public int id { get; set; }
        public string path { get; set; }
        public int firstTableId { get; set; }
        public int lastTableId { get; set; }
    }
}