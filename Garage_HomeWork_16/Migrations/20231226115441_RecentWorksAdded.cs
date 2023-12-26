using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_HomeWork_16.Migrations
{
    public partial class RecentWorksAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RecentWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecentWorks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RecentWorks",
                columns: new[] { "Id", "ImagePath", "Text", "Title" },
                values: new object[,]
                {
                    { 1, "/assets/img/recent-work-01.jpg", "Ullamco laboris nisi ut aliquip ex", "Social Media" },
                    { 2, "/assets/img/recent-work-02.jpg", "Psum officia anim id est laborum.", "Web Marketing" },
                    { 3, "/assets/img/recent-work-03.jpg", "Sum dolor sit consencutur", "R & D" },
                    { 4, "/assets/img/recent-work-04.jpg", "Lorem ipsum dolor sit amet", "Public Relation" },
                    { 5, "/assets/img/recent-work-05.jpg", "Put enim ad minim veniam", "Branding" },
                    { 6, "/assets/img/recent-work-06.jpg", "Mollit anim id est laborum.", "Creative Design" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecentWorks");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
