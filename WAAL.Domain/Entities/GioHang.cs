namespace WAAL.Domain.Entities
{
    public class GioHang
    {
        public int MaKh { get; set; }
        public int MaCtsp { get; set; }
        public int SoLuong { get; set; }
        public ChiTietSanPham ChiTietSanPham { get; set; }
        public KhachHang KhachHang { get; set; }
    }
}
