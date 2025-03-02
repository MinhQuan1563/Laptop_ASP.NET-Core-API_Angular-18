﻿namespace WAAL.Domain.Entities
{
    public class ChiTietQuyen
    {
        public Guid MaChucNang { get; set; }
        public Guid RoleId { get; set; }
        public string HanhDong { get; set; }
        public bool TrangThai { get; set; } = false;
        public ChucNang ChucNang { get; set; }
        public AppRole Role { get; set; }
    }
}
