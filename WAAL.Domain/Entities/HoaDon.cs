namespace WAAL.Domain.Entities
{
    public class HoaDon
    {
        public int Id { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public bool TrangThai { get; set; }
        public ICollection<ThongBao> ThongBaos { get; set; }
        public ICollection<PhieuDoiTra> PhieuDoiTras { get; set; }
        public ICollection<PhieuBaoHanh> PhieuBaoHanhs { get; set; }
        public ICollection<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public KhachHang KhachHang { get; set; }
        public NhanVien NhanVien { get; set; }
        public ThongTinNhanHang ThongTinNhanHang { get; set; }
    }
}
