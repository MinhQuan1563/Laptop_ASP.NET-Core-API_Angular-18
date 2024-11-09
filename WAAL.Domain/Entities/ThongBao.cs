namespace WAAL.Domain.Entities
{
    public class ThongBao
    {
        public Guid MaSp { get; set; }
        public Guid UserId { get; set; }
        public Guid MaHd { get; set; }
        public Guid MaPn { get; set; }
        public Guid MaPdt { get; set; }
        public Guid MaPbh { get; set; }
        public Guid MaNcc { get; set; }
        public Guid MaKm { get; set; }
        public string NoiDung { get; set; }
        public bool TrangThai { get; set; } = true;
        public SanPham SanPham { get; set; }
        public AppUser User { get; set; }
        public HoaDon HoaDon { get; set; }
        public PhieuNhap PhieuNhap { get; set; }
        public PhieuDoiTra PhieuDoiTra { get; set; }
        public PhieuBaoHanh PhieuBaoHanh { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        public KhuyenMai KhuyenMai { get; set; }
    }
}
