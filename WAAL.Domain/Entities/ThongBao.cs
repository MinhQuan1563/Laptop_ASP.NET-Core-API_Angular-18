namespace WAAL.Domain.Entities
{
    public class ThongBao
    {
        public Guid Id { get; set; }
        public string TieuDe { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;
        public DateTime NgayDang { get; set; } = DateTime.UtcNow;
        public bool TrangThai { get; set; } = true;
        // 
        public Guid? SanPhamId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? HoaDonId { get; set; }
        public Guid? PhieuNhapId { get; set; }
        public Guid? PhieuDoiTraId { get; set; }
        public Guid? PhieuBaoHanhId { get; set; }
        public Guid? NhaCungCapId { get; set; }
        public Guid? KhuyenMaiId { get; set; }
        // 
        public SanPham? SanPham { get; set; }
        public AppUser? User { get; set; }
        public HoaDon? HoaDon { get; set; }
        public PhieuNhap? PhieuNhap { get; set; }
        public PhieuDoiTra? PhieuDoiTra { get; set; }
        public PhieuBaoHanh? PhieuBaoHanh { get; set; }
        public NhaCungCap? NhaCungCap { get; set; }
        public KhuyenMai? KhuyenMai { get; set; }
    }
}
