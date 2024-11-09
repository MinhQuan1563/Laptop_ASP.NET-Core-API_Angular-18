namespace WAAL.Domain.Entities
{
    public class ChipXuLy
    {
        public Guid Id { get; set; }
        public string TenChip { get; set; }
        public bool TrangThai { get; set; } = true;
        public ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
