namespace WAAL.Domain.Entities
{
    public class CuocTroChuyen
    {
        public Guid Id { get; set; }
        public Guid KhachHangId { get; set; }
        public AppUser KhachHang { get; set; }
        public Guid NhanVienHoTroId { get; set; }
        public AppUser NhanVienHoTro { get; set; }
        public ICollection<TinNhan> TinNhans { get; set; }
        public DateTime LanCapNhatCuoi { get; set; }
        public String TinNhanCuoi { get; set; }
}
}
