using Microsoft.EntityFrameworkCore.Migrations;

namespace KreditMotorEntityFrameworkCore.Migrations
{
    public partial class removeunnecessaryfield3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "user");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "user",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "user",
                nullable: false,
                defaultValue: false);
        }
    }
}
