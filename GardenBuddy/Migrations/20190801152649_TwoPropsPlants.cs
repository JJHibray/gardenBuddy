using Microsoft.EntityFrameworkCore.Migrations;

namespace GardenBuddy.Migrations
{
    public partial class TwoPropsPlants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Plants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlantName",
                table: "Plants",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PlantName",
                table: "Plants");
        }
    }
}
