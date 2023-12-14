using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_HomeWork_16.Migrations
{
    public partial class ContactAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactCards_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Description", "Text", "Title" },
                values: new object[] { 1, "Incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse ultrices\r\ngravida. Risus commodo viverra maecenas accumsan lacus vel facilisis. Laboris\r\nnisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit\r\nin voluptate.", "Elit, sed do eiusmod tempor", "Create success campaign with us!" });

            migrationBuilder.InsertData(
                table: "ContactCards",
                columns: new[] { "Id", "ContactId", "Fullname", "IconClassName", "PhoneNumber", "Title" },
                values: new object[] { 1, 1, "Mr. John Doe", "news", "010-020-0340", "Media Contact" });

            migrationBuilder.InsertData(
                table: "ContactCards",
                columns: new[] { "Id", "ContactId", "Fullname", "IconClassName", "PhoneNumber", "Title" },
                values: new object[] { 2, 1, "Mr. John Stiles", "laptop", "010-020-0340", "Technical Contact" });

            migrationBuilder.InsertData(
                table: "ContactCards",
                columns: new[] { "Id", "ContactId", "Fullname", "IconClassName", "PhoneNumber", "Title" },
                values: new object[] { 3, 1, "Mr. Richard Miles", "money", "010-020-0340", "Billing Contact" });

            migrationBuilder.CreateIndex(
                name: "IX_ContactCards_ContactId",
                table: "ContactCards",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactCards");

            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
