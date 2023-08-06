namespace TestBlog.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Body { get; set; }

        public DateTime? CreatedDate = DateTime.Now;
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
