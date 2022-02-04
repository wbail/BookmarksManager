using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookmarksManager.Persistence.Migrations
{
    public partial class AddNewUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[] { new Guid("f8148ea9-5ba7-49d3-b6b3-d5a7653ce105"), "test7", "default", "test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f8148ea9-5ba7-49d3-b6b3-d5a7653ce105"));
        }
    }
}
