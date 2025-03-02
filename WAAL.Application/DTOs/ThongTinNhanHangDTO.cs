using WAAL.Domain.Entities;

namespace WAAL.Application.DTOs
{
    public class ThongTinNhanHangDTO
    {
        public Guid Id { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public bool DiaChiMacDinh { get; set; }
        public Guid UserId { get; set; }
    }
}
