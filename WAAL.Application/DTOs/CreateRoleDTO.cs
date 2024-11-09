using System.ComponentModel.DataAnnotations;

namespace WAAL.Application.DTOs
{
    public class CreateRoleDTO
    {
        [Required]
        public string RoleName { get; set; }
    }
}
