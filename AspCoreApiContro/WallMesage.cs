namespace AspCoreApiContro
{
    public class WallMessage
    {
        public DateTime PostingDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public string Message { get; set; }
        public WallUser Author { get; set; }
    }
}
