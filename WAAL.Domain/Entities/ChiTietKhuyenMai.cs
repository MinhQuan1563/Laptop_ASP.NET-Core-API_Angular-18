namespace WAAL.Domain.Entities
{
    public class ChiTietKhuyenMai
    {
        public int MaKm { get; set; }
        public int MaHd { get; set; }
        public decimal GiaTien { get; set; }
        public KhuyenMai KhuyenMai { get; set; }
        public HoaDon HoaDon { get; set; }
    }
}
