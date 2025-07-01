using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Service;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.TopicProgress;
using StudyPlatformAPI.DTOs.User;

namespace StudyPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserResponseDTO>(user));
        }



        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(_mapper.Map<List<UserResponseDTO>>(users));
        }

        [HttpGet("/listuser")]
        public async Task<IActionResult> GetAllUsersNoPass()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(_mapper.Map<List<UserResponseNoPasswordDTO>>(users));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateDTO userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            user.JoinedDate = DateOnly.FromDateTime(DateTime.Now);
            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, _mapper.Map<UserResponseDTO>(createdUser));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id, UserCreateDTO userUpdateDto)
        {
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            // Map the DTO to the existing TopicProgress entity
            _mapper.Map(userUpdateDto, existingUser);


            var result = await _userService.UpdateUserAsync(existingUser);
            if (!result)
            {
                return BadRequest("Failed to update user.");
            }

            return Ok(_mapper.Map<UserResponseDTO>(existingUser));

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDto)
        {
            var user = _mapper.Map<User>(userLoginDto);
            try
            {
                var loggedInUser = await _userService.LoginByEmailAndPassword(user);
                return Ok(_mapper.Map<UserResponseNoPasswordDTO>(loggedInUser));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("loginusername")]
        public async Task<IActionResult> LoginByUserName(UserLoginByUsernameDTO userLoginDto)
        {
            var user = _mapper.Map<User>(userLoginDto);
            try
            {
                var loggedInUser = await _userService.LoginByUsernameAndPassword(user);
                return Ok(_mapper.Map<UserResponseNoPasswordDTO>(loggedInUser));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
