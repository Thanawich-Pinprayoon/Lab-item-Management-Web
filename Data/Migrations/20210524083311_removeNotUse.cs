using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabManage.Data.Migrations
{
    public partial class removeNotUse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_staffID",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Item_itemID",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Timeslot");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_itemID",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_staffID",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "end",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "itemID",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "staffID",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "start",
                table: "Transaction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "end",
                table: "Transaction",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "itemID",
                table: "Transaction",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "staffID",
                table: "Transaction",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "start",
                table: "Transaction",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    toolID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.id);
                    table.ForeignKey(
                        name: "FK_Item_Tool_toolID",
                        column: x => x.toolID,
                        principalTable: "Tool",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timeslot",
                columns: table => new
                {
                    start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    end = table.Column<DateTime>(type: "TEXT", nullable: false),
                    toolID = table.Column<int>(type: "INTEGER", nullable: false),
                    count = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeslot", x => new { x.start, x.end, x.toolID });
                    table.ForeignKey(
                        name: "FK_Timeslot_Tool_toolID",
                        column: x => x.toolID,
                        principalTable: "Tool",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_itemID",
                table: "Transaction",
                column: "itemID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_staffID",
                table: "Transaction",
                column: "staffID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_toolID",
                table: "Item",
                column: "toolID");

            migrationBuilder.CreateIndex(
                name: "IX_Timeslot_toolID",
                table: "Timeslot",
                column: "toolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_staffID",
                table: "Transaction",
                column: "staffID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Item_itemID",
                table: "Transaction",
                column: "itemID",
                principalTable: "Item",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
