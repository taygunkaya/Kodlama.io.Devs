using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class taygun5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 11, 0, 28, 56, 546, DateTimeKind.Local).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 10, 11, 0, 28, 56, 546, DateTimeKind.Local).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 10, 11, 0, 28, 56, 546, DateTimeKind.Local).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt" },
                values: new object[] { "taygun@taygun.com", "Taygun", "taygun", new byte[] { 116, 97, 121, 103, 117, 110 }, new byte[] { 116, 97, 121, 103, 117, 110 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt" },
                values: new object[] { "sercan@sercan.com", "Sercan", "sercan", new byte[] { 115, 101, 114, 99, 97, 110 }, new byte[] { 115, 101, 114, 99, 97, 110 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 11, 0, 3, 0, 742, DateTimeKind.Local).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 10, 11, 0, 3, 0, 742, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 10, 11, 0, 3, 0, 742, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt" },
                values: new object[] { "salih@salih.com", "Salih", "ozturk", new byte[] { 115, 97, 108, 105, 104 }, new byte[] { 115, 97, 108, 105, 104 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt" },
                values: new object[] { "ahmet@ahmet.com", "Ahmet", "ahmet", new byte[] { 115, 97, 108, 105, 104 }, new byte[] { 115, 97, 108, 105, 104 } });
        }
    }
}
