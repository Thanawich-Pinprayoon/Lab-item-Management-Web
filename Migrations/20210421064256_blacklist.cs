using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_item_Management_Web.Migrations
{
    public partial class blacklist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blacklist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userID = table.Column<int>(type: "INTEGER", nullable: false),
                    addDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    reason = table.Column<string>(type: "TEXT", nullable: true),
                    staffID = table.Column<int>(type: "INTEGER", nullable: false),
                    labName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blacklist", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blacklist");
        }
    }
}
