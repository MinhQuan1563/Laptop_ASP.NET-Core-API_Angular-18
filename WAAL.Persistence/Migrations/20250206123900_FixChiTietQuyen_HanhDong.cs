using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAAL.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixChiTietQuyen_HanhDong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietQuyens",
                table: "ChiTietQuyens");

            migrationBuilder.AlterColumn<string>(
                name: "HanhDong",
                table: "ChiTietQuyens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietQuyens",
                table: "ChiTietQuyens",
                columns: new[] { "MaChucNang", "RoleId", "HanhDong" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietQuyens",
                table: "ChiTietQuyens");

            migrationBuilder.AlterColumn<string>(
                name: "HanhDong",
                table: "ChiTietQuyens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietQuyens",
                table: "ChiTietQuyens",
                columns: new[] { "MaChucNang", "RoleId" });
        }
    }
}
