using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
              migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MakeYear = table.Column<DateOnly>(type: "date", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaxWeight = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageData = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });



            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Color", "ContentType", "Description", "DriverId", "FileName", "FileSize", "Height", "ImageData", "Length", "LicensePlate", "MakeYear", "MaxWeight", "Model", "UploadedDate", "Width" },
                values: new object[,]
                {
                    { 1, "Ford", "White", "", null, 1, "", 0L, 250m, new byte[0], 620m, "LU1 VAN", new DateOnly(2021, 1, 1), 1500.00m, "Transit Luton", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 230m },
                    { 2, "Mercedes-Benz", "Silver", "", null, 2, "", 0L, 260m, new byte[0], 650m, "LU2 VAN", new DateOnly(2020, 1, 1), 1700.00m, "Sprinter Luton", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 240m },
                    { 3, "Iveco", "Blue", "", null, 3, "", 0L, 270m, new byte[0], 680m, "LU3 VAN", new DateOnly(2022, 1, 1), 2000.00m, "Daily Luton", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 240m },
                    { 4, "Volkswagen", "Red", "", null, 4, "", 0L, 265m, new byte[0], 660m, "LU4 VAN", new DateOnly(2021, 1, 1), 1800.00m, "Crafter Luton", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 235m },
                    { 5, "Renault", "Yellow", "", null, 5, "", 0L, 255m, new byte[0], 630m, "LU5 VAN", new DateOnly(2023, 1, 1), 1600.00m, "Master Luton", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 230m },
                    { 6, "Peugeot", "Green", "", null, 6, "", 0L, 270m, new byte[0], 670m, "LU6 VAN", new DateOnly(2022, 1, 1), 1900.00m, "Boxer Luton", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 240m }
                });



            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DriverId",
                table: "Vehicles",
                column: "DriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

        }
    }
}
