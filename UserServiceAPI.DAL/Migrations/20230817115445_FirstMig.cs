using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserServiceAPI.DAL.Migrations
{
    public partial class FirstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NickName = table.Column<string>(type: "TEXT", nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Comments", "CreateDate", "Email", "NickName" },
                values: new object[] { 1, "new test user", new DateTime(2023, 8, 17, 14, 54, 45, 189, DateTimeKind.Local).AddTicks(3745), "Test@mail.com", "BurBon" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Comments", "CreateDate", "Email", "NickName" },
                values: new object[] { 2, "second test user", new DateTime(2023, 8, 17, 14, 54, 45, 189, DateTimeKind.Local).AddTicks(8905), "Test1@mail.com", "Turbo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
