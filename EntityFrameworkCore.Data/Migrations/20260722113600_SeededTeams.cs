using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain " },
                    { 2, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "France " },
                    { 3, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Argentina " }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
