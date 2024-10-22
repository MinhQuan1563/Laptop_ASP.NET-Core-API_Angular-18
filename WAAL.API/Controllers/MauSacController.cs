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
    public class MauSacController : Controller
    {
        private readonly IMauSacRepository _mauSacRepository;
        private readonly IMapper _mapper;

        public MauSacController(IMauSacRepository mauSacRepository, IMapper mapper)
        {
            _mauSacRepository = mauSacRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MauSac>))]
        public async Task<IActionResult> GetAllMauSac(string? search)
        {
            var mauSac = _mapper.Map<List<MauSacDTO>>(await _mauSacRepository.GetAllAsync(search));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(mauSac);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(MauSac))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetMauSacById(int id)
        {
            var mauSac = _mapper.Map<MauSacDTO>(await _mauSacRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(mauSac);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateMauSac(MauSacDTO mauSacDTO)
        {
            if (mauSacDTO == null)
            {
                return BadRequest(ModelState);
            }

            var mauSac = (await _mauSacRepository.GetAllAsync(""))
                .Where(e => e.TenMau.Trim().ToLower() == mauSacDTO.TenMau.Trim().ToLower())
                .FirstOrDefault();

            if (mauSac != null)
            {
                ModelState.AddModelError("MauSac already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mauSacMapper = _mapper.Map<MauSac>(mauSacDTO);

            var result = await _mauSacRepository.CreateAsync(mauSacMapper);

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
        public async Task<IActionResult> UpdateMauSac(int id, [FromBody] MauSacDTO mauSacDTO)
        {
            if (id == 0 || mauSacDTO == null)
            {
                return BadRequest(ModelState);
            }

            var mauSacMapper = _mapper.Map<MauSac>(mauSacDTO);

            try
            {
                var result = await _mauSacRepository.UpdateAsync(id, mauSacMapper);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"MauSac with ID {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteMauSac(int id)
        {
            try
            {
                var result = await _mauSacRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"MauSac with ID {id} not found");
            }

            return NoContent();
        }
    }
}
