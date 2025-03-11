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
    public class TinNhanController : Controller
    {
        private readonly ITinNhanRepository _tinNhanRepository;
        private readonly ICuocTroChuyenRepository _cuocTroChuyenRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<MyHub> _hubContext;

        public TinNhanController(
            ITinNhanRepository tinNhanRepository, IMapper mapper, 
            IHubContext<MyHub> hubContext, ICuocTroChuyenRepository cuocTroChuyenRepository
            )
        {
            _tinNhanRepository = tinNhanRepository;
            _cuocTroChuyenRepository = cuocTroChuyenRepository;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TinNhan))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTinNhanByConversationId(Guid id)
        {
            var tinNhanDTOs = _mapper.Map<IEnumerable<TinNhanDTO>>(await _tinNhanRepository.GetByConversationIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(tinNhanDTOs);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTinNhan(TinNhanDTO tinNhanDTO)
        {
            if (tinNhanDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tinNhan = _mapper.Map<TinNhan>(tinNhanDTO);

            var result = await _tinNhanRepository.CreateAsync(tinNhan);

            if (!result)
            {
                ModelState.AddModelError("Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            var cuocTroChuyen = await _cuocTroChuyenRepository.GetByIdAsync(tinNhan.CuocTroChuyenId);
            var nguoiNhanId = tinNhan.NguoiGuiId == cuocTroChuyen.KhachHangId ? cuocTroChuyen.NhanVienHoTroId : cuocTroChuyen.KhachHangId;

            await _hubContext.Clients.User(nguoiNhanId.ToString()).SendAsync("ReceiveMessage", tinNhan.NguoiGuiId, tinNhan.NoiDung);

            return CreatedAtAction(nameof(GetTinNhanByConversationId), new { id = tinNhan.CuocTroChuyenId }, tinNhan);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteTinNhan(Guid id)
        {
            try
            {
                var result = await _tinNhanRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"TinNhan with ID {id} not found");
            }

            return NoContent();
        }
    }
}
