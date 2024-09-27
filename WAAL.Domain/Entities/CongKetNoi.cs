namespace WAAL.Domain.Entities
{
    public class CongKetNoi
    {
        public int Id { get; set; }
        public string TenCong { get; set; }
        public bool TrangThai { get; set; }
        public ICollection<ChiTietCongKetNoi> ChiTietCongKetNois { get; set; }
    }
}
