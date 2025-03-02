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
    public class ChipXuLyController : Controller
    {
        private readonly IChipXuLyRepository _chipXuLyRepository;
        private readonly IMapper _mapper;

        public ChipXuLyController(IChipXuLyRepository chipXuLyRepository, IMapper mapper)
        {
            _chipXuLyRepository = chipXuLyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ChipXuLyDTO))]
        public async Task<IActionResult> GetAllChipXuLy(string? search)
        {
            var result = await _chipXuLyRepository.GetAllAsync(search);
            var chipXuLy = _mapper.Map<List<ChipXuLyDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(chipXuLy);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ChipXuLy))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetChipXuLyById(Guid id)
        {
            var chipXuLy = _mapper.Map<ChipXuLyDTO>(await _chipXuLyRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(chipXuLy);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateChipXuLy(ChipXuLyDTO chipXuLyDTO)
        {
            if (chipXuLyDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chipXuLyMapper = _mapper.Map<ChipXuLy>(chipXuLyDTO);

            var result = await _chipXuLyRepository.CreateAsync(chipXuLyMapper);

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
        public async Task<IActionResult> UpdateChipXuLy(Guid id, [FromBody] ChipXuLyDTO chipXuLyDTO)
        {
            if (chipXuLyDTO == null)
            {
                return BadRequest(ModelState);
            }

            var chipXuLyMapper = _mapper.Map<ChipXuLy>(chipXuLyDTO);

            try
            {
                var result = await _chipXuLyRepository.UpdateAsync(id, chipXuLyMapper);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ChipXuLy with ID {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteChipXuLy(Guid id)
        {
            try
            {
                var result = await _chipXuLyRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ChipXuLy with ID {id} not found");
            }

            return NoContent();
        }
    }
}
