using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_HomeWork_16.Migrations
{
    public partial class TeamMembersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "Name", "PhotoName", "Position", "Surname" },
                values: new object[] { 1, "John", "team-01.jpg", "Business Development", "Doe" });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "Name", "PhotoName", "Position", "Surname" },
                values: new object[] { 2, "Jane", "team-02.jpg", "Media Development", "Doe" });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "Name", "PhotoName", "Position", "Surname" },
                values: new object[] { 3, "Sam", "team-03.jpg", "Developer", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamMembers");
        }
    }
}
