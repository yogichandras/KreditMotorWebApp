using Microsoft.EntityFrameworkCore.Migrations;

namespace KreditMotorEntityFrameworkCore.Migrations
{
    public partial class addallforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pembayaran_dp");

            migrationBuilder.AddColumn<string>(
                name: "no_kredit",
                table: "pembayaran_cicilan",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_transaksi_kredit_kd_motor",
                table: "transaksi_kredit",
                column: "kd_motor");

            migrationBuilder.CreateIndex(
                name: "IX_transaksi_kredit_kd_pelanggan",
                table: "transaksi_kredit",
                column: "kd_pelanggan");

            migrationBuilder.CreateIndex(
                name: "IX_pembayaran_cicilan_no_kredit",
                table: "pembayaran_cicilan",
                column: "no_kredit");

            migrationBuilder.AddForeignKey(
                name: "FK_pembayaran_cicilan_transaksi_kredit_no_kredit",
                table: "pembayaran_cicilan",
                column: "no_kredit",
                principalTable: "transaksi_kredit",
                principalColumn: "no_kredit",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transaksi_kredit_motor_kd_motor",
                table: "transaksi_kredit",
                column: "kd_motor",
                principalTable: "motor",
                principalColumn: "kd_motor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transaksi_kredit_pelanggan_kd_pelanggan",
                table: "transaksi_kredit",
                column: "kd_pelanggan",
                principalTable: "pelanggan",
                principalColumn: "kd_pelanggan",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pembayaran_cicilan_transaksi_kredit_no_kredit",
                table: "pembayaran_cicilan");

            migrationBuilder.DropForeignKey(
                name: "FK_transaksi_kredit_motor_kd_motor",
                table: "transaksi_kredit");

            migrationBuilder.DropForeignKey(
                name: "FK_transaksi_kredit_pelanggan_kd_pelanggan",
                table: "transaksi_kredit");

            migrationBuilder.DropIndex(
                name: "IX_transaksi_kredit_kd_motor",
                table: "transaksi_kredit");

            migrationBuilder.DropIndex(
                name: "IX_transaksi_kredit_kd_pelanggan",
                table: "transaksi_kredit");

            migrationBuilder.DropIndex(
                name: "IX_pembayaran_cicilan_no_kredit",
                table: "pembayaran_cicilan");

            migrationBuilder.DropColumn(
                name: "no_kredit",
                table: "pembayaran_cicilan");

            migrationBuilder.CreateTable(
                name: "pembayaran_dp",
                columns: table => new
                {
                    no_bayar_dp = table.Column<string>(maxLength: 10, nullable: false),
                    no_kredit = table.Column<string>(maxLength: 10, nullable: true),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pembayaran_dp", x => x.no_bayar_dp);
                });
        }
    }
}
