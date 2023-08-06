namespace TestBlog.Data
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        public DateTime? CreatedDate = DateTime.Now;

        public List<Post>? Posts { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
