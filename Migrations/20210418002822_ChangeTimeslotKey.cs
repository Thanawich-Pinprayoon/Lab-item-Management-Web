using Microsoft.EntityFrameworkCore.Migrations;

namespace LabManage.Migrations
{
    public partial class ChangeTimeslotKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_Timeslot",
                table: "Timeslot",
                columns: new[] { "start", "end", "toolID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Timeslot",
                table: "Timeslot");
        }
    }
}
