using Microsoft.EntityFrameworkCore.Migrations;

namespace PolestarApi.Migrations
{
    public partial class addTokenInto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "UserAccount",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "UserAccount");
        }
    }
}
