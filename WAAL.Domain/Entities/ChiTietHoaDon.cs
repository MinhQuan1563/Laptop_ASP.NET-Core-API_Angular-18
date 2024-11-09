namespace WAAL.Domain.Entities
{
    public class ChiTietHoaDon
    {
        public Guid MaHd { get; set; }
        public Guid MaImei { get; set; }
        public int SoLuong { get; set; } = 1;
        public decimal GiaSp { get; set; }
        public HoaDon HoaDon { get; set; }
        public Imei Imei { get; set; }
    }
}
