using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirQualityAPP.Migrations
{
    /// <inheritdoc />
    public partial class InitD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "AirQualityData");

            migrationBuilder.RenameColumn(
                name: "Aqi",
                table: "AirQualityData",
                newName: "AQI");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "AirQualityData",
                newName: "RetrievedAt");

            migrationBuilder.AlterColumn<int>(
                name: "AQI",
                table: "AirQualityData",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "AirQualityData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "AirQualityData",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "AirQualityData");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "AirQualityData");

            migrationBuilder.RenameColumn(
                name: "AQI",
                table: "AirQualityData",
                newName: "Aqi");

            migrationBuilder.RenameColumn(
                name: "RetrievedAt",
                table: "AirQualityData",
                newName: "Timestamp");

            migrationBuilder.AlterColumn<float>(
                name: "Aqi",
                table: "AirQualityData",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AirQualityData",
                type: "text",
                nullable: true);
        }
    }
}
