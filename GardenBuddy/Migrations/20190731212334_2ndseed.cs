using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GardenBuddy.Migrations
{
    public partial class _2ndseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c27ddb49-7aa0-45dc-a702-cb5ae49023e0");

            migrationBuilder.CreateTable(
                name: "GardenBeds",
                columns: table => new
                {
                    GardenBedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenBeds", x => x.GardenBedId);
                });

            migrationBuilder.CreateTable(
                name: "PlantGardens",
                columns: table => new
                {
                    PlantGardenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlantId = table.Column<int>(nullable: false),
                    GardenBedId = table.Column<int>(nullable: false),
                    rowNumber = table.Column<int>(nullable: false),
                    plantCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantGardens", x => x.PlantGardenId);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    rowWidth = table.Column<double>(nullable: false),
                    BetweenPlants = table.Column<double>(nullable: false),
                    groundDepth = table.Column<double>(nullable: false),
                    Soil = table.Column<string>(nullable: false),
                    Season = table.Column<string>(nullable: false),
                    Watering = table.Column<string>(nullable: false),
                    Pruning = table.Column<string>(nullable: false),
                    Pests = table.Column<string>(nullable: false),
                    Disease = table.Column<string>(nullable: false),
                    MiscCare = table.Column<string>(nullable: false),
                    Storage = table.Column<string>(nullable: false),
                    harvestMethod = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenBeds");

            migrationBuilder.DropTable(
                name: "PlantGardens");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c27ddb49-7aa0-45dc-a702-cb5ae49023e0", 0, "be45d8e7-3f6a-4dc0-91a9-2ab2295b0e05", "ApplicationUser", "Josh@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEAAVYJvKIdgZJU6MMMkXK5n3mIo+0qkMiUAUrgV3vmMqzN/m41n76BHYykjx998edg==", null, false, null, false, "Josh@gmail.com" });
        }
    }
}
