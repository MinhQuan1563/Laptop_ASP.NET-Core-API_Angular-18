namespace WAAL.Domain.Entities
{
    public class ChiTietPhieuBaoHanh
    {
        public Guid MaPbh { get; set; }
        public Guid MaImei { get; set; }
        public string LyDo { get; set; }
        public string NoiDungBaoHanh { get; set; }
        public PhieuBaoHanh PhieuBaoHanh { get; set; }
        public Imei Imei { get; set; }
    }
}
