using Microsoft.EntityFrameworkCore.Migrations;

namespace KreditMotorEntityFrameworkCore.Migrations
{
    public partial class updatefieldmotor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "user",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "picture",
                table: "motor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "user");

            migrationBuilder.DropColumn(
                name: "picture",
                table: "motor");
        }
    }
}
