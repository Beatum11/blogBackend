using TestBlog.DTOs.Comments;

namespace TestBlog.DTOs.Posts
{
    public class GetPostDTO
    {
        public string? Title { get; set; }
        public string? Body { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? UserName { get; set; }

        public List<GetCommentDTO>? Comments { get; set; }
    }
}
