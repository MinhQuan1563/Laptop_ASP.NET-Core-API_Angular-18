﻿namespace WAAL.Domain.Entities
{
    public class ChiTietPhieuNhap
    {
        public Guid MaPn { get; set; }
        public Guid MaCtsp { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaTien { get; set; }
        public decimal ThanhTien { get; set; }
        public PhieuNhap PhieuNhap { get; set; }
        public ChiTietSanPham ChiTietSanPham { get; set; }
    }
}
