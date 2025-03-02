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
    public class HeDieuHanhController : Controller
    {
        private readonly IHeDieuHanhRepository _heDieuHanhRepository;
        private readonly IMapper _mapper;

        public HeDieuHanhController(IHeDieuHanhRepository heDieuHanhRepository, IMapper mapper)
        {
            _heDieuHanhRepository = heDieuHanhRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(HeDieuHanhDTO))]
        public async Task<IActionResult> GetAllHeDieuHanh(string? search)
        {
            var result = await _heDieuHanhRepository.GetAllAsync(search);
            var heDieuHanh = _mapper.Map<List<HeDieuHanhDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(heDieuHanh);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(HeDieuHanh))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetHeDieuHanhById(Guid id)
        {
            var heDieuHanh = _mapper.Map<HeDieuHanhDTO>(await _heDieuHanhRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(heDieuHanh);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateHeDieuHanh(HeDieuHanhDTO heDieuHanhDTO)
        {
            if (heDieuHanhDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var heDieuHanhMapper = _mapper.Map<HeDieuHanh>(heDieuHanhDTO);

            var result = await _heDieuHanhRepository.CreateAsync(heDieuHanhMapper);

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
        public async Task<IActionResult> UpdateHeDieuHanh(Guid id, [FromBody] HeDieuHanhDTO heDieuHanhDTO)
        {
            if (heDieuHanhDTO == null)
            {
                return BadRequest(ModelState);
            }

            var heDieuHanhMapper = _mapper.Map<HeDieuHanh>(heDieuHanhDTO);

            try
            {
                var result = await _heDieuHanhRepository.UpdateAsync(id, heDieuHanhMapper);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"HeDieuHanh with ID {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteHeDieuHanh(Guid id)
        {
            try
            {
                var result = await _heDieuHanhRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"HeDieuHanh with ID {id} not found");
            }

            return NoContent();
        }
    }
}
