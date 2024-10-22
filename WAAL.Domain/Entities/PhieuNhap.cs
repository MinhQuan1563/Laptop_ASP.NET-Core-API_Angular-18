﻿namespace WAAL.Domain.Entities
{
    public class PhieuNhap
    {
        public int Id { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
        public string TinhTrang { get; set; }
        public bool TrangThai { get; set; } = true;
        public NhanVien NhanVien { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        public ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public ICollection<ThongBao> ThongBaos { get; set; }
    }
}
