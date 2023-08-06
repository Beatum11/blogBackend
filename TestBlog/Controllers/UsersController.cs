using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBlog.DTOs.Users;
using TestBlog.Services;
using TestBlog.Services.Users;

namespace TestBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Set-Up

        private readonly IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        #endregion

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetUserDTO>>>> GetUsers()
        {
            var res = await userService.GetUsers();
            return res.Success ? Ok(res) : NotFound(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDTO>>> GetUser(int id)
        {
            var res = await userService.GetUser(id);
            return res.Success ? Ok(res) : NotFound(res);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetUserDTO>>> PostUser(AddUserDTO newUser)
        {
            var res = await userService.PostUser(newUser);
            return res.Success ? Ok(res) : BadRequest(res);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetUserDTO>>> PutUser(UpdateUserDTO updatedUser)
        {
            var res = await userService.UpdateUser(updatedUser);
            return res.Success ? Ok(res) : BadRequest(res);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser (int id)
        {
            await userService.DeleteUser(id);
            return Ok();
        }
    }
}
