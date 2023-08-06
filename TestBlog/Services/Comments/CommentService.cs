using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestBlog.Data;
using TestBlog.DTOs.Comments;

namespace TestBlog.Services.Comments
{
    public class CommentService : ICommentService
    {
        #region Set-Up

        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public CommentService(AppDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        #endregion

        public async Task<ServiceResponse<IEnumerable<GetCommentDTO>>> GetComments(int postId)
        {
            var response = new ServiceResponse<IEnumerable<GetCommentDTO>>();
            try
            {
                var post = await context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
                if(post != null)
                {
                    var comments = post?.Comments;
                    response.Data = mapper.Map<IEnumerable<GetCommentDTO>>(comments);
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Sorry! Nothing out there.";
                }
                

            } catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
           
            return response;
        }

        public async Task<ServiceResponse<GetCommentDTO>> GetCommentById(int id)
        {
            var response = new ServiceResponse<GetCommentDTO>();
            try
            {
                var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == id);
                if(comment != null)
                {
                    response.Data = mapper.Map<GetCommentDTO>(comment);
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Comment not found";
                }
                 
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetCommentDTO>> PostComment(AddCommentDTO newComment)
        {
            var response = new ServiceResponse<GetCommentDTO>();

            try
            {
                //Search for a post and map DTO to a comment model.
                var post = await context.Posts.FirstOrDefaultAsync(p => p.Id == newComment.PostId);
                Comment comment = mapper.Map<Comment>(newComment);

                post.Comments.Add(comment);
                await context.SaveChangesAsync();
                
                response.Data = mapper.Map<GetCommentDTO>(comment);
                response.Success = true;
            } 
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetCommentDTO>> UpdateComment (UpdateCommentDTO updatedComment)
        {
            var response = new ServiceResponse<GetCommentDTO>();
            try
            {
                var comment = await context.Comments.SingleOrDefaultAsync(c => c.Id == updatedComment.Id);
                if(comment != null)
                {
                    comment.Body = updatedComment.Body;
                    await context.SaveChangesAsync();
                    response.Data = mapper.Map<GetCommentDTO>(comment);
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Comment not found";
                }
                    
            } 
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task DeleteComment(int id)
        {
            var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment != null)
            {
                context.Comments.Remove(comment);
                await context.SaveChangesAsync();
            }
        }
    }
}
