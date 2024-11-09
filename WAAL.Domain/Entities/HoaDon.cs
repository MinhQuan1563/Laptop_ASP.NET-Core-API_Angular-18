namespace WAAL.Domain.Entities
{
    public class HoaDon
    {
        public Guid Id { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public bool TrangThai { get; set; } = true;
        public ICollection<ThongBao> ThongBaos { get; set; }
        public ICollection<PhieuDoiTra> PhieuDoiTras { get; set; }
        public ICollection<PhieuBaoHanh> PhieuBaoHanhs { get; set; }
        public ICollection<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public AppUser User { get; set; }
        public ThongTinNhanHang ThongTinNhanHang { get; set; }
    }
}
