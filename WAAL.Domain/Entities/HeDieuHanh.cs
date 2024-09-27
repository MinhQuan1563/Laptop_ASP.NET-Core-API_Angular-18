namespace WAAL.Domain.Entities
{
    public class HeDieuHanh
    {
        public int Id { get; set; }
        public string TenHdh { get; set; }
        public bool TrangThai { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
    }
}
