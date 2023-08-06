using AutoMapper;
using TestBlog.Data;
using TestBlog.DTOs.Comments;
using TestBlog.DTOs.Posts;
using TestBlog.DTOs.Users;

namespace TestBlog.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Comment, GetCommentDTO>();
            CreateMap<AddCommentDTO, Comment>();

            CreateMap<User, GetUserDTO>();
            CreateMap<AddUserDTO, User>();

            CreateMap<Post, GetPostDTO>();
            CreateMap<AddPostDTO, Post>();
            CreateMap<Post, AddPostDTO>();
        }
    }
}
