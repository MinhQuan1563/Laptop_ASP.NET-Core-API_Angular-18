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
    public class DanhGiaController : Controller
    {
        private readonly IDanhGiaRepository _danhGiaRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<MyHub> _hubContext;

        public DanhGiaController(IDanhGiaRepository danhGiaRepository, IMapper mapper, IHubContext<MyHub> hubContext)
        {
            _danhGiaRepository = danhGiaRepository;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDanhGia()
        {
            var result = await _danhGiaRepository.GetAllAsync();
            var danhGiaList = _mapper.Map<List<DanhGiaDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(danhGiaList);
        }

        [HttpGet("{maSp}")]
        public async Task<IActionResult> GetAllDanhGiaBySanPham(Guid maSp)
        {
            var result = await _danhGiaRepository.GetAllBySanPhamAsync(maSp);
            var danhGiaList = _mapper.Map<List<DanhGiaDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(danhGiaList);
        }

        [HttpGet("pag")]
        [ProducesResponseType(200, Type = typeof(PaginatedResponse<DanhGiaDTO>))]
        public async Task<IActionResult> GetAllPaginationDanhGia(string? search, int skip, int take)
        {
            var (result, totalCount) = await _danhGiaRepository.GetAllPaginationAsync(search, skip, take);
            var danhGia = _mapper.Map<List<DanhGiaDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new PaginatedResponse<DanhGiaDTO>
            {
                Data = danhGia,
                TotalCount = totalCount
            };

            return Ok(response);
        }

        [HttpGet("pag/{maSp}")]
        [ProducesResponseType(200, Type = typeof(PaginatedResponse<DanhGiaDTO>))]
        public async Task<IActionResult> GetAllPaginationDanhGiaBySanPham(Guid maSp, string? search, int skip, int take)
        {
            var (result, totalCount) = await _danhGiaRepository.GetAllPaginationBySanPhamAsync(maSp, search, skip, take);
            var danhGia = _mapper.Map<List<DanhGiaDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new PaginatedResponse<DanhGiaDTO>
            {
                Data = danhGia,
                TotalCount = totalCount
            };

            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetDanhGiaById([FromQuery] Guid maSp, [FromQuery] Guid userId, [FromQuery] DateTime thoiGianDanhGia)
        {
            var danhGia = await _danhGiaRepository.GetByIdAsync(maSp, userId, thoiGianDanhGia);

            if (danhGia == null)
            {
                return NotFound("Không tìm thấy đánh giá với các tham số đã cho.");
            }

            var danhGiaDto = _mapper.Map<DanhGiaDTO>(danhGia);

            return Ok(danhGiaDto);
        }

        [HttpGet("rating/{rating}")]
        public async Task<IActionResult> GetDanhGiaByRating(float rating)
        {
            var result = await _danhGiaRepository.GetByRatingAsync(rating);
            var danhGiaList = _mapper.Map<List<DanhGiaDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(danhGiaList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDanhGia([FromBody] DanhGiaDTO danhGiaDTO)
        {
            if (danhGiaDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var danhGia = _mapper.Map<DanhGia>(danhGiaDTO);

            var result = await _danhGiaRepository.CreateAsync(danhGia);

            if (!result)
            {
                ModelState.AddModelError("Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            await _hubContext.Clients.All.SendAsync("updateDanhGia");

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDanhGia([FromQuery] Guid maSp, [FromQuery] Guid userId, [FromQuery] DateTime thoiGianDanhGia, [FromBody] DanhGiaDTO danhGiaDTO)
        {
            if (danhGiaDTO == null)
            {
                return BadRequest(ModelState);
            }

            var danhGia = _mapper.Map<DanhGia>(danhGiaDTO);

            var result = await _danhGiaRepository.UpdateAsync(maSp, userId, thoiGianDanhGia, danhGia);

            if (!result)
            {
                ModelState.AddModelError("Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            await _hubContext.Clients.All.SendAsync("updateDanhGia");

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDanhGia([FromQuery] Guid maSp, [FromQuery] Guid userId, [FromQuery] DateTime thoiGianDanhGia)
        {
            try
            {
                var result = await _danhGiaRepository.DeleteAsync(maSp, userId, thoiGianDanhGia);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound("Không tìm thấy đánh giá với các tham số đã cho.");
            }

            await _hubContext.Clients.All.SendAsync("updateDanhGia");

            return NoContent();
        }
    }
}
