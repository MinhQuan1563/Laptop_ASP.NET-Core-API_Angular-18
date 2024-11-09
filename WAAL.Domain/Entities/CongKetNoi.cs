namespace WAAL.Domain.Entities
{
    public class CongKetNoi
    {
        public Guid Id { get; set; }
        public string TenCong { get; set; }
        public bool TrangThai { get; set; } = true;
        public ICollection<ChiTietCongKetNoi> ChiTietCongKetNois { get; set; }
    }
}
