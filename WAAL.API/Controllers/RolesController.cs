using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAAL.Application.DTOs;
using WAAL.Domain.Entities;

namespace WAAL.API.Controllers
{
    //[Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public RolesController(UserManager<AppUser> userManager, 
            RoleManager<AppRole> roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDTO createRoleDTO)
        {
            if (string.IsNullOrEmpty(createRoleDTO.RoleName))
            {
                return BadRequest("RoleName is required");
            }

            var roleExist = await _roleManager.RoleExistsAsync(createRoleDTO.RoleName);

            if (roleExist)
            {
                return BadRequest("RoleName already exist");
            }

            var roleResult = await _roleManager.CreateAsync(new AppRole(createRoleDTO.RoleName));

            if (roleResult.Succeeded)
            {
                return Ok(new { message = "Role created Successfully" });
            }

            return BadRequest("Role created Fail");
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
                return NotFound("Role not found");
            }

            var result = await _roleManager.DeleteAsync(role);
            if(result.Succeeded)
            {
                return Ok(new { message = "Delete role Successfully" });
            }

            return BadRequest("Delete role Fail");
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole([FromBody] RoleAssignDTO roleAssignDTO)
        {
            var user = await _userManager.FindByIdAsync(roleAssignDTO.UserId.ToString());
            if(user is null)
            {
                return NotFound("User not found");
            }

            var role = await _roleManager.FindByIdAsync(roleAssignDTO.RoleId.ToString());
            if(role is null)
            {
                return NotFound("Role not found");
            }

            var result = await _userManager.AddToRoleAsync(user, role.Name!);
            if(result.Succeeded)
            {
                return Ok(new { message = "Role assigned Successfully" });
            }

            var error = result.Errors.FirstOrDefault();
            return BadRequest(error!.Description);
        }
    }
}
