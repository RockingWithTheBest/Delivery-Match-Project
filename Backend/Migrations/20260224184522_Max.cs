using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Max : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RouteData",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Palace Square, 2, St. Petersburg, Russia, 191186", "Red Square, 1, Moscow, Russia, 101000" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Kuibysheva Street, 1, Samara, Russia, 443000", "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Red Square, 1, Moscow, Russia, 101000", "Palace Square, 2, St. Petersburg, Russia, 191186" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "Kuibysheva Street, 1, Samara, Russia, 443000" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Red Square, 1, Moscow, Russia, 101000", "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Palace Square, 2, St. Petersburg, Russia, 191186", "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Kuibysheva Street, 1, Samara, Russia, 443000", "Palace Square, 2, St. Petersburg, Russia, 191186" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Red Square, 1, Moscow, Russia, 101000" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Red Square, 1, Moscow, Russia, 101000", "Kuibysheva Street, 1, Samara, Russia, 443000" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Kuibysheva Street, 1, Samara, Russia, 443000", "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Palace Square, 2, St. Petersburg, Russia, 191186", "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "Red Square, 1, Moscow, Russia, 101000" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Palace Square, 2, St. Petersburg, Russia, 191186" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "Kuibysheva Street, 1, Samara, Russia, 443000" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Palace Square, 2, St. Petersburg, Russia, 191186", "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Red Square, 1, Moscow, Russia, 101000", "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Kuibysheva Street, 1, Samara, Russia, 443000", "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000t" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Red Square, 1, Moscow, Russia, 101000", "Palace Square, 2, St. Petersburg, Russia, 191186" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "Red Square, 1, Moscow, Russia, 101000" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Kuibysheva Street, 1, Samara, Russia, 443000" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "59.9343,30.3351", "55.7558,37.6173" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "54.7349,55.9579", "55.7961,49.1064" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "54.7261,55.9475", "56.3269,44.0075" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "55.7961,49.1064", "54.7349,55.9579" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "55.7558,37.6173", "59.9343,30.3351" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "56.3269,44.0075", "54.7261,55.9475" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "55.7558,37.6173", "55.7961,49.1064" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "59.9343,30.3351", "54.7349,55.9579" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "54.7349,55.9579", "56.3269,44.0075" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "54.7261,55.9475", "59.9343,30.3351" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "55.7961,49.1064", "55.7558,37.6173" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "55.7558,37.6173", "54.7261,55.9475" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "54.7261,55.9475", "55.7961,49.1064" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "56.3269,44.0075", "54.7349,55.9579" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "59.9343,30.3351", "56.3269,44.0075" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "54.7349,55.9579", "55.7558,37.6173" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "55.7961,49.1064", "59.9343,30.3351" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "56.3269,44.0075", "54.7261,55.9475" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "59.9343,30.3351", "55.7961,49.1064" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "55.7558,37.6173", "54.7349,55.9579" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "54.7261,55.9475", "56.3269,44.0075" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "55.7558,37.6173", "59.9343,30.3351" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "56.3269,44.0075", "55.7558,37.6173" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "55.7961,49.1064", "54.7261,55.9475" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RouteData",
                table: "Routes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "456 Elm St", "123 Main St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "789 Oak St", "123 Main St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "101 Pine St", "123 Main St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "202 Maple St", "123 Main St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "30 Center St", "25 Market St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "35 Park Ave", "25 Market St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "40 Broadway", "25 Market St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "45 Fifth St", "25 Market St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "50 Snack Ave", "45 Fast Food Rd" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "55 Snack Ave", "45 Fast Food Rd" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "60 Snack Ave", "45 Fast Food Rd" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "65 Snack Ave", "45 Fast Food Rd" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "110 Library Lane", "100 Book St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "120 Library Lane", "100 Book St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "130 Library Lane", "100 Book St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "140 Library Lane", "100 Book St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "160 Home Lane", "150 Home St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "170 Home Lane", "150 Home St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "180 Home Lane", "150 Home St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "190 Home Lane", "150 Home St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "210 Gym Lane", "200 Fitness St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "220 Gym Lane", "200 Fitness St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "230 Gym Lane", "200 Fitness St" });

            migrationBuilder.UpdateData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "DeliveryUpAddress", "PickUpAddress" },
                values: new object[] { "240 Gym Lane", "200 Fitness St" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "DeliveryLocation", "PickUpLocation" },
                values: new object[] { "-118.2437", "34.0522" });
        }
    }
}
