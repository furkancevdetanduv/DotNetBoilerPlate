using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetBoilerPlate.EF.Migrations
{
    public partial class UserColumnNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "Users",
                newName: "PasswordKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordKey",
                table: "Users",
                newName: "PasswordSalt");
        }
    }
}
