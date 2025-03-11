using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAAL.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTinNhanCuoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TinNhanCuoi",
                table: "CuocTroChuyens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TinNhanCuoi",
                table: "CuocTroChuyens");
        }
    }
}
