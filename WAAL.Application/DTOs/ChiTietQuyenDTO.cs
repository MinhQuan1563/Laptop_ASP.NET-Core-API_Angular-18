namespace WAAL.Application.DTOs
{
    public class ChiTietQuyenDTO
    {
        public Guid MaChucNang { get; set; }
        public Guid RoleId { get; set; }
        public string HanhDong { get; set; }
    }

    public class ChiTietMaQuyenDTO
    {
        public Guid MaChucNang { get; set; }
        public Guid RoleId { get; set; }
    }

    public class ChiTietTenQuyenDTO
    {
        public string TenChucNang { get; set; }
        public string TenRole { get; set; }
        public string HanhDong { get; set; }
    }
}
