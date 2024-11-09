namespace WAAL.Domain.Entities
{
    public class ChiTietCongKetNoi
    {
        public Guid MaCong { get; set; }
        public Guid MaCtsp { get; set; }
        public ChiTietSanPham ChiTietSanPham { get; set; }
        public CongKetNoi CongKetNoi { get; set; }
    }
}
