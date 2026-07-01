using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class in1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BusinessType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TaxIdentification = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TotalOrders = table.Column<int>(type: "int", nullable: false),
                    TotalSpent = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriversLicense = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LicenseExpiry = table.Column<DateOnly>(type: "date", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CompletionRate = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TotalEarnings = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPlacements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickUpAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeliveryUpAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PickUpContact = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DeliveryContact = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Distance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPlacements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPlacements_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPlacements_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDistance = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstimatedDuration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    TravelinSequency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Earnings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrossAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EarnedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: true),
                    OrderPlacementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Earnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Earnings_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Earnings_OrderPlacements_OrderPlacementId",
                        column: x => x.OrderPlacementId,
                        principalTable: "OrderPlacements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DriverCommentry = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    OrderPlacementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_OrderPlacements_OrderPlacementId",
                        column: x => x.OrderPlacementId,
                        principalTable: "OrderPlacements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    WeightPerItem = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    SpecialInstructions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderPlacementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_OrderPlacements_OrderPlacementId",
                        column: x => x.OrderPlacementId,
                        principalTable: "OrderPlacements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickUpLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeliveryLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TimeStamps = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderPlacementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTrackings_OrderPlacements_OrderPlacementId",
                        column: x => x.OrderPlacementId,
                        principalTable: "OrderPlacements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TransactionIdentification = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProcessedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlatformFee = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DriverEarnings = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    OrderPlacementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_OrderPlacements_OrderPlacementId",
                        column: x => x.OrderPlacementId,
                        principalTable: "OrderPlacements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDimension",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    OrderItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDimension", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDimension_OrderItems_OrderItemsId",
                        column: x => x.OrderItemsId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "John", "Doe", "P@ss0rd1", "1234567890" },
                    { 2, "janesmith@example.com", "Jane", "Smith", "S3cr3P@s", "2345678901" },
                    { 3, "alciejohnson@example.com", "Alice", "Johnson", "A1i3#Pas", "3456789012" },
                    { 4, "bobbrown@example.com", "Bob", "Brown", "B0b$T0ub", "4567890123" },
                    { 5, "charliedavis@example.com", "Charlie", "Davis", "Ch@rie1$", "5678901234" },
                    { 6, "dianamiller@example.com", "Diana", "Miller", "D1na!Cmp", "6789012345" },
                    { 7, "ethanwilson@example.com", "Ethan", "Wilson", "Ethn1234", "7890123456" },
                    { 8, "fionamoore@example.com", "Foina", "Moore", "F!0nC0d3", "8901234567" },
                    { 9, "georgetaylor@example.com", "George", "Taylor", "G3rge@20", "9012345678" },
                    { 10, "hannahanderson@example.com", "Hannah", "Anderson", "H@nah202", "0123456789" },
                    { 11, "brunofernandes@example.com", "Bruno", "Fernandes", "F@brno20", "0129756789" },
                    { 12, "cristianojuan@example.com", "Cristiano", "Juan", "C@juan02", "4208656789" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Label", "Latitude", "Location", "Longitude", "UserId" },
                values: new object[,]
                {
                    { 1, "Home", null, "123 Main St", null, 1 },
                    { 2, "Work", null, "456 Business Rd", null, 2 },
                    { 3, "Home", null, "789 Oak St", null, 3 },
                    { 4, "Vacation Home", null, "321 Pine Ave", null, 4 },
                    { 5, "Home", null, "654 Maple Dr", null, 5 },
                    { 6, "Office", null, "987 Birch Blvd", null, 6 },
                    { 7, "Home", "55.75100000000001", "Kremlin, Moscow", "37.61760000000001", 7 },
                    { 8, "Gym", "59.88520000000001", "Samson Fountain, Saint Petersburg", "29.90910000000001", 8 },
                    { 9, "Home", "55.80060000000001", "Temple of all Religions, Kazan", "48.97470000000001", 9 },
                    { 10, "School", "55.76670000000001", "Ice Palace, Moscow", "37.43520000000001", 10 },
                    { 11, "Home", null, "234 Palm St", null, 11 },
                    { 12, "Market", null, "567 Market St", null, 12 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BusinessName", "BusinessType", "Rating", "TaxIdentification", "TotalOrders", "TotalSpent", "UserId" },
                values: new object[,]
                {
                    { 1, "Tech Solutions", "IT Services", "4.5", "TS123456A", 4, 1500.00m, 1 },
                    { 2, "Green Grocers", "Retail", "4.8", "GG987654B", 4, 2200.00m, 2 },
                    { 3, "Fast Foodies", "Food & Beverage", "4.3", "FF456789C", 4, 800.00m, 3 },
                    { 4, "Book Haven", "Retail", "4.7", "BH321654D", 4, 1200.00m, 4 },
                    { 5, "Home Essentials", "Retail", "4.6", "HE654123E", 4, 1600.00m, 5 },
                    { 6, "Fitness Hub", "Health & Fitness", "4.9", "FH159753F", 4, 3000.00m, 6 }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CompletionRate", "DriversLicense", "IsAvailable", "IsVerified", "LicenseExpiry", "Rating", "TotalEarnings", "UserId" },
                values: new object[,]
                {
                    { 1, "95%", "DL123456789", true, true, new DateOnly(2025, 12, 31), "4.8", 1500.00m, 7 },
                    { 2, "90%", "DL987654321", true, true, new DateOnly(2025, 11, 15), "4.5", 1200.00m, 8 },
                    { 3, "92%", "DL456123789", true, true, new DateOnly(2026, 5, 1), "4.6", 1800.00m, 9 },
                    { 4, "93%", "DL321654987", true, true, new DateOnly(2025, 10, 30), "4.7", 1600.00m, 10 },
                    { 5, "97%", "DL159753468", true, true, new DateOnly(2026, 1, 14), "4.9", 2000.00m, 11 },
                    { 6, "89%", "DL753159864", true, true, new DateOnly(2025, 8, 20), "4.4", 1400.00m, 12 }
                });

            migrationBuilder.InsertData(
                table: "OrderPlacements",
                columns: new[] { "Id", "CompletedOn", "CreatedAt", "CustomerId", "DeliveryContact", "DeliveryUpAddress", "Description", "Distance", "DriverId", "PickUpAddress", "PickUpContact", "Price", "ScheduledAt", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jane Smith", "Palace Square, 2, St. Petersburg, Russia, 191186", "Electronics", 0m, null, "Red Square, 1, Moscow, Russia, 101000", "John Doe", 300.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 2, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alice Brown", "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "Computers", 0m, null, "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "John Doe", 500.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 3, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bob White", "Kuibysheva Street, 1, Samara, Russia, 443000", "Accessories", 0m, null, "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "John Doe", 150.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 4, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lucy Green", "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Furniture", 0m, null, "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "John Doe", 600.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 5, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Tom Brown", "Red Square, 1, Moscow, Russia, 101000", "Fresh Produce", 0m, null, "Palace Square, 2, St. Petersburg, Russia, 191186", "Alice Green", 200.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 6, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Sarah White", "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "Dairy Products", 0m, null, "Kuibysheva Street, 1, Samara, Russia, 443000", "Alice Green", 300.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 7, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Daniel Black", "Red Square, 1, Moscow, Russia, 101000", "Packaged Goods", 0m, null, "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Alice Green", 250.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 8, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Emma Red", "Palace Square, 2, St. Petersburg, Russia, 191186", "Beverages", 0m, null, "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "Alice Green", 400.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 9, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Jim Doe", "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "Fast Food Order", 0m, null, "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "Alice Johnson", 50.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 10, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Kate Brown", "Kuibysheva Street, 1, Samara, Russia, 443000", "Burger Order", 0m, null, "Palace Square, 2, St. Petersburg, Russia, 191186", "Alice Johnson", 30.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 11, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Ben White", "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Pizza Order", 0m, null, "Red Square, 1, Moscow, Russia, 101000", "Alice Johnson", 40.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 12, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Beth Green", "Red Square, 1, Moscow, Russia, 101000", "Dessert Order", 0m, null, "Kuibysheva Street, 1, Samara, Russia, 443000", "Alice Johnson", 20.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 13, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Alice Johnson", "Kuibysheva Street, 1, Samara, Russia, 443000", "Books", 0m, null, "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "John Smith", 25.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 14, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Bob White", "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "Textbooks", 0m, null, "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "John Smith", 45.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 15, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Charlie Black", "Palace Square, 2, St. Petersburg, Russia, 191186", "Novels", 0m, null, "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "John Smith", 50.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 16, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "David Green", "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "Magazines", 0m, null, "Red Square, 1, Moscow, Russia, 101000", "John Smith", 30.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 17, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "James Black", "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Home Goods", 0m, null, "Palace Square, 2, St. Petersburg, Russia, 191186", "Emily White", 200.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 18, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Sarah Green", "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "Furniture", 0m, null, "Kuibysheva Street, 1, Samara, Russia, 443000", "Emily White", 800.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 19, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Paul Red", "Palace Square, 2, St. Petersburg, Russia, 191186", "Kitchenware", 0m, null, "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Emily White", 150.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 20, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Jessica Blue", "Red Square, 1, Moscow, Russia, 101000", "Decorations", 0m, null, "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "Emily White", 100.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 21, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Anna Green", "Kuibysheva Street, 1, Samara, Russia, 443000", "Gym Equipment", 0m, null, "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000t", "Mike Brown", 500.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 22, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Laura Black", "Red Square, 1, Moscow, Russia, 101000", "Fitness Apparel", 0m, null, "Palace Square, 2, St. Petersburg, Russia, 191186", "Mike Brown", 150.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 23, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Cathy White", "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "Health Supplements", 0m, null, "Red Square, 1, Moscow, Russia, 101000", "Mike Brown", 300.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 24, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Sarah Blue", "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Yoga Mats", 0m, null, "Kuibysheva Street, 1, Samara, Russia, 443000", "Mike Brown", 100.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" }
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

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "ItemName", "OrderPlacementId", "Quantity", "SpecialInstructions", "WeightPerItem" },
                values: new object[,]
                {
                    { 1, "Laptop", 1, 1, "Handle with care", 50.00m },
                    { 2, "Mouse", 2, 2, "Wireless", 50.00m },
                    { 3, "Keyboard", 3, 1, "Mechanical", 50.00m },
                    { 4, "Desk", 4, 1, "Assembly required", 50.00m },
                    { 5, "Chair", 5, 1, "Comfortable", 50.00m },
                    { 6, "Phone", 6, 1, "New model", 60.00m },
                    { 7, "Charger", 7, 1, "Fast charging", 60.00m },
                    { 8, "Couch", 8, 1, "Delivery on ground floor only", 60.00m },
                    { 9, "Coffee Table", 9, 1, "Glass top", 60.00m },
                    { 10, "T-Shirt", 10, 5, "Various colors", 60.00m },
                    { 11, "Jeans", 11, 2, "Brand: XYZ", 60.00m },
                    { 12, "Fruits Basket", 12, 1, "Seasonal fruits", 60.00m },
                    { 13, "Vegetable Basket", 13, 1, "Organic", 60.00m },
                    { 14, "Cookbook", 14, 1, "Best seller", 60.00m },
                    { 15, "Spices Set", 15, 1, "Variety pack", 60.00m },
                    { 16, "Headphones", 16, 1, "Noise cancelling", 60.00m },
                    { 17, "Bluetooth Speaker", 17, 1, "Waterproof", 60.00m },
                    { 18, "Backpack", 18, 1, "For travel", 60.00m },
                    { 19, "Water Bottle", 19, 1, "Insulated", 60.00m },
                    { 20, "Camera", 20, 1, "Includes accessories", 60.00m },
                    { 21, "Tripod", 21, 1, "Adjustable height", 60.00m },
                    { 22, "Blanket", 22, 1, "Soft and warm", 60.00m },
                    { 23, "Pillow", 23, 2, "Memory foam", 60.00m },
                    { 24, "Rug", 24, 1, "Non-slip", 60.00m }
                });

            migrationBuilder.InsertData(
                table: "OrderTrackings",
                columns: new[] { "Id", "DeliveryLocation", "Notes", "OrderPlacementId", "PickUpLocation", "Status", "TimeStamps" },
                values: new object[,]
                {
                    { 1, "59.9343,30.3351", "Picked up from warehouse", 1, "55.7558,37.6173", "In Transit", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "54.7349,55.9579", "Delivered to customer", 2, "55.7961,49.1064", "Delivered", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "54.7261,55.9475", "On the way", 3, "56.3269,44.0075", "In Transit", new DateTime(2023, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "55.7961,49.1064", "Received by customer", 4, "54.7349,55.9579", "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "55.7558,37.6173", "Awaiting pickup", 5, "59.9343,30.3351", "Pending", new DateTime(2023, 9, 15, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "56.3269,44.0075", "Picked up", 6, "54.7261,55.9475", "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "55.7558,37.6173", "On the way to destination", 7, "55.7961,49.1064", "In Transit", new DateTime(2023, 9, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "59.9343,30.3351", "Delivered successfully", 8, "54.7349,55.9579", "Delivered", new DateTime(2023, 9, 15, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "54.7349,55.9579", "Waiting for dispatch", 9, "56.3269,44.0075", "In Warehouse", new DateTime(2023, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "54.7261,55.9475", "On route to delivery", 10, "59.9343,30.3351", "In Transit", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "55.7961,49.1064", "Awaiting confirmation", 11, "55.7558,37.6173", "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "55.7558,37.6173", "Picked up", 12, "54.7261,55.9475", "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "54.7261,55.9475", "On the way", 13, "55.7961,49.1064", "In Transit", new DateTime(2023, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "56.3269,44.0075", "Delivered to customer", 14, "54.7349,55.9579", "Delivered", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "59.9343,30.3351", "On the way", 15, "56.3269,44.0075", "In Transit", new DateTime(2023, 9, 15, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "54.7349,55.9579", "Received by customer", 16, "55.7558,37.6173", "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "55.7961,49.1064", "Awaiting pickup", 17, "59.9343,30.3351", "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "56.3269,44.0075", "Picked up", 18, "54.7261,55.9475", "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "59.9343,30.3351", "On the way to destination", 19, "55.7961,49.1064", "In Transit", new DateTime(2023, 9, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "55.7558,37.6173", "Delivered successfully", 20, "54.7349,55.9579", "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "54.7261,55.9475", "Waiting for dispatch", 21, "56.3269,44.0075", "In Warehouse", new DateTime(2023, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "55.7558,37.6173", "On route to delivery", 22, "59.9343,30.3351", "In Transit", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "56.3269,44.0075", "Awaiting confirmation", 23, "55.7558,37.6173", "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "55.7961,49.1064", "Picked up", 24, "54.7261,55.9475", "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "DriverEarnings", "OrderPlacementId", "PaymentMethod", "PlatformFee", "ProcessedAt", "Status", "TransactionIdentification" },
                values: new object[,]
                {
                    { 1, 300.00m, 290.00m, 1, "Credit Card", 10.00m, new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN001" },
                    { 2, 500.00m, 485.00m, 2, "PayPal", 15.00m, new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN002" },
                    { 3, 150.00m, 145.00m, 3, "Debit Card", 5.00m, null, "Pending", "TXN003" },
                    { 4, 600.00m, 580.00m, 4, "Credit Card", 20.00m, new DateTime(2023, 9, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN004" },
                    { 5, 200.00m, 192.00m, 5, "Bank Transfer", 8.00m, new DateTime(2023, 9, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN005" },
                    { 6, 80.00m, 80.00m, 6, "Cash", 0.00m, new DateTime(2023, 12, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN006" },
                    { 7, 300.00m, 290.00m, 7, "Credit Card", 10.00m, new DateTime(2023, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN007" },
                    { 8, 450.00m, 435.00m, 8, "PayPal", 15.00m, new DateTime(2023, 9, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN008" },
                    { 9, 150.00m, 145.00m, 9, "Debit Card", 5.00m, null, "Pending", "TXN009" },
                    { 10, 700.00m, 675.00m, 10, "Credit Card", 25.00m, new DateTime(2023, 9, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN010" },
                    { 11, 250.00m, 240.00m, 11, "Bank Transfer", 10.00m, new DateTime(2023, 9, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN011" },
                    { 12, 90.00m, 90.00m, 12, "Cash", 0.00m, new DateTime(2023, 9, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN012" },
                    { 13, 350.00m, 338.00m, 13, "Credit Card", 12.00m, new DateTime(2023, 9, 15, 22, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN013" },
                    { 14, 500.00m, 485.00m, 14, "PayPal", 15.00m, new DateTime(2023, 9, 15, 23, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN014" },
                    { 15, 180.00m, 174.00m, 15, "Debit Card", 6.00m, null, "Pending", "TXN015" },
                    { 16, 650.00m, 628.00m, 16, "Credit Card", 22.00m, new DateTime(2023, 9, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN016" },
                    { 17, 220.00m, 212.00m, 17, "Bank Transfer", 8.00m, new DateTime(2023, 9, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN017" },
                    { 18, 75.00m, 75.00m, 18, "Cash", 0.00m, new DateTime(2023, 9, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN018" },
                    { 19, 400.00m, 386.00m, 19, "Credit Card", 14.00m, new DateTime(2023, 9, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN019" },
                    { 20, 600.00m, 580.00m, 20, "PayPal", 20.00m, new DateTime(2023, 9, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN020" },
                    { 21, 150.00m, 145.00m, 21, "Debit Card", 5.00m, null, "Pending", "TXN021" },
                    { 22, 300.00m, 290.00m, 22, "Credit Card", 10.00m, new DateTime(2023, 9, 16, 15, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN022" },
                    { 23, 200.00m, 192.00m, 23, "Bank Transfer", 8.00m, new DateTime(2023, 9, 16, 16, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN023" },
                    { 24, 80.00m, 80.00m, 24, "Cash", 0.00m, new DateTime(2023, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "TXN024" }
                });

            migrationBuilder.InsertData(
                table: "OrderDimension",
                columns: new[] { "Id", "Height", "Length", "OrderItemsId", "Width" },
                values: new object[,]
                {
                    { 1, 200.50m, 305.00m, 1, 250.00m },
                    { 2, 563.50m, 100.00m, 2, 600.00m },
                    { 3, 400.00m, 405.00m, 3, 105.00m },
                    { 4, 175.00m, 120.00m, 4, 160.00m },
                    { 5, 190.00m, 165.00m, 5, 165.00m },
                    { 6, 210.80m, 215.00m, 6, 207.50m },
                    { 7, 202.50m, 110.00m, 7, 15.00m },
                    { 8, 185.00m, 200.00m, 8, 190.00m },
                    { 9, 245.00m, 120.00m, 9, 260.00m },
                    { 10, 232.00m, 130.00m, 10, 225.00m },
                    { 11, 51.00m, 540.00m, 11, 120.00m },
                    { 12, 125.00m, 230.00m, 12, 130.00m },
                    { 13, 125.00m, 230.00m, 13, 130.00m },
                    { 14, 24.00m, 225.00m, 14, 220.00m },
                    { 15, 208.00m, 105.00m, 15, 100.00m },
                    { 16, 108.00m, 220.00m, 16, 218.00m },
                    { 17, 108.00m, 200.00m, 17, 208.00m },
                    { 18, 215.00m, 145.00m, 18, 230.00m },
                    { 19, 107.50m, 125.00m, 19, 107.50m },
                    { 20, 208.00m, 120.00m, 20, 109.00m },
                    { 21, 150.00m, 235.00m, 21, 235.00m },
                    { 22, 220.50m, 200.00m, 22, 150.00m },
                    { 23, 215.00m, 150.00m, 23, 150.00m },
                    { 24, 200.50m, 240.00m, 24, 160.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserId",
                table: "Drivers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Earnings_DriverId",
                table: "Earnings",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Earnings_OrderPlacementId",
                table: "Earnings",
                column: "OrderPlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CustomerId",
                table: "Notifications",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_DriverId",
                table: "Notifications",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_OrderPlacementId",
                table: "Notifications",
                column: "OrderPlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDimension_OrderItemsId",
                table: "OrderDimension",
                column: "OrderItemsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderPlacementId",
                table: "OrderItems",
                column: "OrderPlacementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderPlacements_CustomerId",
                table: "OrderPlacements",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPlacements_DriverId",
                table: "OrderPlacements",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTrackings_OrderPlacementId",
                table: "OrderTrackings",
                column: "OrderPlacementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderPlacementId",
                table: "Payments",
                column: "OrderPlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DriverId",
                table: "Routes",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DriverId",
                table: "Vehicles",
                column: "DriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Earnings");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "OrderDimension");

            migrationBuilder.DropTable(
                name: "OrderTrackings");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrderPlacements");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
