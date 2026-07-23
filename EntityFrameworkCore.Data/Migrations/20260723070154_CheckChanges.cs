using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class CheckChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Spain ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Spain");
        }
    }
}
