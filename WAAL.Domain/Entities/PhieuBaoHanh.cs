namespace WAAL.Domain.Entities
{
    public class PhieuBaoHanh
    {
        public Guid Id { get; set; }
        public DateTime NgayBaoHanh { get; set; }
        public DateTime NgayTra { get; set; }
        public string TinhTrang { get; set; }
        public bool TrangThai { get; set; } = true;
        public AppUser User { get; set; }
        public ICollection<ThongBao> ThongBaos { get; set; }
        public ICollection<ChiTietPhieuBaoHanh> ChiTietPhieuBaoHanhs { get; set; }
        public HoaDon HoaDon { get; set; }
    }
}
