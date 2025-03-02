using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace WAAL.Application.DTOs
{
    public class SanPhamDTO
    {
        public Guid Id { get; set; }
        public string TenSp { get; set; }
        [JsonIgnore]
        public IFormFile? HinhAnh { get; set; }
        public string KichCoManHinh { get; set; }
        public string DoPhanGiai { get; set; }
        public string Pin { get; set; }
        public string BanPhim { get; set; }
        public double TrongLuong { get; set; }
        public string ChatLieu { get; set; }
        public string XuatXu { get; set; }
        public string MoTa { get; set; }
        public int SoLuongTon { get; set; }
        public Guid ThuongHieuId { get; set; }
        public Guid TheLoaiId { get; set; }
        public Guid HeDieuHanhId { get; set; }
    }

    public class SanPhamListDTO
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
        public string MoTa { get; set; }
        public int SoLuongTon { get; set; }
        public Guid ThuongHieuId { get; set; }
        public Guid TheLoaiId { get; set; }
        public Guid HeDieuHanhId { get; set; }
    }
}
