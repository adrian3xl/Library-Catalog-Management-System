using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_Management_System.Data.Migrations
{
    public partial class Addedlink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LibraryEmployeeId",
                table: "LibraryRecords",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibraryRecords_LibraryEmployeeId",
                table: "LibraryRecords",
                column: "LibraryEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryRecords_AspNetUsers_LibraryEmployeeId",
                table: "LibraryRecords",
                column: "LibraryEmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryRecords_AspNetUsers_LibraryEmployeeId",
                table: "LibraryRecords");

            migrationBuilder.DropIndex(
                name: "IX_LibraryRecords_LibraryEmployeeId",
                table: "LibraryRecords");

            migrationBuilder.DropColumn(
                name: "LibraryEmployeeId",
                table: "LibraryRecords");
        }
    }
}
