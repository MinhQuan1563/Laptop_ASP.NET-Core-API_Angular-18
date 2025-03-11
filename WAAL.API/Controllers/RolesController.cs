using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAAL.Application.DTOs;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.API.Controllers
{
    //[Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IChucNangRepository _chucNangRepository;
        private readonly IChiTietQuyenRepository _chiTietQuyenRepository;
        private readonly IMapper _mapper;

        public RolesController(UserManager<AppUser> userManager, 
            RoleManager<AppRole> roleManager,
            IChucNangRepository chucNangRepository,
            IChiTietQuyenRepository chiTietQuyenRepository,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _chucNangRepository = chucNangRepository;
            _chiTietQuyenRepository = chiTietQuyenRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDTO createRoleDTO)
        {
            if (string.IsNullOrEmpty(createRoleDTO.RoleName))
            {
                return BadRequest("Tên vai trò là bắt buộc");
            }

            var roleExist = await _roleManager.RoleExistsAsync(createRoleDTO.RoleName);

            if (roleExist)
            {
                return BadRequest("Tên vai trò đã tồn tại");
            }

            var newRole = new AppRole(createRoleDTO.RoleName);
            var roleResult = await _roleManager.CreateAsync(newRole);

            if (!roleResult.Succeeded)
            {
                return BadRequest("Tạo vai trò thất bại");
            }

            return Ok(new { message = "Tạo vai trò thành công" });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleResponseDTO>>> getUsers()
        {
            var roles = await _roleManager.Roles
                .Select(r => new RoleResponseDTO
                {
                    Id = r.Id,
                    RoleName = r.Name!
                }).ToListAsync();

            foreach (var role in roles)
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(role.RoleName);
                role.TotalUsers = usersInRole.Count;
            }

            return Ok(roles);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if(role is null)
            {
                return NotFound("Không tìm thấy vai trò");
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return Ok(new { message = "Xóa vai trò thành công" });
            }

            return BadRequest("Xóa vai trò thất bại");
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole([FromBody] RoleAssignDTO roleAssignDTO)
        {
            var user = await _userManager.FindByIdAsync(roleAssignDTO.UserId.ToString());
            if (user is null)
            {
                return NotFound("Không tìm thấy người dùng");
            }

            var role = await _roleManager.FindByIdAsync(roleAssignDTO.RoleId.ToString());
            if (role is null)
            {
                return NotFound("Không tìm thấy vai trò");
            }

            var result = await _userManager.AddToRoleAsync(user, role.Name!);
            if (result.Succeeded)
            {
                return Ok(new { message = "Gán vai trò thành công" });
            }

            var error = result.Errors.FirstOrDefault();
            return BadRequest(error!.Description);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleResponseDTO>> GetRoleById(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                return NotFound("Không tìm thấy vai trò");
            }

            var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name!);

            var roleDto = new RoleResponseDTO
            {
                Id = role.Id,
                RoleName = role.Name!,
                TotalUsers = usersInRole.Count
            };

            return Ok(roleDto);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetRolesByUserId(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return NotFound("Không tìm thấy người dùng");
            }

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(roles);
        }
    }
}
