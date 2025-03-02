using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WAAL.API.Extensions;
using WAAL.API.Hubs;
using WAAL.Application.DTOs;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;
using WAAL.Persistence.Repositories;

namespace WAAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietQuyenController : Controller
    {
        private readonly IChiTietQuyenRepository _chiTietQuyenRepository;
        private readonly IChucNangRepository _chucNangRepository;
        private readonly IHubContext<MyHub> _hubContext;
        private readonly IMapper _mapper;

        public ChiTietQuyenController(
            IChiTietQuyenRepository chiTietQuyenRepository,
            IChucNangRepository chucNangRepository,
            IHubContext<MyHub> hubContext,
            IMapper mapper)
        {
            _chiTietQuyenRepository = chiTietQuyenRepository;
            _chucNangRepository = chucNangRepository;
            _hubContext = hubContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChiTietQuyen()
        {
            var listChiTietQuyen = await _chiTietQuyenRepository.GetAllAsync();
            return Ok(listChiTietQuyen);
        }

        [HttpGet("GetByRole/{roleId}")]
        public async Task<IActionResult> GetAllChiTietQuyenByRole(Guid roleId)
        {
            if (roleId == Guid.Empty)
            {
                return BadRequest("Yêu cầu Role ID.");
            }

            var listChiTietQuyen = await _chiTietQuyenRepository.GetAllChiTietQuyenByRoleAsync(roleId);

            if (listChiTietQuyen == null || !listChiTietQuyen.Any())
            {
                return NotFound("Không tìm thấy quyền nào cho vai trò được chỉ định.");
            }

            return Ok(listChiTietQuyen);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetChiTietQuyenById([FromQuery] Guid maQuyen, [FromQuery] Guid maChucNang, [FromQuery] string hanhDong)
        {
            var chiTietQuyen = await _chiTietQuyenRepository.FindAsync(maQuyen, maChucNang, hanhDong);

            if (chiTietQuyen == null)
            {
                return NotFound("Không tìm thấy chi tiết quyền với các tham số đã cho.");
            }

            return Ok(chiTietQuyen);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChiTietQuyen(ChiTietQuyenDTO chiTietQuyenDTO)
        {
            var chiTietQuyen = _mapper.Map<ChiTietQuyen>(chiTietQuyenDTO);
            var result = await _chiTietQuyenRepository.CreateAsync(chiTietQuyen);
            await _hubContext.Clients.All.SendAsync("loadHanhDong");
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KiemTraQuyen(ChiTietChucNangQuyenDTO chiTietChucNangQuyenDTO)
        {
            var tmp = await _chucNangRepository.GetNameAsync(chiTietChucNangQuyenDTO.TenChucNang);
            if (tmp == null)
            {
                return Ok(new List<string>());
            }
            var chiTietQuyen = _mapper.Map<ChiTietQuyen>(chiTietChucNangQuyenDTO);
            var result = await _chiTietQuyenRepository.CheckQuyenAsync(chiTietQuyen);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateChiTietQuyen([FromBody] ChiTietQuyenDTO chiTietQuyenDTO)
        {
            if (chiTietQuyenDTO == null)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            try
            {
                var chiTietQuyen = _mapper.Map<ChiTietQuyen>(chiTietQuyenDTO);

                var result = await _chiTietQuyenRepository.UpdateAsync(chiTietQuyen);

                if (!result)
                {
                    return StatusCode(500, "Đã xảy ra lỗi khi cập nhật.");
                }
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound($"Không tìm thấy ChiTietQuyen với RoleId {chiTietQuyenDTO.RoleId} và MaChucNang {chiTietQuyenDTO.MaChucNang}. Lỗi: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietQuyen(Guid id)
        {
            try
            {
                var result = await _chiTietQuyenRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ChiTietQuyen with ID {id} not found");
            }

            await _hubContext.Clients.All.SendAsync("loadHanhDong");

            return NoContent();
        }
    }
}
