using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestBlog.Data;
using TestBlog.DTOs.Users;

namespace TestBlog.Services.Users
{
    public class UserService : IUserService
    {
        #region Set-Up

        private readonly AppDbContext context;
        private readonly IMapper mapper;    

        public UserService(AppDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        #endregion

        public async Task<ServiceResponse<IEnumerable<GetUserDTO>>> GetUsers()
        {
            var response = new ServiceResponse<IEnumerable<GetUserDTO>>();
            try
            {
                var users = await context.Users.ToListAsync();
                response.Data = users.Select(u => mapper.Map<GetUserDTO>(u));
                response.Success = true;
            } 
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response;
        }

        public async Task<ServiceResponse<GetUserDTO>> GetUser(int id)
        {
            var response = new ServiceResponse<GetUserDTO>();

            try
            {
                var user = await context.Users.SingleOrDefaultAsync(u => u.Id == id);
                if(user != null)
                {
                    response.Data = mapper.Map<GetUserDTO>(user);
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "User not found";
                }
            } catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        
        public async Task<ServiceResponse<GetUserDTO>> PostUser(AddUserDTO newUser)
        {
            var response = new ServiceResponse<GetUserDTO>();
            try
            {
                var user = mapper.Map<User>(newUser);
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                response.Data = mapper.Map<GetUserDTO>(user);
                response.Success = true;
            } 
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO updatedUser)
        {
            var response = new ServiceResponse<GetUserDTO>();
            try
            {
                var user = context.Users.FirstOrDefault(u => u.Id == updatedUser.Id);
                if(user != null)
                {
                    user.Name = updatedUser.Name;
                    user.Age = updatedUser.Age;

                    context.Users.Add(user);
                    await context.SaveChangesAsync();

                    response.Data = mapper.Map<GetUserDTO>(user);
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "User not found";
                }
            } catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        } 

        public async Task DeleteUser(int id)
        {
            var user = context.Users.SingleOrDefault(u => u.Id == id);
            if(user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
