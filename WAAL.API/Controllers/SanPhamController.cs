using AutoMapper;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using WAAL.API.Extensions;
using WAAL.Application.DTOs;
using WAAL.Application.Exceptions;
using WAAL.Application.Interfaces;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;
using static System.Net.Mime.MediaTypeNames;

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

        public SanPhamController(
            ISanPhamRepository sanPhamRepository, IMapper mapper, 
            IPhotoService photoService, IThuongHieuRepository thuongHieuRepository,
            ITheLoaiRepository theLoaiRepository, IHeDieuHanhRepository heDieuHanhRepository)
        {
            _sanPhamRepository = sanPhamRepository;
            _mapper = mapper;
            _photoService = photoService;
            _thuongHieuRepository = thuongHieuRepository;
            _theLoaiRepository = theLoaiRepository;
            _heDieuHanhRepository = heDieuHanhRepository;
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
            var result = await _sanPhamRepository.GetAllAsync();
            var sanPham = _mapper.Map<List<SanPhamListDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(sanPham);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(SanPham))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSanPhamById(Guid id)
        {
            var sanPham = _mapper.Map<SanPhamListDTO>(await _sanPhamRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(sanPham);
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

            return NoContent();
        }
    }
}
