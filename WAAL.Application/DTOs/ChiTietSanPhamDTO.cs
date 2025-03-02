using WAAL.Domain.Entities;

namespace WAAL.Application.DTOs
{
    public class ChiTietSanPhamDTO
    {
        public Guid Id { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
        public decimal GiaNhap { get; set; }
        public float ChietKhau { get; set; }
        public decimal GiaTien { get; set; }
        public int SoLuong { get; set; }
        public Guid SanPhamId { get; set; }
        public Guid MauSacId { get; set; }
        public Guid CardDoHoaId { get; set; }
        public Guid ChipXuLyId { get; set; }
    }
}
