using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBlog.DTOs.Posts;
using TestBlog.Services;
using TestBlog.Services.Posts;

namespace TestBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        #region Set-Up

        private readonly IPostService postService;
        public PostsController(IPostService _postService)
        {
            postService = _postService;
        }

        #endregion

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetPostDTO>>>> GetPosts(int userId)
        {
            var res = await postService.GetPosts(userId);
            return res.Success ? Ok(res) : NotFound(res);
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPostDTO>>> GetPost(int postId)
        {
            var res = await postService.GetPost(postId);
            return res.Success ? Ok(res) : NotFound(res);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetPostDTO>>> AddPost(AddPostDTO newPost)
        {
            var res = await postService.AddPost(newPost);
            return res.Success ? Ok(res) : BadRequest(res);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetPostDTO>>> EditPost(UpdatePostDTO updatedPost)
        {
            var res = await postService.UpdatePost(updatedPost);
            return res.Success ? Ok(res) : BadRequest(res);
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePost(int postId)
        {
            await postService.DeletePost(postId);
            return Ok();
        }
    }
}
