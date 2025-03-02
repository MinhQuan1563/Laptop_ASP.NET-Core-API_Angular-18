using AutoMapper;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using WAAL.API.Extensions;
using WAAL.Application.DTOs;
using WAAL.Application.Exceptions;
using WAAL.Application.Interfaces;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : Controller
    {
        private readonly IHoaDonRepository _hoaDonRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IThongTinNhanHangRepository _thongTinNhanHangRepository;

        public HoaDonController(
            IHoaDonRepository hoaDonRepository, IMapper mapper,
            IUserRepository userRepository, IThongTinNhanHangRepository thongTinNhanHangRepository)
        {
            _hoaDonRepository = hoaDonRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _thongTinNhanHangRepository = thongTinNhanHangRepository;
        }

        [HttpGet("pag")]
        [ProducesResponseType(200, Type = typeof(PaginatedResponse<HoaDonDTO>))]
        public async Task<IActionResult> GetAllPaginationHoaDon(string? tinhTrang, string? search, int skip, int take)
        {
            var (result, totalCount) = await _hoaDonRepository.GetAllPaginationAsync(tinhTrang, search, skip, take);
            var hoaDon = _mapper.Map<List<HoaDonDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new PaginatedResponse<HoaDonDTO>
            {
                Data = hoaDon,
                TotalCount = totalCount
            };

            return Ok(response);
        }

        [HttpGet("pag/{userId}")]
        [ProducesResponseType(200, Type = typeof(PaginatedResponse<HoaDonDTO>))]
        public async Task<IActionResult> GetAllPaginationHoaDonByUser(Guid userId, string? tinhTrang, string? search, int skip, int take)
        {
            var (result, totalCount) = await _hoaDonRepository.GetAllByUserPaginationAsync(userId, tinhTrang, search, skip, take);
            var hoaDon = _mapper.Map<List<HoaDonDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new PaginatedResponse<HoaDonDTO>
            {
                Data = hoaDon,
                TotalCount = totalCount
            };

            return Ok(response);
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(HoaDon))]
        public async Task<IActionResult> GetAllHoaDon()
        {
            var result = await _hoaDonRepository.GetAllAsync();
            var hoaDon = _mapper.Map<List<HoaDonDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(hoaDon);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(HoaDon))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetHoaDonById(Guid id)
        {
            var hoaDon = _mapper.Map<HoaDonDTO>(await _hoaDonRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(hoaDon);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateHoaDon(HoaDonDTO hoaDonDTO)
        {
            if (hoaDonDTO == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepository.GetByIdAsync(hoaDonDTO.UserId);
            var thongTinNhanHang = await _thongTinNhanHangRepository.GetByIdAsync(hoaDonDTO.ThongTinNhanHangId);

            if (user == null || thongTinNhanHang == null)
            {
                return BadRequest("User, ThongTinNhanHang không tồn tại.");
            }

            var hoaDon = _mapper.Map<HoaDon>(hoaDonDTO);

            hoaDon.User = user;
            hoaDon.ThongTinNhanHang = thongTinNhanHang;

            var result = await _hoaDonRepository.CreateAsync(hoaDon);

            if (!result)
            {
                ModelState.AddModelError("Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            var hoaDonReponse = _mapper.Map<HoaDonDTO>(hoaDon);

            return Ok(hoaDonReponse);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTinhTrangHoaDon(Guid id, [FromBody] string? tinhTrang)
        {
            if (string.IsNullOrEmpty(tinhTrang))
            {
                return BadRequest("Tình trạng không hợp lệ.");
            }

            var result = await _hoaDonRepository.UpdateTinhTrangAsync(id, tinhTrang);

            if (!result)
            {
                return NotFound($"Hóa đơn với ID {id} không tồn tại.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteHoaDon(Guid id)
        {
            try
            {
                var result = await _hoaDonRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"HoaDon with ID {id} not found");
            }

            return NoContent();
        }
    }
}
