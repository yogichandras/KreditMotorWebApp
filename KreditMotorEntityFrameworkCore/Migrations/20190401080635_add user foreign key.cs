using Microsoft.EntityFrameworkCore.Migrations;

namespace KreditMotorEntityFrameworkCore.Migrations
{
    public partial class adduserforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_transaksi_kredit_user_id",
                table: "transaksi_kredit",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_pembayaran_cicilan_user_id",
                table: "pembayaran_cicilan",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_pembayaran_cicilan_user_user_id",
                table: "pembayaran_cicilan",
                column: "user_id",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transaksi_kredit_user_user_id",
                table: "transaksi_kredit",
                column: "user_id",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pembayaran_cicilan_user_user_id",
                table: "pembayaran_cicilan");

            migrationBuilder.DropForeignKey(
                name: "FK_transaksi_kredit_user_user_id",
                table: "transaksi_kredit");

            migrationBuilder.DropIndex(
                name: "IX_transaksi_kredit_user_id",
                table: "transaksi_kredit");

            migrationBuilder.DropIndex(
                name: "IX_pembayaran_cicilan_user_id",
                table: "pembayaran_cicilan");
        }
    }
}
