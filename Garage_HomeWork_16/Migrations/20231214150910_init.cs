using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_HomeWork_16.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactIntro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactIntro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryCategoryComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCategoryComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryCategoryComponents_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryCategoryComponents_CategoryComponents_CategoryComponentId",
                        column: x => x.CategoryComponentId,
                        principalTable: "CategoryComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "FilePath", "Text", "Title" },
                values: new object[,]
                {
                    { 1, "/services-01.jpg", "UI?UX Design text", "UI?UX Design" },
                    { 2, "/services-02.jpg", "Social Media text", "Social Media" },
                    { 3, "/services-03.jpg", "Marketing text", "Marketing" },
                    { 4, "/services-04.jpg", "Graphic  text", "Graphic" },
                    { 5, "/services-05.jpg", "Digital Marketing text", "Digital Marketing" },
                    { 6, "/services-06.jpg", "Market Researchtext", "Market Research" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Business" },
                    { 2, "Marketing" },
                    { 3, "Social Media" },
                    { 4, "Graphic" }
                });

            migrationBuilder.InsertData(
                table: "CategoryComponents",
                columns: new[] { "Id", "Description", "FilePath", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit,\r\nsed do eiusmod tempor incididunt ut labore et dolor.", "our-work-01.jpg", "Digital Marketing" },
                    { 2, "Ut enim ad minim veniam, quis nostrud exercitation ullamco\r\nlaboris nisi ut aliquip ex ea commodo consequat.", "our-work-02.jpg", "Corporate Branding" },
                    { 3, "Duis aute irure dolor in reprehenderit in voluptate velit\r\nesse cillum dolore eu fugiatdolore eu fugiat nulla pariatur.", "our-work-03.jpg", "Leading Digital Solution" },
                    { 4, "Excepteur sint occaecat cupidatat non proident, sunt in\r\nculpa qui officia deserunt mollit anim id est laborum.", "our-work-04.jpg", "Smart Applications" },
                    { 5, "Excepteur sint occaecat cupidatat non proident,\r\nsunt in culpa qui officia deserunt mollit anim id est laborum.", "our-work-05.jpg", "Corporate Stationary" },
                    { 6, "Ut enim ad minim veniam, quis nostrud exercitation ullamco\r\nlaboris nisi ut aliquip ex ea commodo consequat.", "our-work-06.jpg", "8 Financial Tips" }
                });

            migrationBuilder.InsertData(
                table: "ContactIntro",
                columns: new[] { "Id", "Description", "FilePath", "Title" },
                values: new object[] { 1, "<h3 class=\"h4 regular-400\">Elit, sed do eiusmod tempor</h3><p class=\"light-300\">Vector illustration is from <a rel=\"nofollow\" href=\"https://storyset.com/\" target=\"_blank\">StorySet</a>.Incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse ultrices gravida.</p>", "/banner-img-01.svg", "Contact" });

            migrationBuilder.InsertData(
                table: "CategoryCategoryComponents",
                columns: new[] { "Id", "CategoryComponentId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 1, 2 },
                    { 3, 1, 1 },
                    { 4, 2, 4 },
                    { 5, 2, 3 },
                    { 6, 3, 2 },
                    { 7, 3, 4 },
                    { 8, 3, 1 },
                    { 9, 4, 3 },
                    { 10, 4, 1 },
                    { 11, 5, 2 },
                    { 12, 6, 2 },
                    { 13, 6, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCategoryComponents_CategoryComponentId",
                table: "CategoryCategoryComponents",
                column: "CategoryComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCategoryComponents_CategoryId",
                table: "CategoryCategoryComponents",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "CategoryCategoryComponents");

            migrationBuilder.DropTable(
                name: "ContactIntro");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryComponents");
        }
    }
}
