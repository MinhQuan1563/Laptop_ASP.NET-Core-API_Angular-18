using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WAAL.API.Extensions;
using WAAL.API.Hubs;
using WAAL.Application.DTOs;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuyenMaiController : Controller
    {
        private readonly IKhuyenMaiRepository _khuyenMaiRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<MyHub> _hubContext;

        public KhuyenMaiController(IKhuyenMaiRepository khuyenMaiRepository, IMapper mapper, IHubContext<MyHub> hubContext)
        {
            _khuyenMaiRepository = khuyenMaiRepository;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpGet("pag")]
        [ProducesResponseType(200, Type = typeof(PaginatedResponse<KhuyenMaiDTO>))]
        public async Task<IActionResult> GetAllPaginationKhuyenMai(string? search, int skip, int take)
        {
            var (result, totalCount) = await _khuyenMaiRepository.GetAllPaginationAsync(search, skip, take);
            var khuyenMai = _mapper.Map<List<KhuyenMaiDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new PaginatedResponse<KhuyenMaiDTO>
            {
                Data = khuyenMai,
                TotalCount = totalCount
            };

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(KhuyenMaiDTO))]
        public async Task<IActionResult> GetAllKhuyenMai(string? search)
        {
            var result = await _khuyenMaiRepository.GetAllAsync(search);
            var khuyenMai = _mapper.Map<List<KhuyenMaiDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(KhuyenMai))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetKhuyenMaiById(Guid id)
        {
            var khuyenMai = _mapper.Map<KhuyenMaiDTO>(await _khuyenMaiRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(khuyenMai);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateKhuyenMai(KhuyenMaiDTO khuyenMaiDTO)
        {
            if (khuyenMaiDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var khuyenMaiMapper = _mapper.Map<KhuyenMai>(khuyenMaiDTO);

            var result = await _khuyenMaiRepository.CreateAsync(khuyenMaiMapper);

            if (!result)
            {
                ModelState.AddModelError("Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            await _hubContext.Clients.All.SendAsync("CreateKhuyenMai");

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateKhuyenMai(Guid id, [FromBody] KhuyenMaiDTO khuyenMaiDTO)
        {
            if (khuyenMaiDTO == null)
            {
                return BadRequest(ModelState);
            }

            var khuyenMaiMapper = _mapper.Map<KhuyenMai>(khuyenMaiDTO);

            try
            {
                var result = await _khuyenMaiRepository.UpdateAsync(id, khuyenMaiMapper);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"KhuyenMai with ID {id} not found");
            }
            await _hubContext.Clients.All.SendAsync("UpdateKhuyenMai");

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteKhuyenMai(Guid id)
        {
            try
            {
                var result = await _khuyenMaiRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"KhuyenMai with ID {id} not found");
            }

            return NoContent();
        }
    }
}
