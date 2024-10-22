using WAAL.Domain.Entities;

namespace WAAL.Application.DTOs
{
    public class DanhGiaDTO
    {
        public int MaSp { get; set; }
        public int MaKh { get; set; }
        public float Rating { get; set; }
        public DateTime ThoiGianDanhGia { get; set; }
        public string NoiDung { get; set; }
        public bool TrangThai { get; set; }
        public SanPham SanPham { get; set; }
    }
}
