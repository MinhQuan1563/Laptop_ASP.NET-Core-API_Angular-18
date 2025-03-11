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
    public class CuocTroChuyenController : Controller
    {
        private readonly ICuocTroChuyenRepository _cuocTroChuyenRepository;
        private readonly IMapper _mapper;

        public CuocTroChuyenController(ICuocTroChuyenRepository cuocTroChuyenRepository, IMapper mapper)
        {
            _cuocTroChuyenRepository = cuocTroChuyenRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(CuocTroChuyenDTO))]
        public async Task<IActionResult> GetAllCuocTroChuyen()
        {
            var result = await _cuocTroChuyenRepository.GetAllAsync();
            var cuocTroChuyen = _mapper.Map<List<CuocTroChuyenDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(cuocTroChuyen);
        }

        [HttpGet("nhanvien/{nvId}")]
        [ProducesResponseType(200, Type = typeof(CuocTroChuyenDTO))]
        public async Task<IActionResult> GetAllCuocTroChuyenByNhanVienId(Guid nvId)
        {
            var result = await _cuocTroChuyenRepository.GetAllByNhanVienIdAsync(nvId);
            var cuocTroChuyen = _mapper.Map<List<CuocTroChuyenDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(cuocTroChuyen);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CuocTroChuyen))]
        [ProducesResponseType(400)]
            public async Task<IActionResult> GetCuocTroChuyenById(Guid id)
            {
                var cuocTroChuyen = _mapper.Map<CuocTroChuyenDTO>(await _cuocTroChuyenRepository.GetByIdAsync(id));

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(cuocTroChuyen);
            }

        [HttpGet("khachhang/{khId}/nhanvien/{nvId}")]
        [ProducesResponseType(200, Type = typeof(CuocTroChuyen))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCuocTroChuyenByAllId(Guid khId, Guid nvId)   
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cuocTroChuyen = await _cuocTroChuyenRepository.GetByAllIdAsync(khId, nvId);

            if (cuocTroChuyen == null)
            {
                return Ok(new { });
            }

            return Ok(_mapper.Map<CuocTroChuyenDTO>(cuocTroChuyen));
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCuocTroChuyen(CuocTroChuyenDTO cuocTroChuyenDTO)
        {
            if (cuocTroChuyenDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cuocTroChuyenMapper = _mapper.Map<CuocTroChuyen>(cuocTroChuyenDTO);

            var result = await _cuocTroChuyenRepository.CreateAsync(cuocTroChuyenMapper);

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
        public async Task<IActionResult> UpdateCuocTroChuyen(Guid id, [FromBody] CuocTroChuyenCreateDTO cuocTroChuyenDTO)
        {
            if (cuocTroChuyenDTO == null)
            {
                return BadRequest(ModelState);
            }

            var cuocTroChuyenMapper = _mapper.Map<CuocTroChuyen>(cuocTroChuyenDTO);

            try
            {
                var result = await _cuocTroChuyenRepository.UpdateAsync(id, cuocTroChuyenMapper);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"CuocTroChuyen with ID {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCuocTroChuyen(Guid id)
        {
            try
            {
                var result = await _cuocTroChuyenRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"CuocTroChuyen with ID {id} not found");
            }

            return NoContent();
        }
    }
}
