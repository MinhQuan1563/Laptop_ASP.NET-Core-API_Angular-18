using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAAL.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFullRoleNameToRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullRoleName",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullRoleName",
                table: "Roles");
        }
    }
}
