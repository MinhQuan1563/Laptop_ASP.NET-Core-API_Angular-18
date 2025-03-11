using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAAL.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDeleteBehaviorCuocTroChuyen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CuocTroChuyens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NhanVienHoTroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuocTroChuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuocTroChuyens_Users_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CuocTroChuyens_Users_NhanVienHoTroId",
                        column: x => x.NhanVienHoTroId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TinNhans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CuocTroChuyenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiGuiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianGui = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaDoc = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinNhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TinNhans_CuocTroChuyens_CuocTroChuyenId",
                        column: x => x.CuocTroChuyenId,
                        principalTable: "CuocTroChuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TinNhans_Users_NguoiGuiId",
                        column: x => x.NguoiGuiId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuocTroChuyens_KhachHangId",
                table: "CuocTroChuyens",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_CuocTroChuyens_NhanVienHoTroId",
                table: "CuocTroChuyens",
                column: "NhanVienHoTroId");

            migrationBuilder.CreateIndex(
                name: "IX_TinNhans_CuocTroChuyenId",
                table: "TinNhans",
                column: "CuocTroChuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_TinNhans_NguoiGuiId",
                table: "TinNhans",
                column: "NguoiGuiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TinNhans");

            migrationBuilder.DropTable(
                name: "CuocTroChuyens");
        }
    }
}
