namespace MiniFacebook.Models
{
    public class Post
    {
        public int Id{ get; set; }
        public string Content { get; set; }
        public int UserId {  get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
