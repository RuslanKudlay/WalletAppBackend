using BAL.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Common;

namespace WalletAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("post-user")]
        public async Task<IActionResult> PostUser(CreateModel user)
        {
            try
            {
                await _userService.CreateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
            
        }

        [HttpGet]
        [Route("get-users")]
        public async Task<IActionResult> GetListUsers()
        {
            var result = await _userService.GetUsers();
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-user-by-id")]
        public async Task<IActionResult> DeleteUserById(Guid userId)
        {
            var res = await _userService.DeleteUser(userId);
            if (res != false)
            {
                return Ok();
            }
            else
            {
                return BadRequest("User with this id does not exist!");
            }
        }
    }
}
