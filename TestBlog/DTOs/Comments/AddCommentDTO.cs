namespace TestBlog.DTOs.Comments
{
    public class AddCommentDTO
    {
        public string? Body { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }
    }
}
