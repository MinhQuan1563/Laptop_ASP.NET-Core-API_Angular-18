using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAAL.API.Extensions;
using WAAL.Application.DTOs;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinNhanHangController : Controller
    {
        private readonly IThongTinNhanHangRepository _thongTinNhanHangRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public ThongTinNhanHangController(IThongTinNhanHangRepository thongTinNhanHangRepository, IMapper mapper, IUserRepository userRepository)
        {
            _thongTinNhanHangRepository = thongTinNhanHangRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ThongTinNhanHangDTO))]
        public async Task<IActionResult> GetAllThongTinNhanHang()
        {
            var result = await _thongTinNhanHangRepository.GetAllAsync();
            var thongTinNhanHang = _mapper.Map<List<ThongTinNhanHangDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(thongTinNhanHang);
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(200, Type = typeof(ThongTinNhanHangDTO))]
        public async Task<IActionResult> GetAllThongTinNhanHangByUserId(Guid userId)
        {
            var result = await _thongTinNhanHangRepository.GetAllByUserIdAsync(userId);
            var thongTinNhanHang = _mapper.Map<List<ThongTinNhanHangDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(thongTinNhanHang);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ThongTinNhanHang))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetThongTinNhanHangById(Guid id)
        {
            var thongTinNhanHang = _mapper.Map<ThongTinNhanHangDTO>(await _thongTinNhanHangRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(thongTinNhanHang);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateThongTinNhanHang(ThongTinNhanHangDTO thongTinNhanHangDTO)
        {
            if (thongTinNhanHangDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepository.GetByIdAsync(thongTinNhanHangDTO.UserId);
            if (user == null)
            {
                return BadRequest(ModelState);
            }

            var thongTinNhanHangMapper = _mapper.Map<ThongTinNhanHang>(thongTinNhanHangDTO);
            thongTinNhanHangMapper.User = user;

            var result = await _thongTinNhanHangRepository.CreateAsync(thongTinNhanHangMapper);

            if (!result)
            {
                ModelState.AddModelError("Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateThongTinNhanHang(Guid id, [FromBody] ThongTinNhanHangDTO thongTinNhanHangDTO)
        {
            if (thongTinNhanHangDTO == null)
            {
                return BadRequest(ModelState);
            }

            var thongTinNhanHangMapper = _mapper.Map<ThongTinNhanHang>(thongTinNhanHangDTO);

            try
            {
                var result = await _thongTinNhanHangRepository.UpdateAsync(id, thongTinNhanHangMapper);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ThongTinNhanHang with ID {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteThongTinNhanHang(Guid id)
        {
            try
            {
                var result = await _thongTinNhanHangRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ThongTinNhanHang with ID {id} not found");
            }

            return NoContent();
        }
    }
}
