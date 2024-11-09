namespace WAAL.Domain.Entities
{
    public class PhieuDoiTra
    {
        public Guid Id { get; set; }
        public DateTime NgayTra { get; set; }
        public int TongSoLuong { get; set; }
        public decimal TongTienTra { get; set; }
        public bool TrangThai { get; set; } = true;
        public ICollection<ThongBao> ThongBaos { get; set; }
        public ICollection<ChiTietPhieuDoiTra> ChiTietPhieuDoiTras { get; set; }
        public AppUser User { get; set; }
        public HoaDon HoaDon { get; set; }
    }
}
