namespace TestBlog.DTOs.Comments
{
    public class GetCommentDTO
    {
        public string? Body { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? UserName { get; set; }
    }
}
