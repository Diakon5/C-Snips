namespace AspCoreApiContro
{
    public class WallUser
    {
        public int userID;
        public DateTime CreationTime { get; set; }
        public string UserName { get; set; } = string.Empty;

        public string EMail { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
