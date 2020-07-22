using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_Management_System.Data.Migrations
{
    public partial class NewMigrationAfteredits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_CatalogType_CatalogTypeId",
                table: "Catalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogType",
                table: "CatalogType");

            migrationBuilder.RenameTable(
                name: "CatalogType",
                newName: "CatalogTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogTypes",
                table: "CatalogTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_CatalogTypes_CatalogTypeId",
                table: "Catalogs",
                column: "CatalogTypeId",
                principalTable: "CatalogTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_CatalogTypes_CatalogTypeId",
                table: "Catalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogTypes",
                table: "CatalogTypes");

            migrationBuilder.RenameTable(
                name: "CatalogTypes",
                newName: "CatalogType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogType",
                table: "CatalogType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_CatalogType_CatalogTypeId",
                table: "Catalogs",
                column: "CatalogTypeId",
                principalTable: "CatalogType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
