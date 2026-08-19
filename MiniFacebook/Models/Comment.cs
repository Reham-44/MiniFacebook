namespace MiniFacebook.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
