namespace WAAL.Domain.Entities
{
    public class NhomQuyen
    {
        public int Id { get; set; }
        public string TenQuyen { get; set; }
        public bool TrangThai { get; set; }
        public ICollection<ThongBao> ThongBaos { get; set; }
        public ICollection<TaiKhoan> TaiKhoans { get; set; }
        public ICollection<ChiTietQuyen> ChiTietQuyens { get; set; }

    }
}
