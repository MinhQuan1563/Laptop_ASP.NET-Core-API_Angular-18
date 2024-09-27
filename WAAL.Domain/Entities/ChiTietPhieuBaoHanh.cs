namespace WAAL.Domain.Entities
{
    public class ChiTietPhieuBaoHanh
    {
        public int MaPbh { get; set; }
        public int MaImei { get; set; }
        public string LyDo { get; set; }
        public string NoiDungBaoHanh { get; set; }
        public PhieuBaoHanh PhieuBaoHanh { get; set; }
        public Imei CtspImei { get; set; }
    }
}
