using Microsoft.EntityFrameworkCore.Migrations;

namespace GardenBuddy.Migrations
{
    public partial class userIdADD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Plants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "GardenBeds",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plants_userId",
                table: "Plants",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_GardenBeds_userId",
                table: "GardenBeds",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_GardenBeds_AspNetUsers_userId",
                table: "GardenBeds",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_AspNetUsers_userId",
                table: "Plants",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GardenBeds_AspNetUsers_userId",
                table: "GardenBeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_AspNetUsers_userId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_userId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_GardenBeds_userId",
                table: "GardenBeds");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "GardenBeds");
        }
    }
}
