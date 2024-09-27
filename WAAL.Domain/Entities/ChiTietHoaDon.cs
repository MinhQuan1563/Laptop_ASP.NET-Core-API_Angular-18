namespace WAAL.Domain.Entities
{
    public class ChiTietHoaDon
    {
        public int MaHd { get; set; }
        public int MaImei { get; set; }
        public int SoLuong { get; set; } = 1;
        public decimal GiaSp { get; set; }
        public HoaDon HoaDon { get; set; }
        public Imei Imei { get; set; }
    }
}
