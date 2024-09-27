namespace WAAL.Domain.Entities
{
    public class ChiTietPhieuDoiTra
    {
        public int MaPdt { get; set; }
        public int MaImei { get; set; }
        public string LyDo { get; set; }
        public decimal GiaSp { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien { get; set; }
        public PhieuDoiTra PhieuDoiTra { get; set; }
        public Imei Imei { get; set; }
    }
}
