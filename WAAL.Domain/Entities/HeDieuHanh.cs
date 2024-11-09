namespace WAAL.Domain.Entities
{
    public class HeDieuHanh
    {
        public Guid Id { get; set; }
        public string TenHdh { get; set; }
        public bool TrangThai { get; set; } = true;
        public ICollection<SanPham> SanPhams { get; set; }
    }
}
