using Microsoft.EntityFrameworkCore.Migrations;

namespace KreditMotorEntityFrameworkCore.Migrations
{
    public partial class newrevert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "user",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "Roles",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "user",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "user");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "user");

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "Roles");
        }
    }
}
