using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserServiceAPI.DAL.Migrations
{
    public partial class SecondMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    NickName = table.Column<string>(type: "TEXT", nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "Comments", "CreateDate", "NickName" },
                values: new object[] { "Test@mail.com", "new test user", new DateTime(2023, 8, 18, 14, 20, 12, 599, DateTimeKind.Local).AddTicks(7006), "BurBon" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "Comments", "CreateDate", "NickName" },
                values: new object[] { "Test1@mail.com", "second test user", new DateTime(2023, 8, 18, 14, 20, 12, 600, DateTimeKind.Local).AddTicks(2234), "Turbo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
