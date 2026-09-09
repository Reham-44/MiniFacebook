namespace MiniFacebook.Models
{
    public class Post
    {
        public int Id{ get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int UserId {  get; set; }
        public User user {  get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
