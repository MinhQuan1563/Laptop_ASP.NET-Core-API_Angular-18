using System.ComponentModel.DataAnnotations;namespace WAAL.Domain.Entities
{
    public class ChipXuLy
    {
        public int Id { get; set; }
        public string TenChip { get; set; }
        public bool TrangThai { get; set; }
        public ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
