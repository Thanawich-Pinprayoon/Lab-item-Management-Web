using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_item_Management_Web.Migrations
{
    public partial class managetolabmanage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manage",
                table: "User",
                newName: "LabManage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LabManage",
                table: "User",
                newName: "Manage");
        }
    }
}
