using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirQualityAPP.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "AirQualityData",
                newName: "Timestamp");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AirQualityData",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "AirQualityData");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "AirQualityData",
                newName: "DateTime");
        }
    }
}
