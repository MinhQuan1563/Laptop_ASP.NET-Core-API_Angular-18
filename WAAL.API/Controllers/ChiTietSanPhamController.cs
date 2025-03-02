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
    public class ChiTietSanPhamController : Controller
    {
        private readonly IChiTietSanPhamRepository _chiTietSanPhamRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<MyHub> _hubContext;
        private readonly ISanPhamRepository _sanPhamRepository;
        private readonly IMauSacRepository _mauSacRepository;
        private readonly ICardDoHoaRepository _cardDoHoaRepository;
        private readonly IChipXuLyRepository _chipXuLyRepository;

        public ChiTietSanPhamController(
            IChiTietSanPhamRepository chiTietSanPhamRepository, IMapper mapper, IHubContext<MyHub> hubContext,
            ISanPhamRepository sanPhamRepository, IMauSacRepository mauSacRepository, 
            ICardDoHoaRepository cardDoHoaRepository, IChipXuLyRepository chipXuLyRepository)
        {
            _chiTietSanPhamRepository = chiTietSanPhamRepository;
            _mapper = mapper;
            _hubContext = hubContext;
            _sanPhamRepository = sanPhamRepository;
            _mauSacRepository = mauSacRepository;
            _cardDoHoaRepository = cardDoHoaRepository;
            _chipXuLyRepository = chipXuLyRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PaginatedResponse<ChiTietSanPhamDTO>))]
        public async Task<IActionResult> GetAllChiTietSanPham(string? search, int skip, int take)
        {
            var (result, totalCount) = await _chiTietSanPhamRepository.GetAllAsync(search, skip, take);
            var chiTietSanPham = _mapper.Map<List<ChiTietSanPhamDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new PaginatedResponse<ChiTietSanPhamDTO>
            {
                Data = chiTietSanPham,
                TotalCount = totalCount
            };

            return Ok(response);
        }

        [HttpGet("sanpham/{maSp}")]
        [ProducesResponseType(200, Type = typeof(PaginatedResponse<ChiTietSanPhamDTO>))]
        public async Task<IActionResult> GetAllChiTietSanPhamBySanPham(Guid maSp, string? search, int skip, int take)
        {
            var (result, totalCount) = await _chiTietSanPhamRepository.GetAllBySanPhamAsync(maSp, search, skip, take);
            var chiTietSanPham = _mapper.Map<List<ChiTietSanPhamDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new PaginatedResponse<ChiTietSanPhamDTO>
            {
                Data = chiTietSanPham,
                TotalCount = totalCount
            };

            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(200, Type = typeof(ChiTietSanPham))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetChiTietSanPhamById(Guid id)
        {
            var chiTietSanPham = _mapper.Map<ChiTietSanPhamDTO>(await _chiTietSanPhamRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(chiTietSanPham);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateChiTietSanPham(ChiTietSanPhamDTO chiTietSanPhamDTO)
        {
            if (chiTietSanPhamDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sanPham = await _sanPhamRepository.GetByIdAsync(chiTietSanPhamDTO.SanPhamId);
            var mauSac = await _mauSacRepository.GetByIdAsync(chiTietSanPhamDTO.MauSacId);
            var cardDoHoa = await _cardDoHoaRepository.GetByIdAsync(chiTietSanPhamDTO.CardDoHoaId);
            var chipXuLy = await _chipXuLyRepository.GetByIdAsync(chiTietSanPhamDTO.ChipXuLyId);

            if (sanPham == null || mauSac == null || cardDoHoa == null || chipXuLy == null)
            {
                return BadRequest("sanPham, mauSac, chipXuLy hoặc cardDoHoa không tồn tại.");
            }

            var chiTietSanPhamMapper = _mapper.Map<ChiTietSanPham>(chiTietSanPhamDTO);

            chiTietSanPhamMapper.SanPham = sanPham;
            chiTietSanPhamMapper.MauSac = mauSac;
            chiTietSanPhamMapper.CardDoHoa = cardDoHoa;
            chiTietSanPhamMapper.ChipXuLy = chipXuLy;

            var result = await _chiTietSanPhamRepository.CreateAsync(chiTietSanPhamMapper);

            if (!result)
            {
                ModelState.AddModelError("Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            await _hubContext.Clients.All.SendAsync("CreateChiTietSanPham");

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateChiTietSanPham(Guid id, [FromBody] ChiTietSanPhamDTO chiTietSanPhamDTO)
        {
            if (chiTietSanPhamDTO == null)
            {
                return BadRequest(ModelState);
            }

            var chiTietSanPhamMapper = _mapper.Map<ChiTietSanPham>(chiTietSanPhamDTO);

            try
            {
                var result = await _chiTietSanPhamRepository.UpdateAsync(id, chiTietSanPhamMapper);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ChiTietSanPham with ID {id} not found");
            }
            await _hubContext.Clients.All.SendAsync("UpdateChiTietSanPham");

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteChiTietSanPham(Guid id)
        {
            try
            {
                var result = await _chiTietSanPhamRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ChiTietSanPham with ID {id} not found");
            }

            return NoContent();
        }
    }
}
