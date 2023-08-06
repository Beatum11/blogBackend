using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestBlog.Data;
using TestBlog.DTOs.Posts;

namespace TestBlog.Services.Posts
{
    public class PostService : IPostService
    {
        #region Set-Up

        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public PostService(AppDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        #endregion

        public async Task<ServiceResponse<IEnumerable<GetPostDTO>>> GetPosts(int userId)
        {
            var response = new ServiceResponse<IEnumerable<GetPostDTO>>()
            {
                Success = false
            };

            try
            {
                var user = await context.Users
                                            .Include(u => u.Posts)
                                            .FirstOrDefaultAsync(u => u.Id == userId);
                if(user != null)
                {
                    response.Data = user.Posts.Select(p => mapper.Map<GetPostDTO>(p));
                    response.Success = true;
                }
                else
                {
                    response.Message = "No posts at all. Sorry.";
                }
            } 
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetPostDTO>> GetPost(int id)
        {
            var response = new ServiceResponse<GetPostDTO>()
            {
                Success = false
            };

            try
            {
                var post = await context.Posts.FirstOrDefaultAsync(p => p.Id == id);
                if (post != null)
                {
                    response.Data = mapper.Map<GetPostDTO>(post);
                    response.Success = true;
                }
                else
                    response.Message = "Nothing. Sorry";
                
            } 
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetPostDTO>> AddPost(AddPostDTO newPost)
        {
            var response = new ServiceResponse<GetPostDTO>()
            {
                Success = false
            };

            try
            {
                var user = await context.Users
                                            .Include(u => u.Posts)
                                            .FirstOrDefaultAsync(u => u.Id == newPost.UserId);
                if (user != null)
                {
                    var posts = user.Posts;
                    var finalPost = mapper.Map<Post>(newPost);
                    posts.Add(finalPost);
                    await context.SaveChangesAsync();

                    response.Data = mapper.Map<GetPostDTO>(finalPost);
                    response.Success = true;
                }
                else
                    response.Message = "Oops";
            } 
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetPostDTO>> UpdatePost(UpdatePostDTO updatedPost)
        {
            var response = new ServiceResponse<GetPostDTO>()
            {
                Success = false
            };

            try
            {
                var post = context.Posts.FirstOrDefault(p => p.Id == updatedPost.Id);
                if (post != null)
                {
                    post.Title = updatedPost.Title;
                    post.Body = updatedPost.Body;
                    await context.SaveChangesAsync();

                    response.Data = mapper.Map<GetPostDTO>(post);
                    response.Success = true;
                }
                else
                    response.Message = "Can't find a post";
                

            } 
            catch(Exception ex)
            {
                response.Message = ex.Message;    
            }

            return response;
        }

        public async Task DeletePost(int id)
        {
            var post = await context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            context.Posts.Remove(post);
            await context.SaveChangesAsync();
        }
        
    }
}
