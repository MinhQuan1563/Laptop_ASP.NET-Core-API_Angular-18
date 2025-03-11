using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WAAL.API.Extensions;
using WAAL.API.Hubs;
using WAAL.Application.DTOs;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietHoaDonController : Controller
    {
        private readonly IChiTietHoaDonRepository _chiTietHoaDonRepository;
        private readonly IHoaDonRepository _hoaDonRepository;
        private readonly IImeiRepository _imeiRepository;
        private readonly IHubContext<MyHub> _hubContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ChiTietHoaDonController> _logger;

        public ChiTietHoaDonController(
            IChiTietHoaDonRepository chiTietHoaDonRepository,
            IHoaDonRepository hoaDonRepository,
            IImeiRepository imeiRepository,
            IHubContext<MyHub> hubContext,
            IMapper mapper,
            ILogger<ChiTietHoaDonController> logger)
        {
            _chiTietHoaDonRepository = chiTietHoaDonRepository;
            _hoaDonRepository = hoaDonRepository;
            _imeiRepository = imeiRepository;
            _hubContext = hubContext;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChiTietHoaDon()
        {
            var listChiTietHoaDon = await _chiTietHoaDonRepository.GetAllAsync();
            return Ok(listChiTietHoaDon);
        }

        [HttpGet("hoadon/{maHd}")]
        [ProducesResponseType(200, Type = typeof(PaginatedResponse<ChiTietHoaDonDTO>))]
        public async Task<IActionResult> GetAllChiTietHoaDon(Guid maHd, string? search, int skip, int take)
        {
            var (result, totalCount) = await _chiTietHoaDonRepository.GetAllByHoaDonAsync(maHd, search, skip, take);
            var chiTietHoaDon = _mapper.Map<List<ChiTietHoaDonDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new PaginatedResponse<ChiTietHoaDonDTO>
            {
                Data = chiTietHoaDon,
                TotalCount = totalCount
            };

            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetChiTietHoaDonById([FromQuery] Guid MaHd, [FromQuery] Guid MaImei)
        {
            var chiTietHoaDon = await _chiTietHoaDonRepository.FindAsync(MaHd, MaImei);

            if (chiTietHoaDon == null)
            {
                return NotFound("Không tìm thấy chi tiết quyền với các tham số đã cho.");
            }

            return Ok(chiTietHoaDon);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChiTietHoaDon(ChiTietHoaDonDTO chiTietHoaDonDTO)
        {
            var hoaDon = await _hoaDonRepository.GetByIdAsync(chiTietHoaDonDTO.MaHd);
            var imei = await _imeiRepository.GetByIdAsync(chiTietHoaDonDTO.MaImei);

            if (hoaDon == null || imei == null)
            {
                return BadRequest("HoaDon or Imei not found");
            }

            if (string.IsNullOrEmpty(hoaDon.PhuongThucThanhToan))
            {
                return BadRequest("PhuongThucThanhToan is required");
            }

            var chiTietHoaDon = _mapper.Map<ChiTietHoaDon>(chiTietHoaDonDTO);

            chiTietHoaDon.HoaDon = hoaDon;
            chiTietHoaDon.Imei = imei;

            try
            {
                var result = await _chiTietHoaDonRepository.CreateAsync(chiTietHoaDon);
                return Ok(result);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "An error occurred while saving changes: {Message}", ex.InnerException?.Message);
                return StatusCode(500, "A database error occurred: " + ex.InnerException?.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateChiTietHoaDon([FromQuery] Guid MaHd, [FromQuery] Guid maImei, [FromBody] ChiTietHoaDonDTO chiTietHoaDonDTO)
        {
            if (chiTietHoaDonDTO == null)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            try
            {
                var chiTietHoaDon = _mapper.Map<ChiTietHoaDon>(chiTietHoaDonDTO);

                var result = await _chiTietHoaDonRepository.UpdateAsync(MaHd, maImei, chiTietHoaDon);

                if (!result)
                {
                    return StatusCode(500, "Đã xảy ra lỗi khi cập nhật.");
                }
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound($"Không tìm thấy ChiTietHoaDon với MaHd {chiTietHoaDonDTO.MaHd} và MaImei {chiTietHoaDonDTO.MaImei}. Lỗi: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteChiTietHoaDon([FromQuery] Guid maHd, [FromQuery] Guid maImei)
        {
            try
            {
                var result = await _chiTietHoaDonRepository.DeleteAsync(maHd, maImei);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ChiTietHoaDon with maHd {maHd} and maImei {maImei} not found");
            }

            return NoContent();
        }
    }
}
