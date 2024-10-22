namespace WAAL.Domain.Entities
{
    public class ThongTinNhanHang
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public bool DiaChiMacDinh { get; set; }
        public bool TrangThai { get; set; } = true;
        public KhachHang KhachHang { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
    }
}
