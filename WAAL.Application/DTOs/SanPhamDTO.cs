namespace WAAL.Application.DTOs
{
    public class SanPhamDTO
    {
        public Guid Id { get; set; }
        public string TenSp { get; set; }
        public string HinhAnh { get; set; }
        public string KichCoManHinh { get; set; }
        public string DoPhanGiai { get; set; }
        public string Pin { get; set; }
        public string BanPhim { get; set; }
        public double TrongLuong { get; set; }
        public string ChatLieu { get; set; }
        public string XuatXu { get; set; }
        public int SoLuongTon { get; set; }
        public bool TrangThai { get; set; }
    }
}
