using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_HomeWork_16.Migrations
{
    public partial class FeatureWorkComponentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeaturedWorkComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedWorkComponent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeaturedWorkComponentPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    FeaturedWorkComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedWorkComponentPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeaturedWorkComponentPhotos_FeaturedWorkComponent_FeaturedWorkComponentId",
                        column: x => x.FeaturedWorkComponentId,
                        principalTable: "FeaturedWorkComponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FeaturedWorkComponent",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, "<h2><strong>Transform with us</strong></h2><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse ultrices gravida. Risus commodo viverra maecenas accumsan lacus vel facilisis.</p><p>Consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse ultrices gravida. Risus commodo viverra maecenas. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>", "Featured Work" });

            migrationBuilder.InsertData(
                table: "FeaturedWorkComponentPhotos",
                columns: new[] { "Id", "FeaturedWorkComponentId", "Order", "PhotoPath" },
                values: new object[,]
                {
                    { 1, 1, 1, "feature-work-1.jpg" },
                    { 2, 1, 2, "feature-work-2.jpg" },
                    { 3, 1, 3, "feature-work-3.jpg" },
                    { 4, 1, 4, "feature-work-4.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedWorkComponentPhotos_FeaturedWorkComponentId",
                table: "FeaturedWorkComponentPhotos",
                column: "FeaturedWorkComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeaturedWorkComponentPhotos");

            migrationBuilder.DropTable(
                name: "FeaturedWorkComponent");
        }
    }
}
