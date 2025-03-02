using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
    public class ChiTietKhuyenMaiController : Controller
    {
        private readonly IChiTietKhuyenMaiRepository _chiTietKhuyenMaiRepository;
        private readonly IKhuyenMaiRepository _khuyenMaiRepository;
        private readonly IHoaDonRepository _hoaDonRepository;
        private readonly IHubContext<MyHub> _hubContext;
        private readonly IMapper _mapper;

        public ChiTietKhuyenMaiController(
            IChiTietKhuyenMaiRepository chiTietKhuyenMaiRepository,
            IKhuyenMaiRepository khuyenMaiRepository,
            IHoaDonRepository hoaDonRepository,
            IHubContext<MyHub> hubContext,
            IMapper mapper)
        {
            _chiTietKhuyenMaiRepository = chiTietKhuyenMaiRepository;
            _khuyenMaiRepository = khuyenMaiRepository;
            _hoaDonRepository = hoaDonRepository;
            _hubContext = hubContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChiTietKhuyenMai()
        {
            var listChiTietKhuyenMai = await _chiTietKhuyenMaiRepository.GetAllAsync();
            return Ok(listChiTietKhuyenMai);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetChiTietKhuyenMaiById([FromQuery] Guid MaHd, [FromQuery] Guid MaHoaDon)
        {
            var chiTietKhuyenMai = await _chiTietKhuyenMaiRepository.FindAsync(MaHd, MaHoaDon);

            if (chiTietKhuyenMai == null)
            {
                return NotFound("Không tìm thấy chi tiết quyền với các tham số đã cho.");
            }

            return Ok(chiTietKhuyenMai);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChiTietKhuyenMai(ChiTietKhuyenMaiDTO chiTietKhuyenMaiDTO)
        {
            var khuyenMai = await _khuyenMaiRepository.GetByIdAsync(chiTietKhuyenMaiDTO.MaKm);
            var hoaDon = await _hoaDonRepository.GetByIdAsync(chiTietKhuyenMaiDTO.MaHd);

            if (khuyenMai == null || hoaDon == null)
            {
                return BadRequest("KhuyenMai, HoaDon not found");
            }

            var chiTietKhuyenMai = _mapper.Map<ChiTietKhuyenMai>(chiTietKhuyenMaiDTO);

            chiTietKhuyenMai.KhuyenMai = khuyenMai;
            chiTietKhuyenMai.HoaDon = hoaDon;

            var result = await _chiTietKhuyenMaiRepository.CreateAsync(chiTietKhuyenMai);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateChiTietKhuyenMai([FromQuery] Guid maHd, [FromQuery] Guid maKm, [FromBody] ChiTietKhuyenMaiDTO chiTietKhuyenMaiDTO)
        {
            if (chiTietKhuyenMaiDTO == null)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            try
            {
                var chiTietKhuyenMai = _mapper.Map<ChiTietKhuyenMai>(chiTietKhuyenMaiDTO);

                var result = await _chiTietKhuyenMaiRepository.UpdateAsync(maHd, maKm, chiTietKhuyenMai);

                if (!result)
                {
                    return StatusCode(500, "Đã xảy ra lỗi khi cập nhật.");
                }
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound($"Không tìm thấy ChiTietKhuyenMai với maHd {chiTietKhuyenMaiDTO.MaHd} và MaHoaDon {chiTietKhuyenMaiDTO.MaKm}. Lỗi: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }

            return NoContent();
        }



        [HttpDelete]
        public async Task<IActionResult> DeleteChiTietKhuyenMai([FromQuery] Guid maHd, [FromQuery] Guid maKm)
        {
            try
            {
                var result = await _chiTietKhuyenMaiRepository.DeleteAsync(maHd, maKm);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ChiTietKhuyenMai with maHd {maHd} and maKm {maKm} not found");
            }

            return NoContent();
        }
    }
}
