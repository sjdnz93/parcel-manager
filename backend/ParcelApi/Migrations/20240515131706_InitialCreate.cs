using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcelApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    ShipmentId = table.Column<string>(type: "TEXT", nullable: false),
                    Airport = table.Column<int>(type: "INTEGER", nullable: false),
                    DestinationCountry = table.Column<string>(type: "TEXT", nullable: false),
                    FlightNumber = table.Column<string>(type: "TEXT", nullable: false),
                    FlightDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsFinalised = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.ShipmentId);
                });

            migrationBuilder.CreateTable(
                name: "Bags",
                columns: table => new
                {
                    BagId = table.Column<string>(type: "TEXT", nullable: false),
                    BagType = table.Column<string>(type: "TEXT", nullable: true),
                    IsFinalised = table.Column<bool>(type: "INTEGER", nullable: false),
                    DestinationCountry = table.Column<string>(type: "TEXT", nullable: false),
                    ShipmentId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bags", x => x.BagId);
                    table.ForeignKey(
                        name: "FK_Bags_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "ShipmentId");
                });

            migrationBuilder.CreateTable(
                name: "LetterBag",
                columns: table => new
                {
                    BagId = table.Column<string>(type: "TEXT", nullable: false),
                    LetterCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterBag", x => x.BagId);
                    table.ForeignKey(
                        name: "FK_LetterBag_Bags_BagId",
                        column: x => x.BagId,
                        principalTable: "Bags",
                        principalColumn: "BagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelBag",
                columns: table => new
                {
                    BagId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelBag", x => x.BagId);
                    table.ForeignKey(
                        name: "FK_ParcelBag_Bags_BagId",
                        column: x => x.BagId,
                        principalTable: "Bags",
                        principalColumn: "BagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcels",
                columns: table => new
                {
                    ParcelId = table.Column<string>(type: "TEXT", nullable: false),
                    RecipientName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DestinationCountry = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ParcelBagBagId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.ParcelId);
                    table.ForeignKey(
                        name: "FK_Parcels_ParcelBag_ParcelBagBagId",
                        column: x => x.ParcelBagBagId,
                        principalTable: "ParcelBag",
                        principalColumn: "BagId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bags_ShipmentId",
                table: "Bags",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_ParcelBagBagId",
                table: "Parcels",
                column: "ParcelBagBagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LetterBag");

            migrationBuilder.DropTable(
                name: "Parcels");

            migrationBuilder.DropTable(
                name: "ParcelBag");

            migrationBuilder.DropTable(
                name: "Bags");

            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
