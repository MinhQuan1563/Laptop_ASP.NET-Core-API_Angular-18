using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WAAL.Application.DTOs;
using WAAL.Domain.Entities;

namespace WAAL.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AccountController(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            IConfiguration configuration,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        // api/account/register
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegisterDTO registerDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<AppUser>(registerDTO);

            user.UserName = registerDTO.Email;

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if(!result.Succeeded)
            {
                return  BadRequest(result.Errors);
            }

            await _userManager.AddToRoleAsync(user, "User");

            return Ok(new AuthResponseDTO()
            {
                Message = "Account Created Successfully!",
                IsSuccess = true
            });

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDTO>> Login(LoginDTO loginDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if(user == null)
            {
                return Unauthorized(new AuthResponseDTO
                {
                    IsSuccess = false,
                    Message = "Không tìm thấy người dùng với email này !!"
                });
            }

            var result = await _userManager.CheckPasswordAsync(user, loginDTO.Password);

            if(!result)
            {
                return Unauthorized(new AuthResponseDTO
                {
                    IsSuccess = false,
                    Message = "Mật khẩu không hợp lệ !!"
                });
            }

            var token = GenerateToken(user);

            return Ok(new AuthResponseDTO()
            {
                Token = await token,
                IsSuccess = true,
                Message = "Đăng nhập thành công"
            });
        }

        private async Task<string> GenerateToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII
                .GetBytes(_configuration.GetSection("JwtSettings").GetSection("Key").Value!);

            var roles = await _userManager.GetRolesAsync(user);

            List<Claim> claims =
            [
                new (JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new (JwtRegisteredClaimNames.Name, user.HoTen ?? ""),
                new (JwtRegisteredClaimNames.NameId, user.Id.ToString() ?? ""),
                new (JwtRegisteredClaimNames.Aud, 
                    _configuration.GetSection("JwtSettings").GetSection("Audience").Value!),
                new (JwtRegisteredClaimNames.Iss,
                    _configuration.GetSection("JwtSettings").GetSection("Issuer").Value!)
            ];

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        [HttpGet("detail")]
        public async Task<ActionResult<UserDetailDTO>> GetUserDetail()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(currentUserId!);

            if(user is null)
            {
                return NotFound(new AuthResponseDTO
                {
                    IsSuccess = false,
                    Message = "Không tìm thấy người dùng"
                });
            }

            return Ok(new UserDetailDTO
            {
                Id = user.Id,
                FullName = user.HoTen,
                Email = user.Email,
                Roles = [..await _userManager.GetRolesAsync(user)],
                PhoneNumber = user.PhoneNumber,
                TwoFactorEnabled = user.TwoFactorEnabled,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                AccessFailedCount = user.AccessFailedCount,
            });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetailDTO>>> GetUsers()
        {
            var users = await _userManager.Users
                .Select(u => new UserDetailDTO
                {
                    Id = u.Id,
                    FullName = u.HoTen,
                    Email = u.Email
                }).ToListAsync();

            foreach(var user in users)
            {
                var roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(user.Id.ToString()));
                user.Roles = roles.ToArray();
            }

            return Ok(users);
        }
    }
}
