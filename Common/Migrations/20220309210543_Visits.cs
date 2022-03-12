using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class Visits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Browser",
                table: "VisitorInfo");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "VisitorInfo");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "VisitorInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "VisitorInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "VisitorInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "VisitorInfo",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
