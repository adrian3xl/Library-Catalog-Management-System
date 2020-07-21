using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_Management_System.Data.Migrations
{
    public partial class NewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorVM");

            migrationBuilder.DropTable(
                name: "PublisherVM");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "LibraryRecords");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Catalogs");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadlineDate",
                table: "LibraryRecords",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "LibraryRecords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffComment",
                table: "LibraryRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CatalogTypeId",
                table: "Catalogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Catalogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "Catalogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "StaffIdentificationCode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CatalogType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryDisposals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisposalCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    MethodOfDisposal = table.Column<string>(nullable: true),
                    DateOfDisposal = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryDisposals", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_CatalogTypeId",
                table: "Catalogs",
                column: "CatalogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_GenreId",
                table: "Catalogs",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_CatalogType_CatalogTypeId",
                table: "Catalogs",
                column: "CatalogTypeId",
                principalTable: "CatalogType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_Genres_GenreId",
                table: "Catalogs",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_CatalogType_CatalogTypeId",
                table: "Catalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_Genres_GenreId",
                table: "Catalogs");

            migrationBuilder.DropTable(
                name: "CatalogType");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "LibraryDisposals");

            migrationBuilder.DropIndex(
                name: "IX_Catalogs_CatalogTypeId",
                table: "Catalogs");

            migrationBuilder.DropIndex(
                name: "IX_Catalogs_GenreId",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "DeadlineDate",
                table: "LibraryRecords");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "LibraryRecords");

            migrationBuilder.DropColumn(
                name: "StaffComment",
                table: "LibraryRecords");

            migrationBuilder.DropColumn(
                name: "CatalogTypeId",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "StaffIdentificationCode",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "LibraryRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Catalogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Catalogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuthorVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueAuthorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublisherVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniquePublisherCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherVM", x => x.Id);
                });
        }
    }
}
