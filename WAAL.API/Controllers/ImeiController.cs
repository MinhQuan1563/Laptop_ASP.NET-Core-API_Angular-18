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
    public class ImeiController : Controller
    {
        private readonly IImeiRepository _imeiRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<MyHub> _hubContext;
        private readonly IChiTietSanPhamRepository _chiTietSanPhamRepository;

        public ImeiController(
            IImeiRepository imeiRepository, IMapper mapper, 
            IHubContext<MyHub> hubContext, IChiTietSanPhamRepository chiTietSanPhamRepository)
        {
            _imeiRepository = imeiRepository;
            _mapper = mapper;
            _hubContext = hubContext;
            _chiTietSanPhamRepository = chiTietSanPhamRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ImeiDTO))]
        public async Task<IActionResult> GetAllImei()
        {
            var result = await _imeiRepository.GetAllAsync();
            var imei = _mapper.Map<List<ImeiDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(imei);
        }

        [HttpGet("getByCtsp")]
        [ProducesResponseType(200, Type = typeof(ImeiDTO))]
        public async Task<IActionResult> GetAllByMaCTSPImei([FromQuery] Guid maCtsp, [FromQuery] int soLuong)
        {
            var result = await _imeiRepository.GetAllByMaCTSPAsync(maCtsp, soLuong);
            var imei = _mapper.Map<List<ImeiDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(imei);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Imei))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetImeiById(Guid id)
        {
            var imei = _mapper.Map<ImeiDTO>(await _imeiRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(imei);
        }

        [HttpGet("getByCtsp/{maCtsp}")]
        [ProducesResponseType(200, Type = typeof(Imei))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetImeiByMaCtsp(Guid maCtsp)
        {
            var imei = _mapper.Map<ImeiDTO>(await _imeiRepository.GetByMaCtspAsync(maCtsp));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(imei);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateImei(ImeiDTO imeiDTO)
        {
            if (imeiDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chitietsanpham = await _chiTietSanPhamRepository.GetByIdAsync(imeiDTO.ChiTietSanPhamId);

            if(chitietsanpham == null) { return BadRequest(ModelState); }

            var imeiMapper = _mapper.Map<Imei>(imeiDTO);

            imeiMapper.ChiTietSanPham = chitietsanpham;

            var result = await _imeiRepository.CreateAsync(imeiMapper);

            if (!result)
            {
                ModelState.AddModelError("Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            await _hubContext.Clients.All.SendAsync("updateImei");

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> updateImei(Guid id, [FromBody] ImeiDTO imeiDTO)
        {
            if (imeiDTO == null)
            {
                return BadRequest(ModelState);
            }

            var chitietsanpham = await _chiTietSanPhamRepository.GetByIdAsync(imeiDTO.ChiTietSanPhamId);

            if (chitietsanpham == null) { return BadRequest(ModelState); }

            var imeiMapper = _mapper.Map<Imei>(imeiDTO);

            imeiMapper.ChiTietSanPham = chitietsanpham;

            try
            {
                var result = await _imeiRepository.UpdateAsync(id, imeiMapper);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"Imei with ID {id} not found");
            }

            await _hubContext.Clients.All.SendAsync("updateImei");

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteImei(Guid id)
        {
            try
            {
                var result = await _imeiRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"Imei with ID {id} not found");
            }

            await _hubContext.Clients.All.SendAsync("updateImei");

            return NoContent();
        }
    }
}
