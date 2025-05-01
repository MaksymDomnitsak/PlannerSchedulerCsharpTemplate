using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlannerScheduler.Models;
using PlannerScheduler.Data;
using AutoMapper;
using PlannerScheduler.Dto;

namespace PlannerScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _service;
        private IMapper _mapper;

        public UsersController(IUserService userService,IMapper mapper)
        {
            _service = userService;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _service.GetAllUsers();

                var usersResult = _mapper.Map<IEnumerable<UserDto>>(users);

                return Ok(usersResult);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Users?pageNumber=1&pageSize=5
        [HttpGet("pageable/")]
        public async Task<IActionResult> GetUsers([FromQuery] Pageable pageable)
        {
            try
            {
                var users = await Task.Run(() => _service.GetUsersInPage(pageable));

                var usersResult = _mapper.Map<IEnumerable<UserDto>>(users);

                var metadata = new
                {
                    users.TotalCount,
                    users.PageSize,
                    users.CurrentPage,
                    users.TotalPages,
                    users.HasNext,
                    users.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                return Ok(usersResult);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _service.GetUserById(id);

                if (user == null)
                {
                    return NotFound();
                }

                var userResult = _mapper.Map<IEnumerable<UserDto>>(user);

                return Ok(userResult);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody]UpdateUserDto user)
        {

            try
            {
                if (user == null)
                {
                    return BadRequest("User object is null");
                }
                var userEntity = await _service.GetUserById(id);

                _mapper.Map(user, userEntity);

                _service.UpdateUser(userEntity);

                return NoContent();
            }
            catch
            {
                if (!_service.UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Internal server error");
                }
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] CreateUserDto user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User object is null");
                }

                var userEntity = _mapper.Map<User>(user);

                _service.CreateUser(userEntity);

                var resultUser = _mapper.Map<UserDto>(userEntity);

                return Ok(resultUser);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _service.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }

                _service.DeleteUser(user);

                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
