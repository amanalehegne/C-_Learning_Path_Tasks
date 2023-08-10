namespace BlogAppAPI.Requests
{
    public class CommentRequest
    {
        public int PostId { get; set; }
        public string Text { get; set; } = "";
    }
}