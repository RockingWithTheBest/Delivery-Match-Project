using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Earnings",
                columns: new[] { "Id", "DriverId", "Earned_At", "Gross_Amount", "Is_Paid_Out", "Net_Earnings", "Order_PlacementId", "Platform_Fee" },
                values: new object[,]
                {
                    { 1, 1, "2023-09-15 22:00:00", 1350.00m, "Yes", 1304.00m, 13, 46.00m },
                    { 2, 2, "2023-09-15 23:00:00", 1650.00m, "Yes", 1597.00m, 14, 53.00m },
                    { 3, 3, "2023-09-15", 630.00m, "Partial", 609.00m, 15, 21.00m },
                    { 4, 4, "2023-09-15 19:00:00", 1300.00m, "Yes", 1253.00m, 10, 47.00m },
                    { 5, 5, "2023-09-15 20:00:00", 970.00m, "Yes", 934.00m, 11, 36.00m },
                    { 6, 6, "2023-09-15 21:00:00", 245.00m, "Yes", 245.00m, 12, 0.00m }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "DriverId", "Estimated_Duration", "Order_PlacementId", "Route_Data", "Total_Distance" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 1, 2, 30, 0, 0, DateTimeKind.Unspecified), 1, "Route 1 Data", "15.2 km" },
                    { 2, 2, new DateTime(2024, 1, 1, 3, 15, 0, 0, DateTimeKind.Unspecified), 2, "Route 2 Data", "22.8 km" },
                    { 3, 3, new DateTime(2024, 1, 1, 2, 45, 0, 0, DateTimeKind.Unspecified), 3, "Route 3 Data", "18.5 km" },
                    { 4, 4, new DateTime(2024, 1, 1, 3, 30, 0, 0, DateTimeKind.Unspecified), 4, "Route 4 Data", "27.3 km" },
                    { 5, 5, new DateTime(2024, 1, 1, 1, 50, 0, 0, DateTimeKind.Unspecified), 5, "Route 5 Data", "12.1 km" },
                    { 6, 6, new DateTime(2024, 1, 1, 2, 55, 0, 0, DateTimeKind.Unspecified), 6, "Route 6 Data", "19.7 km" },
                    { 7, 1, new DateTime(2024, 1, 1, 3, 20, 0, 0, DateTimeKind.Unspecified), 7, "Route 7 Data", "24.9 km" },
                    { 8, 2, new DateTime(2024, 1, 1, 2, 25, 0, 0, DateTimeKind.Unspecified), 8, "Route 8 Data", "16.4 km" },
                    { 9, 3, new DateTime(2024, 1, 1, 3, 5, 0, 0, DateTimeKind.Unspecified), 9, "Route 9 Data", "21.2 km" },
                    { 10, 4, new DateTime(2024, 1, 1, 2, 15, 0, 0, DateTimeKind.Unspecified), 10, "Route 10 Data", "14.8 km" },
                    { 11, 5, new DateTime(2024, 1, 1, 3, 40, 0, 0, DateTimeKind.Unspecified), 11, "Route 11 Data", "23.6 km" },
                    { 12, 6, new DateTime(2024, 1, 1, 2, 40, 0, 0, DateTimeKind.Unspecified), 12, "Route 12 Data", "17.9 km" },
                    { 13, 1, new DateTime(2024, 1, 1, 3, 35, 0, 0, DateTimeKind.Unspecified), 13, "Route 13 Data", "26.1 km" },
                    { 14, 2, new DateTime(2024, 1, 1, 2, 10, 0, 0, DateTimeKind.Unspecified), 14, "Route 14 Data", "13.5 km" },
                    { 15, 3, new DateTime(2024, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified), 15, "Route 15 Data", "20.3 km" },
                    { 16, 4, new DateTime(2024, 1, 1, 3, 45, 0, 0, DateTimeKind.Unspecified), 16, "Route 16 Data", "25.7 km" },
                    { 17, 5, new DateTime(2024, 1, 1, 2, 35, 0, 0, DateTimeKind.Unspecified), 17, "Route 17 Data", "15.9 km" },
                    { 18, 6, new DateTime(2024, 1, 1, 3, 25, 0, 0, DateTimeKind.Unspecified), 18, "Route 18 Data", "22.4 km" },
                    { 19, 1, new DateTime(2024, 1, 1, 2, 50, 0, 0, DateTimeKind.Unspecified), 19, "Route 19 Data", "18.2 km" },
                    { 20, 2, new DateTime(2024, 1, 1, 3, 30, 0, 0, DateTimeKind.Unspecified), 20, "Route 20 Data", "24.3 km" },
                    { 21, 3, new DateTime(2024, 1, 1, 2, 30, 0, 0, DateTimeKind.Unspecified), 21, "Route 21 Data", "16.7 km" },
                    { 22, 4, new DateTime(2024, 1, 1, 3, 15, 0, 0, DateTimeKind.Unspecified), 22, "Route 22 Data", "21.9 km" },
                    { 23, 5, new DateTime(2024, 1, 1, 2, 20, 0, 0, DateTimeKind.Unspecified), 23, "Route 23 Data", "14.3 km" },
                    { 24, 6, new DateTime(2024, 1, 1, 2, 55, 0, 0, DateTimeKind.Unspecified), 24, "Route 24 Data", "19.8 km" },
                    { 25, 1, new DateTime(2024, 1, 1, 3, 50, 0, 0, DateTimeKind.Unspecified), 25, "Route 25 Data", "26.8 km" },
                    { 26, 2, new DateTime(2024, 1, 1, 2, 5, 0, 0, DateTimeKind.Unspecified), 26, "Route 26 Data", "12.9 km" },
                    { 27, 3, new DateTime(2024, 1, 1, 3, 20, 0, 0, DateTimeKind.Unspecified), 27, "Route 27 Data", "23.1 km" },
                    { 28, 4, new DateTime(2024, 1, 1, 2, 45, 0, 0, DateTimeKind.Unspecified), 28, "Route 28 Data", "17.4 km" },
                    { 29, 5, new DateTime(2024, 1, 1, 3, 35, 0, 0, DateTimeKind.Unspecified), 29, "Route 29 Data", "22.7 km" },
                    { 30, 6, new DateTime(2024, 1, 1, 2, 25, 0, 0, DateTimeKind.Unspecified), 30, "Route 30 Data", "15.6 km" },
                    { 31, 1, new DateTime(2024, 1, 1, 3, 10, 0, 0, DateTimeKind.Unspecified), 31, "Route 31 Data", "20.5 km" },
                    { 32, 2, new DateTime(2024, 1, 1, 3, 40, 0, 0, DateTimeKind.Unspecified), 32, "Route 32 Data", "25.2 km" },
                    { 33, 3, new DateTime(2024, 1, 1, 2, 15, 0, 0, DateTimeKind.Unspecified), 33, "Route 33 Data", "13.8 km" },
                    { 34, 4, new DateTime(2024, 1, 1, 2, 50, 0, 0, DateTimeKind.Unspecified), 34, "Route 34 Data", "18.9 km" },
                    { 35, 5, new DateTime(2024, 1, 1, 3, 30, 0, 0, DateTimeKind.Unspecified), 35, "Route 35 Data", "24.6 km" },
                    { 36, 6, new DateTime(2024, 1, 1, 2, 35, 0, 0, DateTimeKind.Unspecified), 36, "Route 36 Data", "16.2 km" },
                    { 37, 1, new DateTime(2024, 1, 1, 3, 15, 0, 0, DateTimeKind.Unspecified), 37, "Route 37 Data", "21.7 km" },
                    { 38, 2, new DateTime(2024, 1, 1, 2, 20, 0, 0, DateTimeKind.Unspecified), 38, "Route 38 Data", "14.6 km" },
                    { 39, 3, new DateTime(2024, 1, 1, 2, 55, 0, 0, DateTimeKind.Unspecified), 39, "Route 39 Data", "19.3 km" },
                    { 40, 4, new DateTime(2024, 1, 1, 3, 45, 0, 0, DateTimeKind.Unspecified), 40, "Route 40 Data", "26.4 km" },
                    { 41, 5, new DateTime(2024, 1, 1, 1, 55, 0, 0, DateTimeKind.Unspecified), 41, "Route 41 Data", "12.4 km" },
                    { 42, 6, new DateTime(2024, 1, 1, 3, 25, 0, 0, DateTimeKind.Unspecified), 42, "Route 42 Data", "23.8 km" },
                    { 43, 1, new DateTime(2024, 1, 1, 2, 40, 0, 0, DateTimeKind.Unspecified), 43, "Route 43 Data", "17.1 km" },
                    { 44, 2, new DateTime(2024, 1, 1, 3, 20, 0, 0, DateTimeKind.Unspecified), 44, "Route 44 Data", "22.2 km" },
                    { 45, 3, new DateTime(2024, 1, 1, 2, 30, 0, 0, DateTimeKind.Unspecified), 45, "Route 45 Data", "15.3 km" },
                    { 46, 4, new DateTime(2024, 1, 1, 3, 5, 0, 0, DateTimeKind.Unspecified), 46, "Route 46 Data", "20.8 km" },
                    { 47, 5, new DateTime(2024, 1, 1, 3, 50, 0, 0, DateTimeKind.Unspecified), 47, "Route 47 Data", "25.9 km" },
                    { 48, 6, new DateTime(2024, 1, 1, 2, 10, 0, 0, DateTimeKind.Unspecified), 48, "Route 48 Data", "13.2 km" },
                    { 49, 1, new DateTime(2024, 1, 1, 2, 50, 0, 0, DateTimeKind.Unspecified), 49, "Route 49 Data", "18.6 km" },
                    { 50, 2, new DateTime(2024, 1, 1, 3, 35, 0, 0, DateTimeKind.Unspecified), 50, "Route 50 Data", "24.1 km" },
                    { 51, 3, new DateTime(2024, 1, 1, 2, 40, 0, 0, DateTimeKind.Unspecified), 51, "Route 51 Data", "16.9 km" },
                    { 52, 4, new DateTime(2024, 1, 1, 3, 15, 0, 0, DateTimeKind.Unspecified), 52, "Route 52 Data", "21.4 km" },
                    { 53, 5, new DateTime(2024, 1, 1, 2, 25, 0, 0, DateTimeKind.Unspecified), 53, "Route 53 Data", "14.7 km" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Earnings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Earnings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Earnings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Earnings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Earnings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Earnings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 53);
        }
    }
}
