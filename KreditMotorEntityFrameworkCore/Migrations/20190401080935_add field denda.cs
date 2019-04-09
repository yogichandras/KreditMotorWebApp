using Microsoft.EntityFrameworkCore.Migrations;

namespace KreditMotorEntityFrameworkCore.Migrations
{
    public partial class addfielddenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "denda",
                table: "pembayaran_cicilan",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "denda",
                table: "pembayaran_cicilan");
        }
    }
}
