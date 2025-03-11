using Microsoft.Extensions.DependencyInjection;
using WAAL.Application.Interfaces;
using WAAL.Domain.Interfaces;
using WAAL.Infrastructure.Services;
using WAAL.Persistence.Repositories;

namespace WAAL.Persistence.ServiceRegister
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ICardDoHoaRepository, CardDoHoaRepository>();
            services.AddScoped<IMauSacRepository, MauSacRepository>();
            services.AddScoped<INhaCungCapRepository, NhaCungCapRepository>();
            services.AddScoped<IChucNangRepository, ChucNangRepository>();
            services.AddScoped<IChiTietQuyenRepository, ChiTietQuyenRepository>();
            services.AddScoped<ISanPhamRepository, SanPhamRepository>();
            services.AddScoped<IHeDieuHanhRepository, HeDieuHanhRepository>();
            services.AddScoped<IThuongHieuRepository, ThuongHieuRepository>();
            services.AddScoped<ITheLoaiRepository, TheLoaiRepository>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IChiTietSanPhamRepository, ChiTietSanPhamRepository>();
            services.AddScoped<IChipXuLyRepository, ChipXuLyRepository>();
            services.AddScoped<IDanhGiaRepository, DanhGiaRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGioHangRepository, GioHangRepository>();
            services.AddScoped<IKhuyenMaiRepository, KhuyenMaiRepository>();
            services.AddScoped<IThongTinNhanHangRepository, ThongTinNhanHangRepository>();
            services.AddScoped<IImeiRepository, ImeiRepository>();
            services.AddScoped<IChiTietHoaDonRepository, ChiTietHoaDonRepository>();
            services.AddScoped<IChiTietKhuyenMaiRepository, ChiTietKhuyenMaiRepository>();
            services.AddScoped<IHoaDonRepository, HoaDonRepository>();
            services.AddScoped<ITinNhanRepository, TinNhanRepository>();
            services.AddScoped<ICuocTroChuyenRepository, CuocTroChuyenRepository>();
            services.AddScoped<IThongBaoRepository, ThongBaoRepository>();

            return services;
        }
    }
}
