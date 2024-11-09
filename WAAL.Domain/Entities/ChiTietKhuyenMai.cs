namespace WAAL.Domain.Entities
{
    public class ChiTietKhuyenMai
    {
        public Guid MaKm { get; set; }
        public Guid MaHd { get; set; }
        public decimal GiaTien { get; set; }
        public KhuyenMai KhuyenMai { get; set; }
        public HoaDon HoaDon { get; set; }
    }
}
