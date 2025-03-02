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
    public class TheLoaiController : Controller
    {
        private readonly ITheLoaiRepository _theLoaiRepository;
        private readonly IMapper _mapper;

        public TheLoaiController(ITheLoaiRepository theLoaiRepository, IMapper mapper)
        {
            _theLoaiRepository = theLoaiRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(TheLoaiDTO))]
        public async Task<IActionResult> GetAllTheLoai(string? search)
        {
            var result = await _theLoaiRepository.GetAllAsync(search);
            var theLoai = _mapper.Map<List<TheLoaiDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(theLoai);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TheLoai))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTheLoaiById(Guid id)
        {
            var theLoai = _mapper.Map<TheLoaiDTO>(await _theLoaiRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(theLoai);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTheLoai(TheLoaiDTO theLoaiDTO)
        {
            if (theLoaiDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var theLoaiMapper = _mapper.Map<TheLoai>(theLoaiDTO);

            var result = await _theLoaiRepository.CreateAsync(theLoaiMapper);

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
        public async Task<IActionResult> UpdateTheLoai(Guid id, [FromBody] TheLoaiDTO theLoaiDTO)
        {
            if (theLoaiDTO == null)
            {
                return BadRequest(ModelState);
            }

            var theLoaiMapper = _mapper.Map<TheLoai>(theLoaiDTO);

            try
            {
                var result = await _theLoaiRepository.UpdateAsync(id, theLoaiMapper);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"TheLoai with ID {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteTheLoai(Guid id)
        {
            try
            {
                var result = await _theLoaiRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"TheLoai with ID {id} not found");
            }

            return NoContent();
        }
    }
}
