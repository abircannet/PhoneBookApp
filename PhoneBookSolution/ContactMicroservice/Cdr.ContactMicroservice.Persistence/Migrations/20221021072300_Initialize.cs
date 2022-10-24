using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cdr.ContactMicroservice.Persistence.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactDetailType = table.Column<byte>(type: "tinyint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactDetails_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "dbo",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_ContactDetailType",
                schema: "dbo",
                table: "ContactDetails",
                column: "ContactDetailType");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_ContactId",
                schema: "dbo",
                table: "ContactDetails",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "dbo");
        }
    }
}
