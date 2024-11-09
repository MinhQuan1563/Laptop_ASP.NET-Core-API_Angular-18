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
    public class NhaCungCapController : Controller
    {
        private readonly INhaCungCapRepository _nhaCungCapRepository;
        private readonly IMapper _mapper;

        public NhaCungCapController(INhaCungCapRepository nhaCungCapRepository, IMapper mapper)
        {
            _nhaCungCapRepository = nhaCungCapRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PaginatedResponse<NhaCungCapDTO>))]
        public async Task<IActionResult> GetAllNhaCungCap(string? search, int skip, int take)
        {
            var (result, totalCount) = await _nhaCungCapRepository.GetAllAsync(search, skip, take);
            var nhaCungCap = _mapper.Map<List<NhaCungCapDTO>>(result);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new PaginatedResponse<NhaCungCapDTO>
            {
                Data = nhaCungCap,
                TotalCount = totalCount
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(NhaCungCap))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetNhaCungCapById(Guid id)
        {
            var nhaCungCap = _mapper.Map<NhaCungCapDTO>(await _nhaCungCapRepository.GetByIdAsync(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(nhaCungCap);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateNhaCungCap(NhaCungCapDTO nhaCungCapDTO)
        {
            if (nhaCungCapDTO == null)
            {
                return BadRequest(ModelState);
            }

            //var nhaCungCap = (await _nhaCungCapRepository.GetAllAsync(""))
            //    .Where(e => e.TenNcc.Trim().ToLower() == nhaCungCapDTO.TenNcc.Trim().ToLower())
            //    .FirstOrDefault();

            //if (nhaCungCap != null)
            //{
            //    ModelState.AddModelError("NhaCungCap already exists");
            //    return StatusCode(422, ModelState);
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nhaCungCapMapper = _mapper.Map<NhaCungCap>(nhaCungCapDTO);

            var result = await _nhaCungCapRepository.CreateAsync(nhaCungCapMapper);

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
        public async Task<IActionResult> UpdateNhaCungCap(Guid id, [FromBody] NhaCungCapDTO nhaCungCapDTO)
        {
            if (nhaCungCapDTO == null)
            {
                return BadRequest(ModelState);
            }

            var nhaCungCapMapper = _mapper.Map<NhaCungCap>(nhaCungCapDTO);

            try
            {
                var result = await _nhaCungCapRepository.UpdateAsync(id, nhaCungCapMapper);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"NhaCungCap with ID {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteNhaCungCap(Guid id)
        {
            try
            {
                var result = await _nhaCungCapRepository.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"NhaCungCap with ID {id} not found");
            }

            return NoContent();
        }
    }
}
