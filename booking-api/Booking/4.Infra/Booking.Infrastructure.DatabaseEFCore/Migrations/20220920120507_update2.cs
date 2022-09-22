using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Infrastructure.DatabaseEFCore.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TB_USER",
                columns: new[] { "Id", "CreatedDate", "Email", "Password", "Role", "UpdatedDate", "Username" },
                values: new object[] { new Guid("d6df6771-ef40-4713-81d5-a0429cd34ab9"), new DateTime(2022, 3, 30, 16, 14, 37, 755, DateTimeKind.Local).AddTicks(4636), "guest@gmail.com", "guest", "guest", new DateTime(2022, 3, 30, 16, 14, 37, 758, DateTimeKind.Local).AddTicks(1509), "guest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_USER",
                keyColumn: "Id",
                keyValue: new Guid("d6df6771-ef40-4713-81d5-a0429cd34ab9"));
        }
    }
}
