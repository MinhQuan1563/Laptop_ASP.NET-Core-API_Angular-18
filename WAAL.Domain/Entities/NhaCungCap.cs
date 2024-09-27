namespace WAAL.Domain.Entities
{
    public class NhaCungCap
    {
        public int Id { get; set; }
        public string TenNcc { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public bool TrangThai { get; set; }
        public ICollection<PhieuNhap> PhieuNhaps { get; set; }
        public ICollection<ThongBao> ThongBaos { get; set; }
    }
}
