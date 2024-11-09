namespace WAAL.Domain.Entities
{
    public class MauSac
    {
        public Guid Id { get; set; }
        public string TenMau { get; set; }
        public string MaMau { get; set; }
        public bool TrangThai { get; set; } = true;
        public ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
