namespace AspCoreApiContro.Models
{
    public class WallMessage
    {
        public int messageID;
        public WallMessage? RespondingTo { get; set; }
        public int RespondingTo_ID { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime? LastEditDate { get; set; }
        public string Message { get; set; } = string.Empty;
        public WallUser? Author { get; set; }
        public int Author_ID { get; set; }
    }
        public class WallMessageDTO
    {
        public int messageID;
        public int RespondingTo_ID { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime? LastEditDate { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Author_ID { get; set; }
    }
}
