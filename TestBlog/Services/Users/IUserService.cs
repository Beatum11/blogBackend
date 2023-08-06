using TestBlog.DTOs.Users;

namespace TestBlog.Services.Users
{
    public interface IUserService
    {
        Task<ServiceResponse<IEnumerable<GetUserDTO>>> GetUsers();

        Task<ServiceResponse<GetUserDTO>> GetUser(int id);

        Task<ServiceResponse<GetUserDTO>> PostUser(AddUserDTO newUser);

        Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO updatedUser);

        Task DeleteUser(int id);
    }
}
