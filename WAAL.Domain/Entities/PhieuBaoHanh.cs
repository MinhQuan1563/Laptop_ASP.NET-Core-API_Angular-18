namespace WAAL.Domain.Entities
{
    public class PhieuBaoHanh
    {
        public int Id { get; set; }
        public DateTime NgayBaoHanh { get; set; }
        public DateTime NgayTra { get; set; }
        public string TinhTrang { get; set; }
        public bool TrangThai { get; set; }
        public NhanVien NhanVien { get; set; }
        public ICollection<ThongBao> ThongBaos { get; set; }
        public ICollection<ChiTietPhieuBaoHanh> ChiTietPhieuBaoHanhs { get; set; }
        public KhachHang KhachHang { get; set; }
        public HoaDon HoaDon { get; set; }
    }
}
