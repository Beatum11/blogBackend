using TestBlog.DTOs.Comments;

namespace TestBlog.Services.Comments
{
    public interface ICommentService
    {
        Task<ServiceResponse<IEnumerable<GetCommentDTO>>> GetComments(int postId);
        Task<ServiceResponse<GetCommentDTO>> GetCommentById(int id);
        Task<ServiceResponse<GetCommentDTO>> PostComment(AddCommentDTO newComment);
        Task<ServiceResponse<GetCommentDTO>> UpdateComment(UpdateCommentDTO updatedComment);
        Task DeleteComment(int id);
    }
}
