using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBlog.DTOs.Comments;
using TestBlog.Services;
using TestBlog.Services.Comments;

namespace TestBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        #region Set-Up

        private readonly ICommentService commentService;

        public CommentsController(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        #endregion

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetCommentDTO>>>> GetComments(int postId)
        {
            var res = await commentService.GetComments(postId);
            return res.Success ? Ok(res) : NotFound(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCommentDTO>>> GetComment(int id)
        {
            var res = await commentService.GetCommentById(id);
            return res.Success ? Ok(res) : NotFound(res);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCommentDTO>>> PostComment(AddCommentDTO newComment)
        {
            var res = await commentService.PostComment(newComment);
            return res.Success ? Ok(res) : BadRequest(res);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCommentDTO>>> UpdateComment(UpdateCommentDTO updatedComment)
        {
            var res = await commentService.UpdateComment(updatedComment);
            return res.Success ? Ok(res) : BadRequest(res);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteComment(int id)
        {
            await commentService.DeleteComment(id);
            return Ok();
        }
    }
}
