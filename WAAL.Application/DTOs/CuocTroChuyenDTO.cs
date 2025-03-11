namespace WAAL.Application.DTOs
{
    public class CuocTroChuyenDTO
    {
        public Guid Id { get; set; }
        public Guid KhachHangId { get; set; }
        public Guid NhanVienHoTroId { get; set; }
        public DateTime LanCapNhatCuoi { get; set; }
        public string TinNhanCuoi { get; set; } 
    }

    public class CuocTroChuyenCreateDTO
    {
        public Guid KhachHangId { get; set; }
        public Guid NhanVienHoTroId { get; set; }
        public DateTime LanCapNhatCuoi { get; set; }
        public string TinNhanCuoi { get; set; }
    }

}
