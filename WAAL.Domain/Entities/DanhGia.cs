namespace WAAL.Domain.Entities
{
    public class DanhGia
    {
        public Guid MaSp { get; set; }
        public Guid UserId { get; set; }
        public float Rating { get; set; }
        public DateTime ThoiGianDanhGia { get; set; }
        public string NoiDung { get; set; }
        public bool TrangThai { get; set; } = true;
        public SanPham SanPham { get; set; }
        public AppUser User { get; set; }
    }
}
