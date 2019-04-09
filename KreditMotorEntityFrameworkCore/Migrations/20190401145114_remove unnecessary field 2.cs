using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KreditMotorEntityFrameworkCore.Migrations
{
    public partial class removeunnecessaryfield2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "user");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "user");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "user");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "user");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "user");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "user",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "user",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "user",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "user",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "user",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "user",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "user",
                column: "NormalizedUserName",
                unique: true);
        }
    }
}
