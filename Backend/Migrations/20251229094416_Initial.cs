using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
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
                    AddressLine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    TotalOrders = table.Column<int>(type: "int", nullable: true),
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
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
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
                    DeliveryUpAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PickUpContact = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DeliveryContact = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
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
                    PlatformFee = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NetEarnings = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IsPaidOut = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EarnedAt = table.Column<DateOnly>(type: "date", nullable: false),
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
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
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
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteData = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalDistance = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstimatedDuration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    OrderPlacementId = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Routes_OrderPlacements_OrderPlacementId",
                        column: x => x.OrderPlacementId,
                        principalTable: "OrderPlacements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDimension",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
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
                columns: new[] { "Id", "AddressLine", "City", "Label", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Main St", "Los Angeles", "Home", 1 },
                    { 2, "456 Business Rd", "Los Angeles", "Work", 2 },
                    { 3, "789 Oak St", "San Francisco", "Home", 3 },
                    { 4, "321 Pine Ave", "Lake Tahoe", "Vacation Home", 4 },
                    { 5, "654 Maple Dr", "Seattle", "Home", 5 },
                    { 6, "987 Birch Blvd", "Seattle", "Office", 6 },
                    { 7, "123 Elm St", "New York", "Home", 7 },
                    { 8, "456 Fitness Ln", "New York", "Gym", 8 },
                    { 9, "321 Cedar Ct", "Miami", "Home", 9 },
                    { 10, "654 Academy Blvd", "Miami", "School", 10 },
                    { 11, "234 Palm St", "Austin", "Home", 11 },
                    { 12, "567 Market St", "Austin", "Market", 12 }
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
                table: "Documents",
                columns: new[] { "Id", "DocumentType", "DriverId", "ExpiryDate", "FileUrl", "RejectionReason", "ReviewedAt", "ReviewedBy", "Status", "UploadedAt" },
                values: new object[,]
                {
                    { 2, "Insurance", 1, new DateOnly(2025, 5, 15), "http://example.com/documents/insurance1.pdf", "Awaiting verification", new DateTime(2023, 9, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "Bob Smith", "Pending", new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Registration", 2, new DateOnly(2026, 3, 1), "http://example.com/documents/registration1.pdf", "Expired document", new DateTime(2023, 9, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), "Charlie Brown", "Rejected", new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Vehicle Inspection", 3, new DateOnly(2025, 11, 30), "http://example.com/documents/inspection1.pdf", "None", new DateTime(2023, 9, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), "Diana Prince", "Approved", new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Driving History", 4, new DateOnly(2025, 8, 20), "http://example.com/documents/history1.pdf", "Awaiting submission", new DateTime(2023, 9, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), "Ethan Hunt", "Pending", new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Medical Certificate", 6, new DateOnly(2025, 1, 14), "http://example.com/documents/medical1.pdf", "None", new DateTime(2023, 9, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), "Fiona Gallagher", "Approved", new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OrderPlacements",
                columns: new[] { "Id", "CompletedOn", "CreatedAt", "CustomerId", "DeliveryContact", "DeliveryUpAddress", "Description", "DriverId", "PickUpAddress", "PickUpContact", "Price", "ScheduledAt", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jane Smith", "456 Elm St", "Electronics", null, "123 Main St", "John Doe", 300.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 2, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alice Brown", "789 Oak St", "Computers", null, "123 Main St", "John Doe", 500.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 3, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bob White", "101 Pine St", "Accessories", null, "123 Main St", "John Doe", 150.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 4, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lucy Green", "202 Maple St", "Furniture", null, "123 Main St", "John Doe", 600.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 5, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Tom Brown", "30 Center St", "Fresh Produce", null, "25 Market St", "Alice Green", 200.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 6, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Sarah White", "35 Park Ave", "Dairy Products", null, "25 Market St", "Alice Green", 300.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 7, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Daniel Black", "40 Broadway", "Packaged Goods", null, "25 Market St", "Alice Green", 250.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 8, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Emma Red", "45 Fifth St", "Beverages", null, "25 Market St", "Alice Green", 400.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 9, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Jim Doe", "50 Snack Ave", "Fast Food Order", null, "45 Fast Food Rd", "Alice Johnson", 50.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 10, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Kate Brown", "55 Snack Ave", "Burger Order", null, "45 Fast Food Rd", "Alice Johnson", 30.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 11, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Ben White", "60 Snack Ave", "Pizza Order", null, "45 Fast Food Rd", "Alice Johnson", 40.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 12, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Beth Green", "65 Snack Ave", "Dessert Order", null, "45 Fast Food Rd", "Alice Johnson", 20.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 13, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Alice Johnson", "110 Library Lane", "Books", null, "100 Book St", "John Smith", 25.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 14, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Bob White", "120 Library Lane", "Textbooks", null, "100 Book St", "John Smith", 45.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 15, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Charlie Black", "130 Library Lane", "Novels", null, "100 Book St", "John Smith", 50.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 16, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "David Green", "140 Library Lane", "Magazines", null, "100 Book St", "John Smith", 30.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 17, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "James Black", "160 Home Lane", "Home Goods", null, "150 Home St", "Emily White", 200.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 18, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Sarah Green", "170 Home Lane", "Furniture", null, "150 Home St", "Emily White", 800.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 19, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Paul Red", "180 Home Lane", "Kitchenware", null, "150 Home St", "Emily White", 150.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 20, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Jessica Blue", "190 Home Lane", "Decorations", null, "150 Home St", "Emily White", 100.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 21, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Anna Green", "210 Gym Lane", "Gym Equipment", null, "200 Fitness St", "Mike Brown", 500.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 22, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Laura Black", "220 Gym Lane", "Fitness Apparel", null, "200 Fitness St", "Mike Brown", 150.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 23, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Cathy White", "230 Gym Lane", "Health Supplements", null, "200 Fitness St", "Mike Brown", 300.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 24, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Sarah Blue", "240 Gym Lane", "Yoga Mats", null, "200 Fitness St", "Mike Brown", 100.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Color", "DriverId", "Height", "Length", "LicensePlate", "MakeYear", "MaxWeight", "Model", "Width" },
                values: new object[,]
                {
                    { 1, "Ford", "White", 1, 250m, 620m, "LU1 VAN", new DateOnly(2021, 1, 1), 1500.00m, "Transit Luton", 230m },
                    { 2, "Mercedes-Benz", "Silver", 2, 260m, 650m, "LU2 VAN", new DateOnly(2020, 1, 1), 1700.00m, "Sprinter Luton", 240m },
                    { 3, "Iveco", "Blue", 3, 270m, 680m, "LU3 VAN", new DateOnly(2022, 1, 1), 2000.00m, "Daily Luton", 240m },
                    { 4, "Volkswagen", "Red", 4, 265m, 660m, "LU4 VAN", new DateOnly(2021, 1, 1), 1800.00m, "Crafter Luton", 235m },
                    { 5, "Renault", "Yellow", 5, 255m, 630m, "LU5 VAN", new DateOnly(2023, 1, 1), 1600.00m, "Master Luton", 230m },
                    { 6, "Peugeot", "Green", 6, 270m, 670m, "LU6 VAN", new DateOnly(2022, 1, 1), 1900.00m, "Boxer Luton", 240m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "ItemName", "OrderPlacementId", "Quantity", "SpecialInstructions" },
                values: new object[,]
                {
                    { 1, "Laptop", 1, 1, "Handle with care" },
                    { 2, "Mouse", 2, 2, "Wireless" },
                    { 3, "Keyboard", 3, 1, "Mechanical" },
                    { 4, "Desk", 4, 1, "Assembly required" },
                    { 5, "Chair", 5, 1, "Comfortable" },
                    { 6, "Phone", 6, 1, "New model" },
                    { 7, "Charger", 7, 1, "Fast charging" },
                    { 8, "Couch", 8, 1, "Delivery on ground floor only" },
                    { 9, "Coffee Table", 9, 1, "Glass top" },
                    { 10, "T-Shirt", 10, 5, "Various colors" },
                    { 11, "Jeans", 11, 2, "Brand: XYZ" },
                    { 12, "Fruits Basket", 12, 1, "Seasonal fruits" },
                    { 13, "Vegetable Basket", 13, 1, "Organic" },
                    { 14, "Cookbook", 14, 1, "Best seller" },
                    { 15, "Spices Set", 15, 1, "Variety pack" },
                    { 16, "Headphones", 16, 1, "Noise cancelling" },
                    { 17, "Bluetooth Speaker", 17, 1, "Waterproof" },
                    { 18, "Backpack", 18, 1, "For travel" },
                    { 19, "Water Bottle", 19, 1, "Insulated" },
                    { 20, "Camera", 20, 1, "Includes accessories" },
                    { 21, "Tripod", 21, 1, "Adjustable height" },
                    { 22, "Blanket", 22, 1, "Soft and warm" },
                    { 23, "Pillow", 23, 2, "Memory foam" },
                    { 24, "Rug", 24, 1, "Non-slip" }
                });

            migrationBuilder.InsertData(
                table: "OrderTrackings",
                columns: new[] { "Id", "DeliveryLocation", "Notes", "OrderPlacementId", "PickUpLocation", "Status", "TimeStamps" },
                values: new object[,]
                {
                    { 1, "-118.2437", "Picked up from warehouse", 1, "34.0522", "In Transit", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "-118.2437", "Delivered to customer", 2, "34.0522", "Delivered", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "-118.2437", "On the way", 3, "34.0522", "In Transit", new DateTime(2023, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "-118.2437", "Received by customer", 4, "34.0522", "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "-118.2437", "Awaiting pickup", 5, "34.0522", "Pending", new DateTime(2023, 9, 15, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "-118.2437", "Picked up", 6, "34.0522", "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "-118.2437", "On the way to destination", 7, "34.0522", "In Transit", new DateTime(2023, 9, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "-118.2437", "Delivered successfully", 8, "34.0522", "Delivered", new DateTime(2023, 9, 15, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "-118.2437", "Waiting for dispatch", 9, "34.0522", "In Warehouse", new DateTime(2023, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "-118.2437", "On route to delivery", 10, "34.0522", "In Transit", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "-118.2437", "Awaiting confirmation", 11, "34.0522", "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "-118.2437", "Picked up", 12, "34.0522", "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "-118.2437", "On the way", 13, "34.0522", "In Transit", new DateTime(2023, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "-118.2437", "Delivered to customer", 14, "34.0522", "Delivered", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "-118.2437", "On the way", 15, "34.0522", "In Transit", new DateTime(2023, 9, 15, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "-118.2437", "Received by customer", 16, "34.0522", "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "-118.2437", "Awaiting pickup", 17, "34.0522", "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "-118.2437", "Picked up", 18, "34.0522", "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "-118.2437", "On the way to destination", 19, "34.0522", "In Transit", new DateTime(2023, 9, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "-118.2437", "Delivered successfully", 20, "34.0522", "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "-118.2437", "Waiting for dispatch", 21, "34.0522", "In Warehouse", new DateTime(2023, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "-118.2437", "On route to delivery", 22, "34.0522", "In Transit", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "-118.2437", "Awaiting confirmation", 23, "34.0522", "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "-118.2437", "Picked up", 24, "34.0522", "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) }
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
                table: "Routes",
                columns: new[] { "Id", "DriverId", "EstimatedDuration", "OrderPlacementId", "RouteData", "TotalDistance" },
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
                    { 24, 6, new DateTime(2024, 1, 1, 2, 55, 0, 0, DateTimeKind.Unspecified), 24, "Route 24 Data", "19.8 km" }
                });

            migrationBuilder.InsertData(
                table: "OrderDimension",
                columns: new[] { "Id", "Height", "Length", "OrderItemsId", "Width" },
                values: new object[,]
                {
                    { 1, 2.50m, 35.00m, 1, 25.00m },
                    { 2, 3.50m, 10.00m, 2, 6.00m },
                    { 3, 4.00m, 45.00m, 3, 15.00m },
                    { 4, 75.00m, 120.00m, 4, 60.00m },
                    { 5, 90.00m, 65.00m, 5, 65.00m },
                    { 6, 0.80m, 15.00m, 6, 7.50m },
                    { 7, 2.50m, 10.00m, 7, 5.00m },
                    { 8, 85.00m, 200.00m, 8, 90.00m },
                    { 9, 45.00m, 120.00m, 9, 60.00m },
                    { 10, 2.00m, 30.00m, 10, 25.00m },
                    { 11, 5.00m, 40.00m, 11, 20.00m },
                    { 12, 25.00m, 30.00m, 12, 30.00m },
                    { 13, 25.00m, 30.00m, 13, 30.00m },
                    { 14, 4.00m, 25.00m, 14, 20.00m },
                    { 15, 8.00m, 15.00m, 15, 10.00m },
                    { 16, 8.00m, 20.00m, 16, 18.00m },
                    { 17, 8.00m, 20.00m, 17, 8.00m },
                    { 18, 15.00m, 45.00m, 18, 30.00m },
                    { 19, 7.50m, 25.00m, 19, 7.50m },
                    { 20, 8.00m, 12.00m, 20, 9.00m },
                    { 21, 150.00m, 35.00m, 21, 35.00m },
                    { 22, 0.50m, 200.00m, 22, 150.00m },
                    { 23, 15.00m, 50.00m, 23, 50.00m },
                    { 24, 0.50m, 240.00m, 24, 160.00m }
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
                name: "IX_Documents_DriverId",
                table: "Documents",
                column: "DriverId");

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
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

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
                name: "IX_Routes_OrderPlacementId",
                table: "Routes",
                column: "OrderPlacementId");

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
                name: "Documents");

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
