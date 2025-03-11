using AutoMapper;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
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
    public class SanPhamController : Controller
    {
        private readonly ISanPhamRepository _sanPhamRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly IThuongHieuRepository _thuongHieuRepository;
        private readonly ITheLoaiRepository _theLoaiRepository;
        private readonly IHeDieuHanhRepository _heDieuHanhRepository;
        private readonly IHubContext<MyHub> _hubContext;
        private readonly IDistributedCache _cache;

        public SanPhamController(
            ISanPhamRepository sanPhamRepository, IMapper mapper, IHubContext<MyHub> hubContext,
            IPhotoService photoService, IThuongHieuRepository thuongHieuRepository,
            ITheLoaiRepository theLoaiRepository, IHeDieuHanhRepository heDieuHanhRepository,
            IDistributedCache cache)
        {
            _sanPhamRepository = sanPhamRepository;
            _mapper = mapper;
            _photoService = photoService;
            _thuongHieuRepository = thuongHieuRepository;
            _theLoaiRepository = theLoaiRepository;
            _heDieuHanhRepository = heDieuHanhRepository;
            _hubContext = hubContext;
            _cache = cache;
        }

        [HttpGet("pag")]
        [ProducesResponseType(200, Type = typeof(PaginatedResponse<SanPhamListDTO>))]
        public async Task<IActionResult> GetAllPaginationSanPham(string? search, int skip, int take)
        {
            var (result, totalCount) = await _sanPhamRepository.GetAllPaginationAsync(search, skip, take);
            var sanPham = _mapper.Map<List<SanPhamListDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new PaginatedResponse<SanPhamListDTO>
            {
                Data = sanPham,
                TotalCount = totalCount
            };

            return Ok(response);
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(SanPham))]
        public async Task<IActionResult> GetAllSanPham()
        {
            string cacheKey = "SanPhamList";
            var cachedData = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedData))
            {
                var cachedSanPham = JsonSerializer.Deserialize<List<SanPhamListDTO>>(cachedData);
                return Ok(cachedSanPham);
            }

            var result = await _sanPhamRepository.GetAllAsync();
            var sanPham = _mapper.Map<List<SanPhamListDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };

            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(sanPham), cacheOptions);

            return Ok(sanPham);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(SanPham))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSanPhamById(Guid id)
        {
            string cacheKey = $"SanPham_{id}";
            var cachedSanPham = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedSanPham))
            {
                var sanPham = JsonSerializer.Deserialize<SanPhamListDTO>(cachedSanPham);
                return Ok(sanPham);
            }

            var sanPhamFromDb = await _sanPhamRepository.GetByIdAsync(id);
            if (sanPhamFromDb == null)
            {
                return NotFound();
            }

            var sanPhamDTO = _mapper.Map<SanPhamListDTO>(sanPhamFromDb);

            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            };

            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(sanPhamDTO), cacheOptions);

            return Ok(sanPhamDTO);
        }

        [HttpGet("getByMaCtsp/{maCtsp}")]
        [ProducesResponseType(200, Type = typeof(SanPham))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSanPhamByMaCtsp(Guid maCtsp)
        {
            var sanPham = _mapper.Map<SanPhamListDTO>(await _sanPhamRepository.GetSanPhamByMaCtsp(maCtsp));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(sanPham);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateSanPham([FromForm] SanPhamDTO sanPhamDTO)
        {
            if (sanPhamDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ImageUploadResult? image;

            if (sanPhamDTO.HinhAnh != null)
                image = await _photoService.AddPhotoAsync(sanPhamDTO.HinhAnh);
            else
                image = null;

            var thuongHieu = await _thuongHieuRepository.GetByIdAsync(sanPhamDTO.ThuongHieuId);
            var theLoai = await _theLoaiRepository.GetByIdAsync(sanPhamDTO.TheLoaiId);
            var heDieuHanh = await _heDieuHanhRepository.GetByIdAsync(sanPhamDTO.HeDieuHanhId);

            if (thuongHieu == null || theLoai == null || heDieuHanh == null)
            {
                return BadRequest("ThuongHieu, TheLoai hoặc HeDieuHanh không tồn tại.");
            }

            var sanPham = _mapper.Map<SanPham>(sanPhamDTO);

            sanPham.ThuongHieu = thuongHieu;
            sanPham.TheLoai = theLoai;
            sanPham.HeDieuHanh = heDieuHanh;
            sanPham.HinhAnh = image?.Url?.ToString() ?? "";

            var result = await _sanPhamRepository.CreateAsync(sanPham);

            if (!result)
            {
                ModelState.AddModelError("Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            await _cache.RemoveAsync("SanPhamList");
            await _hubContext.Clients.All.SendAsync("updateSanPham");

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateSanPham(Guid id, [FromForm] SanPhamDTO sanPhamDTO)
        {
            if (sanPhamDTO == null)
            {
                return BadRequest(ModelState);
            }

            var existingSanPham = await _sanPhamRepository.GetByIdAsync(id);
            if (existingSanPham == null)
            {
                return NotFound($"SanPham with ID {id} not found");
            }

            var thuongHieu = await _thuongHieuRepository.GetByIdAsync(sanPhamDTO.ThuongHieuId);
            var theLoai = await _theLoaiRepository.GetByIdAsync(sanPhamDTO.TheLoaiId);
            var heDieuHanh = await _heDieuHanhRepository.GetByIdAsync(sanPhamDTO.HeDieuHanhId);

            if (thuongHieu == null || theLoai == null || heDieuHanh == null)
            {
                return BadRequest("ThuongHieu, TheLoai hoặc HeDieuHanh không tồn tại.");
            }

            // Nếu có ảnh mới, xoá ảnh cũ trước khi cập nhật
            if (sanPhamDTO.HinhAnh != null)
            {
                if (!string.IsNullOrEmpty(existingSanPham.HinhAnh))
                {
                    await _photoService.DeletePhotoAsync(existingSanPham.HinhAnh);
                }

                var image = await _photoService.AddPhotoAsync(sanPhamDTO.HinhAnh);
                existingSanPham.HinhAnh = image?.Url?.ToString() ?? "";
            }

            existingSanPham.ThuongHieu = thuongHieu;
            existingSanPham.TheLoai = theLoai;
            existingSanPham.HeDieuHanh = heDieuHanh;

            var sanPhamMapper = _mapper.Map(sanPhamDTO, existingSanPham);

            var result = await _sanPhamRepository.UpdateAsync(id, sanPhamMapper);

            if (!result)
            {
                ModelState.AddModelError("Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            await _cache.RemoveAsync($"SanPham_{id}");
            await _cache.RemoveAsync("SanPhamList");
            await _hubContext.Clients.All.SendAsync("updateSanPham");

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteSanPham(Guid id)
        {
            try
            {
                var result = await _sanPhamRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"SanPham with ID {id} not found");
            }

            await _cache.RemoveAsync($"SanPham_{id}");
            await _cache.RemoveAsync("SanPhamList");
            await _hubContext.Clients.All.SendAsync("updateSanPham");

            return NoContent();
        }
    }
}
