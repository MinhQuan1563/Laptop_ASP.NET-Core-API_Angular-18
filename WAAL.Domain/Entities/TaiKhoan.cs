namespace WAAL.Domain.Entities
{
    public class TaiKhoan
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Otp { get; set; }
        public bool TrangThai { get; set; } = true;
        public NhomQuyen NhomQuyen { get; set; }
        public ICollection<ThongBao> ThongBaos { get; set; }
    }
}
