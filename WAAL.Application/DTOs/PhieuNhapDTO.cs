﻿namespace WAAL.Application.DTOs
{
    public class PhieuNhapDTO
    {
        public int Id { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
        public string TinhTrang { get; set; }
        public bool TrangThai { get; set; }
    }
}
