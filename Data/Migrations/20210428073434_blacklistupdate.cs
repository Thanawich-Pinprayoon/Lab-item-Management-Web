using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabManage.Data.Migrations
{
    public partial class blacklistupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blacklist_AspNetUsers_staffID",
                table: "Blacklist");

            migrationBuilder.DropForeignKey(
                name: "FK_Blacklist_Lab_labID",
                table: "Blacklist");

            migrationBuilder.DropIndex(
                name: "IX_Blacklist_labID",
                table: "Blacklist");

            migrationBuilder.DropIndex(
                name: "IX_Blacklist_staffID",
                table: "Blacklist");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Blacklist");

            migrationBuilder.DropColumn(
                name: "labID",
                table: "Blacklist");

            migrationBuilder.DropColumn(
                name: "staffID",
                table: "Blacklist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Blacklist",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "labID",
                table: "Blacklist",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "staffID",
                table: "Blacklist",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Blacklist_labID",
                table: "Blacklist",
                column: "labID");

            migrationBuilder.CreateIndex(
                name: "IX_Blacklist_staffID",
                table: "Blacklist",
                column: "staffID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blacklist_AspNetUsers_staffID",
                table: "Blacklist",
                column: "staffID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blacklist_Lab_labID",
                table: "Blacklist",
                column: "labID",
                principalTable: "Lab",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
