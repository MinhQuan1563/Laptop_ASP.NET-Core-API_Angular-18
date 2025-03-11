namespace WAAL.Application.DTOs
{
    public class ThongBaoDTO
    {
        public Guid Id { get; set; }
        public Guid? SanPhamId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? HoaDonId { get; set; }
        public Guid? PhieuNhapId { get; set; }
        public Guid? PhieuDoiTraId { get; set; }
        public Guid? PhieuBaoHanhId { get; set; }
        public Guid? NhaCungCapId { get; set; }
        public Guid? KhuyenMaiId { get; set; }
        public string NoiDung { get; set; } = string.Empty;
        public string TieuDe { get; set; } = string.Empty;
        public DateTime NgayDang { get; set; } = DateTime.UtcNow;
    }
}
