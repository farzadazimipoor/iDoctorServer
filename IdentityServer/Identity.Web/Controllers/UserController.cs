using Identity.BLL.DataRepository.UserRepository;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Models;
using System.Net;
using System.Threading.Tasks;

namespace Identity.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/identity/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}", Name = "GetFiscalYearById")]
        [ProducesResponseType(typeof(UserDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            return Ok(user);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO model)
        {
            var (isSucceed, message, createdId) = await _userRepository.CreateUserAsync(model);

            return Created(string.Empty, (isSucceed, message, createdId, string.Empty));
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody]UserDTO model)
        {
            var (isSucceed, message) = await _userRepository.UpdateUserAsync(model);

            return Ok((isSucceed, message));
        }

        [Route("delete")]
        [HttpDelete]       
        public async Task<IActionResult> DeleteUser([FromBody]string id)
        {
            var (isSucceeded, message) = await _userRepository.DeleteUserAsync(id);

            return Ok((isSucceeded, message));
        }

        [HttpPost("query")]
        public async Task<IActionResult> GetUsersPagingList([FromBody]UsersQueryModel queryModel)
        {
            var result = await _userRepository.GetUsersPagingListAsync(queryModel);

            return Ok(result);
        }

        [HttpPut("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordDTO model)
        {
            var (isSucceeded, message) = await _userRepository.ChangePasswordAsync(model);

            return Ok((isSucceeded, message));
        }

        [HttpPut("lockout")]
        public async Task<IActionResult> Lockout([FromBody]LockoutUserDTO model)
        {
            var (isSucceeded, message) = await _userRepository.LockoutUserAccountAsync(model);

            return Ok((isSucceeded, message));
        }
    }
}