namespace WAAL.Domain.Entities
{
    public class TheLoai
    {
        public int Id { get; set; }
        public string TenLoai { get; set; }
        public bool TrangThai { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
    }
}
