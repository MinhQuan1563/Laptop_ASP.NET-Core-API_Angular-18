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
    public class ThongBaoController : Controller
    {
        private readonly IThongBaoRepository _thongBaoRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<MyHub> _hubContext;

        public ThongBaoController(IThongBaoRepository thongBaoRepository, IMapper mapper, IHubContext<MyHub> hubContext)
        {
            _thongBaoRepository = thongBaoRepository;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(ThongBao))]
        public async Task<IActionResult> GetAllThongBao()
        {
            var result = await _thongBaoRepository.GetAllAsync();
            var thongBao = _mapper.Map<List<ThongBaoDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(thongBao);
        }

        [HttpGet("user")]
        [ProducesResponseType(200, Type = typeof(ThongBao))]
        public async Task<IActionResult> GetAllThongBaoByUser(Guid userId)
        {
            var result = await _thongBaoRepository.GetAllByUserAsync(userId);
            var thongBao = _mapper.Map<List<ThongBaoDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(thongBao);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ThongBao))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetThongBaoById(Guid id)
        {
            var thongBao = _mapper.Map<ThongBaoDTO>(await _thongBaoRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(thongBao);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateThongBao(ThongBaoDTO thongBaoDTO)
        {
            if (thongBaoDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var thongBaoMapper = _mapper.Map<ThongBao>(thongBaoDTO);

            var result = await _thongBaoRepository.CreateAsync(thongBaoMapper);

            if (!result)
            {
                ModelState.AddModelError("Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            await _hubContext.Clients.All.SendAsync("updateThongBao");

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> updateThongBao(Guid id, [FromBody] ThongBaoDTO thongBaoDTO)
        {
            if (thongBaoDTO == null)
            {
                return BadRequest(ModelState);
            }

            var thongBaoMapper = _mapper.Map<ThongBao>(thongBaoDTO);

            try
            {
                var result = await _thongBaoRepository.UpdateAsync(id, thongBaoMapper);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ThongBao with ID {id} not found");
            }

            await _hubContext.Clients.All.SendAsync("updateThongBao");

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteThongBao(Guid id)
        {
            try
            {
                var result = await _thongBaoRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"ThongBao with ID {id} not found");
            }

            await _hubContext.Clients.All.SendAsync("updateThongBao");

            return NoContent();
        }
    }
}
