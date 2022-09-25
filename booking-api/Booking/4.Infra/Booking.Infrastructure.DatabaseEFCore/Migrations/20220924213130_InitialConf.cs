using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Infrastructure.DatabaseEFCore.Migrations
{
    public partial class InitialConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_RESERVATION",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RESERVATION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_ROOM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ROOM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_ROOM",
                columns: new[] { "Id", "CreatedDate", "Description", "UpdatedDate" },
                values: new object[] { new Guid("c83a4a7c-ccfd-4625-ae23-98cf9f62ba2a"), new DateTime(2022, 3, 30, 16, 14, 37, 755, DateTimeKind.Unspecified).AddTicks(4636), "The best room in the world! Beautiful view!", new DateTime(2022, 3, 30, 16, 14, 37, 758, DateTimeKind.Unspecified).AddTicks(1509) });

            migrationBuilder.InsertData(
                table: "TB_USER",
                columns: new[] { "Id", "CreatedDate", "Email", "Password", "Role", "UpdatedDate", "Username" },
                values: new object[,]
                {
                    { new Guid("4db89c05-1b67-4771-96a2-4b607d287123"), new DateTime(2022, 3, 30, 16, 14, 37, 755, DateTimeKind.Unspecified).AddTicks(4636), "admin@admin.com", "admin", "admin", new DateTime(2022, 3, 30, 16, 14, 37, 758, DateTimeKind.Unspecified).AddTicks(1509), "admin" },
                    { new Guid("d6df6771-ef40-4713-81d5-a0429cd34ab9"), new DateTime(2022, 3, 30, 16, 14, 37, 755, DateTimeKind.Unspecified).AddTicks(4636), "guest@gmail.com", "guest", "guest", new DateTime(2022, 3, 30, 16, 14, 37, 758, DateTimeKind.Unspecified).AddTicks(1509), "guest" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_RESERVATION");

            migrationBuilder.DropTable(
                name: "TB_ROOM");

            migrationBuilder.DropTable(
                name: "TB_USER");
        }
    }
}
