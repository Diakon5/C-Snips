namespace AspCoreApiContro
{
    public class WallMessage
    {
        public int messageID;
        public WallMessage? RespondingTo { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime? LastEditDate { get; set; }
        public string Message { get; set; } = string.Empty;
        public WallUser Author { get; set; }
    } 
}
