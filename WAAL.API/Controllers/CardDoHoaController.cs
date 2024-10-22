using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using WAAL.API.Extensions;
using WAAL.Application.DTOs;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardDoHoaController : Controller
    {
        private readonly ICardDoHoaRepository _cardDoHoaRepository;
        private readonly IMapper _mapper;

        public CardDoHoaController(ICardDoHoaRepository cardDoHoaRepository, IMapper mapper)
        {
            _cardDoHoaRepository = cardDoHoaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CardDoHoa>))]
        public async Task<IActionResult> GetAllCardDoHoa(string? search)
        {
            var cardDoHoa = _mapper.Map<List<CardDoHoaDTO>>(await _cardDoHoaRepository.GetAllAsync(search));

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(cardDoHoa);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CardDoHoa))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCardDoHoaById(int id)
        {
            var cardDoHoa = _mapper.Map<CardDoHoaDTO>(await _cardDoHoaRepository.GetByIdAsync(id));

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(cardDoHoa);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCardDoHoa(CardDoHoaDTO cardDoHoaDTO)
        {
            if(cardDoHoaDTO == null)
            {
                return BadRequest(ModelState);
            }

            var cardDoHoa = (await _cardDoHoaRepository.GetAllAsync(""))
                .Where(e => e.TenCard.Trim().ToLower() == cardDoHoaDTO.TenCard.Trim().ToLower())
                .FirstOrDefault();

            if(cardDoHoa != null)
            {
                ModelState.AddModelError("CardDoHoa already exists");
                return StatusCode(422, ModelState);
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cardDoHoaMapper = _mapper.Map<CardDoHoa>(cardDoHoaDTO);

            var result = await _cardDoHoaRepository.CreateAsync(cardDoHoaMapper);

            if(!result)
            {
                ModelState.AddModelError("Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateCardDoHoa(int id, [FromBody] CardDoHoaDTO cardDoHoaDTO)
        {
            if(id == 0 || cardDoHoaDTO == null)
            {
                return BadRequest(ModelState);
            }

            var cardDoHoaMapper = _mapper.Map<CardDoHoa>(cardDoHoaDTO);

            try
            {
                var result = await _cardDoHoaRepository.UpdateAsync(id, cardDoHoaMapper);
                if(!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch(EntityNotFoundException)
            {
                return NotFound($"CardDoHoa with ID {id} not found");
            }
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCardDoHoa(int id)
        {
            try
            {
                var result = await _cardDoHoaRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"CardDoHoa with ID {id} not found");
            }

            return NoContent();
        }
    }
}
