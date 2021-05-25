using Microsoft.EntityFrameworkCore.Migrations;

namespace LabManage.Data.Migrations
{
    public partial class ChangeBlacklistPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blacklist",
                table: "Blacklist");

            migrationBuilder.DropIndex(
                name: "IX_Blacklist_userID",
                table: "Blacklist");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Blacklist",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blacklist",
                table: "Blacklist",
                columns: new[] { "userID", "staffID", "labID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blacklist",
                table: "Blacklist");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Blacklist",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blacklist",
                table: "Blacklist",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Blacklist_userID",
                table: "Blacklist",
                column: "userID");
        }
    }
}
