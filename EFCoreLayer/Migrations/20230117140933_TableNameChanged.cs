using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreLayer.Migrations
{
    public partial class TableNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_testModels",
                table: "testModels");

            migrationBuilder.RenameTable(
                name: "testModels",
                newName: "TestEntities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestEntities",
                table: "TestEntities",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TestEntities",
                table: "TestEntities");

            migrationBuilder.RenameTable(
                name: "TestEntities",
                newName: "testModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_testModels",
                table: "testModels",
                column: "Id");
        }
    }
}
