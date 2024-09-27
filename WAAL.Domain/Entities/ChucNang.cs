﻿namespace WAAL.Domain.Entities
{
    public class ChucNang
    {
        public int Id { get; set; }
        public string TenChucNang { get; set; }
        public bool TrangThai { get; set; }
        public ICollection<ThongBao> ThongBaos { get; set; }
        public ICollection<ChiTietQuyen> chiTietQuyens { get; set; }
    }
}
