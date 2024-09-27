namespace WAAL.Domain.Entities
{
    public class MauSac
    {
        public int Id { get; set; }
        public string TenMau { get; set; }
        public bool TrangThai { get; set; }
        public ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
