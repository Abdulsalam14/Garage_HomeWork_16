using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_HomeWork_16.Migrations
{
    public partial class PricingAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "RecentWorks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PricingItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    UserCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpaceSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PricingItems",
                columns: new[] { "Id", "Cost", "Description", "SpaceSize", "Title", "UserCount" },
                values: new object[,]
                {
                    { 1, 0, "Community Forums", 2, "Free", "5 Users" },
                    { 2, 120, "Live Chat", 10, "Standart", "25  to 99 Users" },
                    { 3, 840, "Customizations", 80, "Enterprise", "100 Users or more" },
                    { 4, 150, "Description4", 15, "Title4", "15 Users" },
                    { 5, 100, "Description5", 25, "Title5", "50 Users" },
                    { 6, 60, "Description6", 30, "Title6", "65 Users" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PricingItems");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "RecentWorks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
