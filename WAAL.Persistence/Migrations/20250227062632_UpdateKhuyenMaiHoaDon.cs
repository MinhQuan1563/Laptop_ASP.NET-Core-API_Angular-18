using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAAL.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKhuyenMaiHoaDon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GiaTien",
                table: "ChiTietKhuyenMais",
                newName: "GiaTienGIam");

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhuongThucThanhToan",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TinhTrang",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TongTienSauKhuyenMai",
                table: "HoaDons",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "DanhGias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "PhuongThucThanhToan",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "TinhTrang",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "TongTienSauKhuyenMai",
                table: "HoaDons");

            migrationBuilder.RenameColumn(
                name: "GiaTienGIam",
                table: "ChiTietKhuyenMais",
                newName: "GiaTien");

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "DanhGias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
