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
    public class ThuongHieuController : Controller
    {
        private readonly IThuongHieuRepository _thuongHieuRepository;
        private readonly IMapper _mapper;

        public ThuongHieuController(IThuongHieuRepository thuongHieuRepository, IMapper mapper)
        {
            _thuongHieuRepository = thuongHieuRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ThuongHieuDTO))]
        public async Task<IActionResult> GetAllThuongHieu(string? search)
        {
            var result = await _thuongHieuRepository.GetAllAsync(search);
            var thuongHieu = _mapper.Map<List<ThuongHieuDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(thuongHieu);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ThuongHieu))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetThuongHieuById(Guid id)
        {
            var thuongHieu = _mapper.Map<ThuongHieuDTO>(await _thuongHieuRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(thuongHieu);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateThuongHieu(ThuongHieuDTO thuongHieuDTO)
        {
            if (thuongHieuDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var thuongHieuMapper = _mapper.Map<ThuongHieu>(thuongHieuDTO);

            var result = await _thuongHieuRepository.CreateAsync(thuongHieuMapper);

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
        public async Task<IActionResult> UpdateThuongHieu(Guid id, [FromBody] ThuongHieuDTO thuongHieuDTO)
        {
            if (thuongHieuDTO == null)
            {
                return BadRequest(ModelState);
            }

            var thuongHieuMapper = _mapper.Map<ThuongHieu>(thuongHieuDTO);

            try
            {
                var result = await _thuongHieuRepository.UpdateAsync(id, thuongHieuMapper);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ThuongHieu with ID {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteThuongHieu(Guid id)
        {
            try
            {
                var result = await _thuongHieuRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ThuongHieu with ID {id} not found");
            }

            return NoContent();
        }
    }
}
