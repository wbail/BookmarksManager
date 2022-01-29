using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookmarksManager.Persistence.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Child_Synced_SyncedId",
                table: "Child");

            migrationBuilder.AlterColumn<string>(
                name: "SyncedId",
                table: "Child",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Child_Synced_SyncedId",
                table: "Child",
                column: "SyncedId",
                principalTable: "Synced",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Child_Synced_SyncedId",
                table: "Child");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "SyncedId",
                table: "Child",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Child_Synced_SyncedId",
                table: "Child",
                column: "SyncedId",
                principalTable: "Synced",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
