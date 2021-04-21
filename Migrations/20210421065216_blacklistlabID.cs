using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_item_Management_Web.Migrations
{
    public partial class blacklistlabID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "labName",
                table: "Blacklist");

            migrationBuilder.AddColumn<int>(
                name: "labId",
                table: "Blacklist",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "labId",
                table: "Blacklist");

            migrationBuilder.AddColumn<string>(
                name: "labName",
                table: "Blacklist",
                type: "TEXT",
                nullable: true);
        }
    }
}
