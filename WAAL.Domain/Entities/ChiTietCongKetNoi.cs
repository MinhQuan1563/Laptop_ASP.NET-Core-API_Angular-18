namespace WAAL.Domain.Entities
{
    public class ChiTietCongKetNoi
    {
        public int MaCong { get; set; }
        public int MaCtsp { get; set; }
        public ChiTietSanPham ChiTietSanPham { get; set; }
        public CongKetNoi CongKetNoi { get; set; }
    }
}
