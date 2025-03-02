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
    public class ChucNangController : Controller
    {
        private readonly IChucNangRepository _chucNangRepository;
        private readonly IMapper _mapper;

        public ChucNangController(IChucNangRepository chucNangRepository, IMapper mapper)
        {
            _chucNangRepository = chucNangRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ChucNang>))]
        public async Task<IActionResult> GetAllChucNang()
        {
            var chucNang = _mapper.Map<List<ChucNangDTO>>(await _chucNangRepository.GetAllAsync());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(chucNang);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ChucNang))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetChucNangById(Guid id)
        {
            var chucNang = _mapper.Map<ChucNangDTO>(await _chucNangRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(chucNang);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateChucNang(ChucNangDTO chucNangDTO)
        {
            if (chucNangDTO == null)
            {
                return BadRequest(ModelState);
            }

            var chucNang = (await _chucNangRepository.GetAllAsync())
                .Where(e => e.TenChucNang.Trim().ToLower() == chucNangDTO.TenChucNang.Trim().ToLower())
                .FirstOrDefault();

            if (chucNang != null)
            {
                ModelState.AddModelError("ChucNang already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chucNangMapper = _mapper.Map<ChucNang>(chucNangDTO);

            var result = await _chucNangRepository.CreateAsync(chucNangMapper);

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
        public async Task<IActionResult> UpdateChucNang(Guid id, [FromBody] ChucNangDTO chucNangDTO)
        {
            if (chucNangDTO == null)
            {
                return BadRequest(ModelState);
            }

            var chucNangMapper = _mapper.Map<ChucNang>(chucNangDTO);

            try
            {
                var result = await _chucNangRepository.UpdateAsync(id, chucNangMapper);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ChucNang with ID {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteChucNang(Guid id)
        {
            try
            {
                var result = await _chucNangRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ChucNang with ID {id} not found");
            }

            return NoContent();
        }
    }
}
