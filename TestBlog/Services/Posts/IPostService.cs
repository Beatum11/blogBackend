using TestBlog.DTOs.Posts;

namespace TestBlog.Services.Posts
{
    public interface IPostService
    {
        Task<ServiceResponse<IEnumerable<GetPostDTO>>> GetPosts(int userId);

        Task<ServiceResponse<GetPostDTO>> GetPost(int id);

        Task<ServiceResponse<GetPostDTO>> AddPost(AddPostDTO newPost);

        Task<ServiceResponse<GetPostDTO>> UpdatePost(UpdatePostDTO updatedPost);

        Task DeletePost(int id);
    }
}
