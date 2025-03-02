using Microsoft.AspNetCore.Identity;

namespace WAAL.Domain.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole() : base() { }
        public AppRole(string roleName) : base(roleName) { }
        public ICollection<ChiTietQuyen> ChiTietQuyens { get; set; } = new HashSet<ChiTietQuyen>();
    }
}
