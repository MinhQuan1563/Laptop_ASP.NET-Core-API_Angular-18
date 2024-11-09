namespace WAAL.Domain.Entities
{
    public class TheLoai
    {
        public Guid Id { get; set; }
        public string TenLoai { get; set; }
        public bool TrangThai { get; set; } = true;
        public ICollection<SanPham> SanPhams { get; set; }
    }
}
