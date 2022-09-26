using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class testsercan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreteDate",
                table: "Language",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreteDate",
                value: new DateTime(2022, 9, 26, 15, 32, 40, 991, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreteDate",
                value: new DateTime(2022, 9, 26, 15, 32, 40, 991, DateTimeKind.Local).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreteDate",
                value: new DateTime(2022, 9, 26, 15, 32, 40, 991, DateTimeKind.Local).AddTicks(719));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreteDate",
                table: "Language");
        }
    }
}
