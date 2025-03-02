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
    public class GioHangController : Controller
    {
        private readonly IGioHangRepository _gioHangRepository;
        private readonly IMapper _mapper;

        public GioHangController(IGioHangRepository gioHangRepository, IMapper mapper)
        {
            _gioHangRepository = gioHangRepository;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllGioHangByUser(Guid userId)
        {
            var result = await _gioHangRepository.GetAllByUserAsync(userId);
            var gioHangList = _mapper.Map<List<GioHangDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(gioHangList);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetGioHangById([FromQuery] Guid maCtsp, [FromQuery] Guid userId)
        {
            var gioHang = await _gioHangRepository.GetByIdAsync(maCtsp, userId);

            if (gioHang == null)
            {
                return NotFound("Không tìm thấy giỏ hàng với các tham số đã cho.");
            }

            var gioHangDto = _mapper.Map<GioHangDTO>(gioHang);

            return Ok(gioHangDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGioHang([FromBody] GioHangDTO gioHangDTO)
        {
            if (gioHangDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gioHang = _mapper.Map<GioHang>(gioHangDTO);

            var result = await _gioHangRepository.CreateAsync(gioHang);

            if (!result)
            {
                ModelState.AddModelError("Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSoLuongGioHang([FromQuery] Guid userId, [FromQuery] Guid maCtsp, [FromBody] int newQuantity)
        {
            if (!ModelState.IsValid || newQuantity < 1)
            {
                ModelState.AddModelError("Invalid Quantity", "Quantity must be a positive integer.");
                return BadRequest(ModelState);
            }


            var result = await _gioHangRepository.UpdateSoLuongAsync(userId, maCtsp, newQuantity);

            if (!result)
            {
                ModelState.AddModelError("Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGioHang([FromQuery] Guid maCtsp, [FromQuery] Guid userId)
        {
            try
            {
                var result = await _gioHangRepository.DeleteAsync(maCtsp, userId);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound("Không tìm thấy giỏ hàng với các tham số đã cho.");
            }

            return NoContent();
        }

        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAllGioHang([FromQuery] Guid userId)
        {
            try
            {
                var result = await _gioHangRepository.DeleteAllAsync(userId);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound("Không tìm thấy giỏ hàng với các tham số đã cho.");
            }

            return NoContent();
        }
    }
}
