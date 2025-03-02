using AutoMapper;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WAAL.API.Extensions;
using WAAL.API.Hubs;
using WAAL.Application.DTOs;
using WAAL.Application.Exceptions;
using WAAL.Application.Interfaces;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<MyHub> _hubContext;
        private readonly IPhotoService _photoService;

        public UserController(
            IUserRepository userRepository, IMapper mapper, 
            IHubContext<MyHub> hubContext, IPhotoService photoService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _hubContext = hubContext;
            _photoService = photoService;
        }

        [HttpGet("pag")]
        [ProducesResponseType(200, Type = typeof(PaginatedResponse<UserDTO>))]
        public async Task<IActionResult> GetAllPaginationUser(string? search, int skip, int take)
        {
            var (result, totalCount) = await _userRepository.GetAllPaginationAsync(search, skip, take);
            var user = _mapper.Map<List<UserDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new PaginatedResponse<UserDTO>
            {
                Data = user,
                TotalCount = totalCount
            };

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(UserDTO))]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _userRepository.GetAllAsync();
            var user = _mapper.Map<List<UserDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(user);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(AppUser))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = _mapper.Map<UserDTO>(await _userRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateUser([FromForm] UserCreateDTO userCreateDTO)
        {
            if (userCreateDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ImageUploadResult? image;

            if (userCreateDTO.HinhAnh != null)
                image = await _photoService.AddPhotoAsync(userCreateDTO.HinhAnh);
            else
                image = null;

            var userMapper = _mapper.Map<AppUser>(userCreateDTO);
            userMapper.HinhAnh = image?.Url?.ToString() ?? "";

            var result = await _userRepository.CreateAsync(userMapper);

            if (!result)
            {
                ModelState.AddModelError("Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            await _hubContext.Clients.All.SendAsync("CreateUser");

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserCreateDTO userCreateDTO)
        {
            if (userCreateDTO == null)
            {
                return BadRequest(ModelState);
            }

            var userMapper = _mapper.Map<AppUser>(userCreateDTO);

            try
            {
                var result = await _userRepository.UpdateAsync(id, userMapper);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"User with ID {id} not found");
            }
            await _hubContext.Clients.All.SendAsync("UpdateUser");

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var result = await _userRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"User with ID {id} not found");
            }

            return NoContent();
        }
    }
}
