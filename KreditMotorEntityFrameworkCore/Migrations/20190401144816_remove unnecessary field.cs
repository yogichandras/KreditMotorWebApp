using Microsoft.EntityFrameworkCore.Migrations;

namespace KreditMotorEntityFrameworkCore.Migrations
{
    public partial class removeunnecessaryfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "user",
                column: "NormalizedEmail");
        }
    }
}
