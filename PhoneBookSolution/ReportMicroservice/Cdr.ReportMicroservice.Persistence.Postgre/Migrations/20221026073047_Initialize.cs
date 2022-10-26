using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cdr.ReportMicroservice.Persistence.Postgre.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Reports",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReportStatus = table.Column<int>(type: "integer", nullable: false),
                    FilePath = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports",
                schema: "dbo");
        }
    }
}
