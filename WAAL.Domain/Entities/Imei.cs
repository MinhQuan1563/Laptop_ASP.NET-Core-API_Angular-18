namespace WAAL.Domain.Entities
{
    public class Imei
    {
        public Guid Id { get; set; }
        public bool TrangThai { get; set; } = true;
        public ChiTietSanPham ChiTietSanPham { get; set; }
        public ICollection<ChiTietPhieuBaoHanh> ChiTietPhieuBaoHanhs { get; set; }
        public ICollection<ChiTietPhieuDoiTra> ChiTietPhieuDoiTras { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
