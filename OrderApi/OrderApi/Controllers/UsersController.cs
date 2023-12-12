using Microsoft.AspNetCore.Mvc;
using OrderApi.Models.Requests;
using OrderApi.Models.Results;
using OrderApi.Models.Security;
using OrderApi.Repositories.Interfaces;
using System.Diagnostics;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository _userRepository;

        public UsersController(ILogger<UsersController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPut]
        public async Task<ActionResult<EntityResult<User>>> UpdateUser([FromBody] User user)
        {
            Guid traceId = Guid.NewGuid();
            try
            {
                if (await _userRepository.Exists(user.Id))
                {
                    //TODO: add logic for checking conflicts when updating username
                    User updatedUser = await _userRepository.UpdateAsync(user);
                    return new EntityResult<User>(updatedUser);
                }
                else
                {
                    return await CreateUser(new(user));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"trace: {traceId} message: {ex.Message}");
                return StatusCode(500, new EntityListResult<User>("Please contact your system administrator", traceId));
            }
        }

        [HttpPost]
        public async Task<ActionResult<EntityResult<User>>> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            Guid traceId = Guid.NewGuid();
            try
            {
                if (!await _userRepository.UserNameExistsAsync(createUserRequest.UserName))
                {
                    User newUser = await _userRepository.CreateAsync(new(createUserRequest));
                    return Ok(new EntityResult<User>(newUser));
                }
                else
                {
                    return BadRequest(new EntityResult<User>($"Username {createUserRequest.UserName} already exists", traceId));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"trace: {traceId} message: {ex.Message}");
                return StatusCode(500, new EntityListResult<User>("Please contact your system administrator", traceId));
            }
        }

        [HttpGet]
        public async Task<ActionResult<EntityListResult<User>>> GetUsers()
        {
            try
            {
                List<User> users = await _userRepository.GetAllAsync();
                return Ok(new EntityListResult<User>(users));
            }
            catch (Exception ex) 
            {
                Guid traceId = Guid.NewGuid();
                _logger.LogError($"trace: {traceId} message: {ex.Message}");
                return StatusCode(500, new EntityListResult<User>("Please contact your system administrator", traceId));
            }
        }
    }
}
