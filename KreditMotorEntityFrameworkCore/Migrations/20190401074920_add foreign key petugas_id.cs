using Microsoft.EntityFrameworkCore.Migrations;

namespace KreditMotorEntityFrameworkCore.Migrations
{
    public partial class addforeignkeypetugas_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "kd_pelanggan",
                table: "transaksi_kredit",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_kd_petugas",
                table: "user",
                column: "kd_petugas");

            migrationBuilder.AddForeignKey(
                name: "FK_user_petugas_kd_petugas",
                table: "user",
                column: "kd_petugas",
                principalTable: "petugas",
                principalColumn: "kd_petugas",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_petugas_kd_petugas",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_kd_petugas",
                table: "user");

            migrationBuilder.AlterColumn<string>(
                name: "kd_pelanggan",
                table: "transaksi_kredit",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
