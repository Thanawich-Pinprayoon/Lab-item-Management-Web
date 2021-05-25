using Microsoft.EntityFrameworkCore.Migrations;

namespace LabManage.Data.Migrations
{
    public partial class ChangeUserFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blacklist_User_staffID",
                table: "Blacklist");

            migrationBuilder.DropForeignKey(
                name: "FK_Blacklist_User_userID",
                table: "Blacklist");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User_staffID",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User_userID",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AlterColumn<string>(
                name: "userID",
                table: "Transaction",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "staffID",
                table: "Transaction",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "staffID",
                table: "Blacklist",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "userID",
                table: "Blacklist",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Blacklist_AspNetUsers_staffID",
                table: "Blacklist",
                column: "staffID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blacklist_AspNetUsers_userID",
                table: "Blacklist",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_staffID",
                table: "Transaction",
                column: "staffID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_userID",
                table: "Transaction",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blacklist_AspNetUsers_staffID",
                table: "Blacklist");

            migrationBuilder.DropForeignKey(
                name: "FK_Blacklist_AspNetUsers_userID",
                table: "Blacklist");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_staffID",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_userID",
                table: "Transaction");

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                table: "Transaction",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "staffID",
                table: "Transaction",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "staffID",
                table: "Blacklist",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                table: "Blacklist",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    manageLabID = table.Column<int>(type: "INTEGER", nullable: true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    pic = table.Column<string>(type: "TEXT", nullable: true),
                    tel = table.Column<string>(type: "TEXT", nullable: true),
                    username = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Lab_manageLabID",
                        column: x => x.manageLabID,
                        principalTable: "Lab",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_manageLabID",
                table: "User",
                column: "manageLabID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blacklist_User_staffID",
                table: "Blacklist",
                column: "staffID",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blacklist_User_userID",
                table: "Blacklist",
                column: "userID",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User_staffID",
                table: "Transaction",
                column: "staffID",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User_userID",
                table: "Transaction",
                column: "userID",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
