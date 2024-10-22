namespace WAAL.Domain.Entities
{
    public class KhachHang
    {
        public int Id { get; set; }
        public string TenKh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public bool TrangThai { get; set; } = true;
        public ICollection<ThongTinNhanHang> ThongTinNhanHangs { get; set; }
        public ICollection<ThongBao> ThongBaos { get; set; }
        public ICollection<DanhGia> DanhGias { get; set; }
        public ICollection<PhieuBaoHanh> PhieuBaoHanhs { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
        public ICollection<GioHang> GioHangs { get; set; }
    }
}
