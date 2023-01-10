using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HistoryFilesFeeder.Migrations
{
    /// <inheritdoc />
    public partial class createDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntradayContinuous",
                columns: table => new
                {
                    DeliveryStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LowPrice = table.Column<double>(type: "float", nullable: true),
                    HighPrice = table.Column<double>(type: "float", nullable: true),
                    LastPrice = table.Column<double>(type: "float", nullable: true),
                    WeightedAveragePrice = table.Column<double>(type: "float", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastPriceTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VolumeBuy = table.Column<double>(type: "float", nullable: true),
                    VolumeSell = table.Column<double>(type: "float", nullable: true),
                    VolumeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntradayContinuous", x => x.DeliveryStart);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntradayContinuous");
        }
    }
}
