namespace WAAL.Domain.Entities
{
    public class GioHang
    {
        public Guid UserId { get; set; }
        public Guid MaCtsp { get; set; }
        public int SoLuong { get; set; }
        public ChiTietSanPham ChiTietSanPham { get; set; }
        public AppUser User { get; set; }
    }
}
