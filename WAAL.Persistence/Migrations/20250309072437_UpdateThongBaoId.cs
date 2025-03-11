using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAAL.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateThongBaoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ThongBaos",
                table: "ThongBaos");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThongBaos",
                table: "ThongBaos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaSp",
                table: "ThongBaos",
                column: "MaSp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ThongBaos",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_MaSp",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ThongBaos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThongBaos",
                table: "ThongBaos",
                columns: new[] { "MaSp", "UserId", "MaHd", "MaPn", "MaPbh", "MaPdt", "MaNcc", "MaKm" });
        }
    }
}
