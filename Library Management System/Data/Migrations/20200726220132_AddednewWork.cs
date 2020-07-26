using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_Management_System.Data.Migrations
{
    public partial class AddednewWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LibraryEmployeeId",
                table: "LibraryDisposals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibraryDisposals_LibraryEmployeeId",
                table: "LibraryDisposals",
                column: "LibraryEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryDisposals_AspNetUsers_LibraryEmployeeId",
                table: "LibraryDisposals",
                column: "LibraryEmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryDisposals_AspNetUsers_LibraryEmployeeId",
                table: "LibraryDisposals");

            migrationBuilder.DropIndex(
                name: "IX_LibraryDisposals_LibraryEmployeeId",
                table: "LibraryDisposals");

            migrationBuilder.DropColumn(
                name: "LibraryEmployeeId",
                table: "LibraryDisposals");
        }
    }
}
