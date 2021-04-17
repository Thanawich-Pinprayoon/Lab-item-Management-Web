using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabManage.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lab",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    pic = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lab", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tool",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    pic = table.Column<string>(type: "TEXT", nullable: true),
                    labID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tool", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tool_Lab_labID",
                        column: x => x.labID,
                        principalTable: "Lab",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    tel = table.Column<string>(type: "TEXT", nullable: true),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    pic = table.Column<string>(type: "TEXT", nullable: true),
                    manageLabID = table.Column<int>(type: "INTEGER", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Timeslot_Tool_toolID",
                        column: x => x.toolID,
                        principalTable: "Tool",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blacklist",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userID = table.Column<int>(type: "INTEGER", nullable: false),
                    staffID = table.Column<int>(type: "INTEGER", nullable: false),
                    reason = table.Column<string>(type: "TEXT", nullable: false),
                    labID = table.Column<int>(type: "INTEGER", nullable: false),
                    date = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blacklist", x => x.id);
                    table.ForeignKey(
                        name: "FK_Blacklist_Lab_labID",
                        column: x => x.labID,
                        principalTable: "Lab",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blacklist_User_staffID",
                        column: x => x.staffID,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blacklist_User_userID",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userID = table.Column<int>(type: "INTEGER", nullable: false),
                    staffID = table.Column<int>(type: "INTEGER", nullable: true),
                    toolID = table.Column<int>(type: "INTEGER", nullable: false),
                    itemID = table.Column<int>(type: "INTEGER", nullable: true),
                    start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    end = table.Column<DateTime>(type: "TEXT", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transaction_Item_itemID",
                        column: x => x.itemID,
                        principalTable: "Item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_Tool_toolID",
                        column: x => x.toolID,
                        principalTable: "Tool",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_User_staffID",
                        column: x => x.staffID,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_User_userID",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blacklist_labID",
                table: "Blacklist",
                column: "labID");

            migrationBuilder.CreateIndex(
                name: "IX_Blacklist_staffID",
                table: "Blacklist",
                column: "staffID");

            migrationBuilder.CreateIndex(
                name: "IX_Blacklist_userID",
                table: "Blacklist",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_toolID",
                table: "Item",
                column: "toolID");

            migrationBuilder.CreateIndex(
                name: "IX_Timeslot_toolID",
                table: "Timeslot",
                column: "toolID");

            migrationBuilder.CreateIndex(
                name: "IX_Tool_labID",
                table: "Tool",
                column: "labID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_itemID",
                table: "Transaction",
                column: "itemID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_staffID",
                table: "Transaction",
                column: "staffID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_toolID",
                table: "Transaction",
                column: "toolID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_userID",
                table: "Transaction",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_User_manageLabID",
                table: "User",
                column: "manageLabID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blacklist");

            migrationBuilder.DropTable(
                name: "Timeslot");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Tool");

            migrationBuilder.DropTable(
                name: "Lab");
        }
    }
}
