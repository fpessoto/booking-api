using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Infrastructure.DatabaseEFCore.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ROOM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ROOM", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_ROOM",
                columns: new[] { "Id", "CreatedDate", "Description", "UpdatedDate" },
                values: new object[] { new Guid("c83a4a7c-ccfd-4625-ae23-98cf9f62ba2a"), new DateTime(2022, 3, 30, 16, 14, 37, 755, DateTimeKind.Local).AddTicks(4636), "The best room in the world! Beautiful view!", new DateTime(2022, 3, 30, 16, 14, 37, 758, DateTimeKind.Local).AddTicks(1509) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ROOM");
        }
    }
}
