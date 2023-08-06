namespace TestBlog.Data
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }

        public DateTime? CreatedDate = DateTime.Now;
        public int UserId { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
