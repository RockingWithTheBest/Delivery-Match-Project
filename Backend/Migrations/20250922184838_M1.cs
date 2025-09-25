using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Business_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Business_Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tax_Identification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Total_Orders = table.Column<int>(type: "int", nullable: false),
                    Total_Spent = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
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
                    Drivers_License = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    License_Expiry = table.Column<DateOnly>(type: "date", nullable: false),
                    Is_Verified = table.Column<bool>(type: "bit", nullable: false),
                    Is_Available = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Completion_Rate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_Earnings = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Read = table.Column<bool>(type: "bit", nullable: true),
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
                    Document_Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    File_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiry_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rejection_Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uploaded_At = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reviewed_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reviewed_At = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    Pick_Up_Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Delivery_Up_Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Pick_Up_Contact = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Delivery_Contact = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Distance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scheduled_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Completed_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    DriverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPlacements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPlacements_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
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
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make_Year = table.Column<DateOnly>(type: "date", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    License_Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Max_Weight = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Max_Volume = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
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
                    Gross_Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Platform_Fee = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Net_Earnings = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Is_Paid_Out = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Earned_At = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: true),
                    Order_PlacementId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Earnings_OrderPlacements_Order_PlacementId",
                        column: x => x.Order_PlacementId,
                        principalTable: "OrderPlacements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Weight_Per_Item = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Special_Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_PlacementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_OrderPlacements_Order_PlacementId",
                        column: x => x.Order_PlacementId,
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
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamps = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Order_PlacementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTrackings_OrderPlacements_Order_PlacementId",
                        column: x => x.Order_PlacementId,
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
                    Payment_Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Transaction_Identification = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Processed_At = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform_Fee = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Driver_Earnings = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Order_PlacementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_OrderPlacements_Order_PlacementId",
                        column: x => x.Order_PlacementId,
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
                    Route_Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_Distance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estimated_Duration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    Order_PlacementId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Routes_OrderPlacements_Order_PlacementId",
                        column: x => x.Order_PlacementId,
                        principalTable: "OrderPlacements",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "First_Name", "Last_Name", "Password", "Phone" },
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
                columns: new[] { "Id", "Address_Line", "City", "Label", "UserId" },
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
                columns: new[] { "Id", "Business_Name", "Business_Type", "Rating", "Tax_Identification", "Total_Orders", "Total_Spent", "UserId" },
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
                columns: new[] { "Id", "Completion_Rate", "Drivers_License", "Is_Available", "Is_Verified", "License_Expiry", "Rating", "Total_Earnings", "UserId" },
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
                columns: new[] { "Id", "Document_Type", "DriverId", "Expiry_Date", "File_Url", "Rejection_Reason", "Reviewed_At", "Reviewed_By", "Status", "Uploaded_At" },
                values: new object[,]
                {
                    { 2, "Insurance", 1, new DateOnly(2025, 5, 15), "http://example.com/documents/insurance1.pdf", "Awaiting verification", new DateTime(2023, 9, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "Bob Smith", "Pending", "2023-09-02" },
                    { 3, "Registration", 2, new DateOnly(2026, 3, 1), "http://example.com/documents/registration1.pdf", "Expired document", new DateTime(2023, 9, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), "Charlie Brown", "Rejected", "2023-09-03" },
                    { 4, "Vehicle Inspection", 3, new DateOnly(2025, 11, 30), "http://example.com/documents/inspection1.pdf", "None", new DateTime(2023, 9, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), "Diana Prince", "Approved", "2023-09-04" },
                    { 5, "Driving History", 4, new DateOnly(2025, 8, 20), "http://example.com/documents/history1.pdf", "Awaiting submission", new DateTime(2023, 9, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), "Ethan Hunt", "Pending", "2023-09-05" },
                    { 6, "Medical Certificate", 6, new DateOnly(2025, 1, 14), "http://example.com/documents/medical1.pdf", "None", new DateTime(2023, 9, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), "Fiona Gallagher", "Approved", "2023-09-06" }
                });

            migrationBuilder.InsertData(
                table: "OrderPlacements",
                columns: new[] { "Id", "Completed_On", "Created_At", "CustomerId", "Delivery_Contact", "Delivery_Up_Address", "Description", "Distance", "DriverId", "Pick_Up_Address", "Pick_Up_Contact", "Price", "Scheduled_At", "Status", "Volume", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-01", 1, "Jane Smith", "456 Elm St", "Electronics", "10 miles", null, "123 Main St", "John Doe", 300.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 2.0m, 5.5m },
                    { 2, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-02", 1, "Alice Brown", "789 Oak St", "Computers", "15 miles", null, "123 Main St", "John Doe", 500.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit", 1.5m, 3.0m },
                    { 3, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-03", 1, "Bob White", "101 Pine St", "Accessories", "8 miles", null, "123 Main St", "John Doe", 150.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 1.0m, 2.5m },
                    { 4, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-04", 1, "Lucy Green", "202 Maple St", "Furniture", "12 miles", null, "123 Main St", "John Doe", 600.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 2.5m, 4.0m },
                    { 5, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-01", 2, "Tom Brown", "30 Center St", "Fresh Produce", "5 miles", null, "25 Market St", "Alice Green", 200.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 3.0m, 6.0m },
                    { 6, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-02", 2, "Sarah White", "35 Park Ave", "Dairy Products", "10 miles", null, "25 Market St", "Alice Green", 300.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit", 4.0m, 8.0m },
                    { 7, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-03", 2, "Daniel Black", "40 Broadway", "Packaged Goods", "7 miles", null, "25 Market St", "Alice Green", 250.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 2.0m, 4.5m },
                    { 8, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-04", 2, "Emma Red", "45 Fifth St", "Beverages", "15 miles", null, "25 Market St", "Alice Green", 400.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 2.5m, 5.0m },
                    { 9, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-01", 3, "Jim Doe", "50 Snack Ave", "Fast Food Order", "3 miles", null, "45 Fast Food Rd", "Alice Johnson", 50.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 1.0m, 2.0m },
                    { 10, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-02", 3, "Kate Brown", "55 Snack Ave", "Burger Order", "2 miles", null, "45 Fast Food Rd", "Alice Johnson", 30.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit", 0.5m, 1.5m },
                    { 11, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-03", 3, "Ben White", "60 Snack Ave", "Pizza Order", "1.5 miles", null, "45 Fast Food Rd", "Alice Johnson", 40.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 1.0m, 2.5m },
                    { 12, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-04", 3, "Beth Green", "65 Snack Ave", "Dessert Order", "2 miles", null, "45 Fast Food Rd", "Alice Johnson", 20.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 1.5m, 3.0m },
                    { 13, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-01", 4, "Alice Johnson", "110 Library Lane", "Books", "1 mile", null, "100 Book St", "John Smith", 25.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 0.5m, 1.0m },
                    { 14, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-02", 4, "Bob White", "120 Library Lane", "Textbooks", "2 miles", null, "100 Book St", "John Smith", 45.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit", 0.75m, 1.5m },
                    { 15, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-03", 4, "Charlie Black", "130 Library Lane", "Novels", "3 miles", null, "100 Book St", "John Smith", 50.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 1.0m, 2.0m },
                    { 16, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-04", 4, "David Green", "140 Library Lane", "Magazines", "4 miles", null, "100 Book St", "John Smith", 30.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 1.25m, 2.5m },
                    { 17, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-01", 5, "James Black", "160 Home Lane", "Home Goods", "5 miles", null, "150 Home St", "Emily White", 200.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 2.0m, 3.5m },
                    { 18, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-02", 5, "Sarah Green", "170 Home Lane", "Furniture", "10 miles", null, "150 Home St", "Emily White", 800.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit", 2.5m, 4.0m },
                    { 19, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-03", 5, "Paul Red", "180 Home Lane", "Kitchenware", "3 miles", null, "150 Home St", "Emily White", 150.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 1.0m, 2.0m },
                    { 20, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-04", 5, "Jessica Blue", "190 Home Lane", "Decorations", "2 miles", null, "150 Home St", "Emily White", 100.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 0.5m, 1.5m },
                    { 21, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-01", 6, "Anna Green", "210 Gym Lane", "Gym Equipment", "6 miles", null, "200 Fitness St", "Mike Brown", 500.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 3.0m, 5.0m },
                    { 22, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-02", 6, "Laura Black", "220 Gym Lane", "Fitness Apparel", "3 miles", null, "200 Fitness St", "Mike Brown", 150.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit", 1.5m, 2.5m },
                    { 23, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-03", 6, "Cathy White", "230 Gym Lane", "Health Supplements", "5 miles", null, "200 Fitness St", "Mike Brown", 300.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 2.0m, 3.0m },
                    { 24, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-04", 6, "Sarah Blue", "240 Gym Lane", "Yoga Mats", "4 miles", null, "200 Fitness St", "Mike Brown", 100.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 2.5m, 4.0m },
                    { 25, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-01", null, "Bob", "456 Elm St", "Electronics", "10 miles", 1, "123 Main St", "Alice", 300.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 2.0m, 5.5m },
                    { 26, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-02", null, "Tom", "789 Oak St", "Computers", "15 miles", 1, "123 Main St", "Alice", 500.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit", 1.5m, 3.0m },
                    { 27, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-03", null, "Sarah", "101 Pine St", "Accessories", "8 miles", 1, "123 Main St", "Alice", 150.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 1.0m, 2.5m },
                    { 28, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-04", null, "Emma", "202 Maple St", "Furniture", "12 miles", 1, "123 Main St", "Alice", 600.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 2.5m, 4.0m },
                    { 29, new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-05", null, "Luke", "303 Cedar St", "Books", "3 miles", 1, "123 Main St", "Alice", 50.00m, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 0.5m, 1.0m },
                    { 30, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-01", null, "Alice", "30 Center St", "Fresh Produce", "5 miles", 2, "25 Market St", "Bob", 200.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 3.0m, 6.0m },
                    { 31, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-02", null, "Sara", "35 Park Ave", "Dairy Products", "10 miles", 2, "25 Market St", "Bob", 300.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit", 4.0m, 8.0m },
                    { 32, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-03", null, "Daniel", "40 Broadway", "Packaged Goods", "7 miles", 2, "25 Market St", "Bob", 250.00m, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 2.0m, 4.5m },
                    { 33, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-04", null, "Emma", "45 Fifth St", "Beverages", "15 miles", 2, "25 Market St", "Bob", 400.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 2.5m, 5.0m },
                    { 34, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-05", null, "Chris", "50 Main St", "Snacks", "2 miles", 2, "25 Market St", "Bob", 100.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 1.5m, 3.0m },
                    { 35, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-06", null, "Diana", "450 Lake St", "Clothing", "12 miles", 3, "400 River Rd", "Charlie", 350.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 3.5m, 7.0m },
                    { 36, new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-07", null, "Evan", "460 Ocean St", "Footwear", "14 miles", 3, "400 River Rd", "Charlie", 200.00m, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit", 2.0m, 6.5m },
                    { 37, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-08", null, "Fiona", "470 Sea St", "Accessories", "10 miles", 3, "400 River Rd", "Charlie", 150.00m, new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 1.5m, 5.0m },
                    { 38, new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-09", null, "Gina", "480 Shore St", "Home Goods", "8 miles", 3, "400 River Rd", "Charlie", 300.00m, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 2.5m, 4.0m },
                    { 39, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-10", null, "Hank", "490 Hill St", "Stationery", "5 miles", 3, "400 River Rd", "Charlie", 80.00m, new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 1.0m, 3.5m },
                    { 40, new DateTime(2023, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-11", null, "Ethan", "60 Blue St", "Gadgets", "3 miles", 4, "50 Green St", "Diana", 120.00m, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 1.2m, 2.5m },
                    { 41, new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-12", null, "Frank", "70 Yellow St", "Electronics", "4 miles", 4, "50 Green St", "Diana", 250.00m, new DateTime(2023, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit", 1.5m, 3.0m },
                    { 42, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-13", null, "Grace", "80 Pink St", "Home Appliances", "6 miles", 4, "50 Green St", "Diana", 400.00m, new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 2.0m, 5.0m },
                    { 43, new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-14", null, "Henry", "90 Gray St", "Books", "2 miles", 4, "50 Green St", "Diana", 50.00m, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 0.5m, 1.5m },
                    { 44, new DateTime(2023, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-15", null, "Ivy", "100 Black St", "Clothing", "7 miles", 4, "50 Green St", "Diana", 320.00m, new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 3.0m, 4.0m },
                    { 45, new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-16", null, "Jack", "85 Orange St", "Furniture", "10 miles", 5, "75 Red St", "Ethan", 600.00m, new DateTime(2023, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 3.0m, 6.0m },
                    { 46, new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-17", null, "Liam", "95 Violet St", "Kitchenware", "5 miles", 5, "75 Red St", "Ethan", 150.00m, new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit", 1.0m, 2.5m },
                    { 47, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-18", null, "Mia", "105 Indigo St", "Decor", "6 miles", 5, "75 Red St", "Ethan", 300.00m, new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 2.0m, 3.5m },
                    { 48, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-18", null, "Nora", "115 Brown St", "Toy", "6 miles", 5, "75 Red St", "Ethan", 300.00m, new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 2.0m, 1.0m },
                    { 49, new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-20", null, "Olivia", "125 Gray St", "Toys", "3 miles", 5, "75 Red St", "Ethan", 180.00m, new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 2.5m, 4.0m },
                    { 50, new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-21", null, "Peter", "160 White St", "Groceries", "4 miles", 6, "150 Black St", "Frank", 100.00m, new DateTime(2023, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 1.0m, 2.0m },
                    { 51, new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-22", null, "Kyle", "170 Yellow St", "Clothes", "5 miles", 6, "150 Black St", "Frank", 200.00m, new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit", 1.5m, 3.0m },
                    { 52, new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-23", null, "Laura", "180 Green St", "Electronics", "7 miles", 6, "150 Black St", "Frank", 300.00m, new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 2.0m, 4.0m },
                    { 53, new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023-09-24", null, "Nancy", "190 Blue St", "Books", "2 miles", 6, "150 Black St", "Frank", 50.00m, new DateTime(2023, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 0.5m, 1.5m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Color", "DriverId", "License_Plate", "Make_Year", "Max_Volume", "Max_Weight", "Model" },
                values: new object[,]
                {
                    { 1, "Toyota", "Blue", 1, "ABC1234", new DateOnly(2020, 1, 1), 3.50m, 1500.00m, "Camry" },
                    { 2, "Honda", "Red", 2, "XYZ5678", new DateOnly(2019, 1, 1), 3.20m, 1400.00m, "Civic" },
                    { 3, "Ford", "Black", 3, "LMN9101", new DateOnly(2021, 1, 1), 5.00m, 2000.00m, "F-150" },
                    { 4, "Chevrolet", "White", 4, "QRS2345", new DateOnly(2022, 1, 1), 5.50m, 2200.00m, "Silverado" },
                    { 5, "Nissan", "Silver", 5, "TUV6789", new DateOnly(2021, 1, 1), 3.80m, 1600.00m, "Altima" },
                    { 6, "Hyundai", "Green", 6, "JKL3456", new DateOnly(2023, 1, 1), 3.00m, 1400.00m, "Elantra" }
                });

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
                table: "OrderItems",
                columns: new[] { "Id", "Item_Name", "Order_PlacementId", "Quantity", "Special_Instructions", "Weight_Per_Item" },
                values: new object[,]
                {
                    { 1, "Laptop", 1, 1, "Handle with care", 2.50m },
                    { 2, "Mouse", 2, 2, "Wireless", 0.10m },
                    { 3, "Keyboard", 3, 1, "Mechanical", 0.75m },
                    { 4, "Desk", 4, 1, "Assembly required", 15.00m },
                    { 5, "Chair", 5, 1, "Comfortable", 5.00m },
                    { 6, "Phone", 6, 1, "New model", 0.20m },
                    { 7, "Charger", 7, 1, "Fast charging", 0.15m },
                    { 8, "Couch", 8, 1, "Delivery on ground floor only", 30.00m },
                    { 9, "Coffee Table", 9, 1, "Glass top", 10.00m },
                    { 10, "T-Shirt", 10, 5, "Various colors", 0.25m },
                    { 11, "Jeans", 11, 2, "Brand: XYZ", 0.75m },
                    { 12, "Fruits Basket", 12, 1, "Seasonal fruits", 3.00m },
                    { 13, "Vegetable Basket", 13, 1, "Organic", 3.00m },
                    { 14, "Cookbook", 14, 1, "Best seller", 1.00m },
                    { 15, "Spices Set", 15, 1, "Variety pack", 0.50m },
                    { 16, "Headphones", 16, 1, "Noise cancelling", 0.30m },
                    { 17, "Bluetooth Speaker", 17, 1, "Waterproof", 0.80m },
                    { 18, "Backpack", 18, 1, "For travel", 0.50m },
                    { 19, "Water Bottle", 19, 1, "Insulated", 0.20m },
                    { 20, "Camera", 20, 1, "Includes accessories", 1.50m },
                    { 21, "Tripod", 21, 1, "Adjustable height", 1.00m },
                    { 22, "Blanket", 22, 1, "Soft and warm", 1.00m },
                    { 23, "Pillow", 23, 2, "Memory foam", 0.50m },
                    { 24, "Rug", 24, 1, "Non-slip", 5.00m },
                    { 25, "Curtains", 25, 2, "Blackout style", 1.00m },
                    { 26, "Bedding Set", 26, 1, "King size", 2.00m },
                    { 27, "Towels", 27, 4, "Soft and absorbent", 0.25m },
                    { 28, "Pet Food", 28, 1, "For dogs", 10.00m },
                    { 29, "Pet Toys", 29, 3, "Variety pack", 0.50m },
                    { 30, "Garden Tools", 30, 5, "Assorted tools", 1.50m },
                    { 31, "Plant Seeds", 31, 10, "Mixed vegetables", 0.05m },
                    { 32, "Laptop Stand", 32, 1, "Adjustable height", 1.00m },
                    { 33, "Mouse Pad", 33, 1, "Large size", 0.20m },
                    { 34, "USB Hub", 34, 1, "4 ports", 0.30m },
                    { 35, "Monitor", 35, 1, "27 inch", 5.00m },
                    { 36, "HDMI Cable", 36, 1, "3 meters", 0.10m },
                    { 37, "Wireless Router", 37, 1, "Dual band", 0.50m },
                    { 38, "Wi-Fi Extender", 38, 1, "For large homes", 0.30m },
                    { 39, "Surge Protector", 39, 1, "8 outlets", 0.40m },
                    { 40, "Smartwatch", 40, 1, "Fitness tracking", 0.20m },
                    { 41, "Fitness Tracker", 41, 1, "Water resistant", 0.15m },
                    { 42, "Yoga Mat", 42, 1, "Non-slip", 1.00m },
                    { 43, "Dumbbells", 43, 2, "Adjustable weight", 2.00m },
                    { 44, "Kettlebell", 44, 1, "For strength training", 5.00m },
                    { 45, "Resistance Bands", 45, 1, "Set of 5", 0.50m },
                    { 46, "Jump Rope", 46, 1, "Adjustable length", 0.25m },
                    { 47, "Protein Powder", 47, 1, "Chocolate flavor", 1.00m },
                    { 48, "Meal Prep Containers", 48, 1, "Set of 5", 1.00m },
                    { 49, "Blender", 49, 1, "High speed", 3.00m },
                    { 50, "Juicer", 50, 1, "For fruits and veggies", 2.50m },
                    { 51, "Coffee Maker", 51, 1, "Auto shut off", 3.00m },
                    { 52, "Tea Kettle", 52, 1, "Stainless steel", 1.00m },
                    { 53, "Cookware Set", 53, 1, "Non-stick", 5.00m }
                });

            migrationBuilder.InsertData(
                table: "OrderTrackings",
                columns: new[] { "Id", "Latitude", "Longitude", "Notes", "Order_PlacementId", "Status", "TimeStamps" },
                values: new object[,]
                {
                    { 1, "34.0522", "-118.2437", "Picked up from warehouse", 1, "In Transit", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "34.0522", "-118.2437", "Delivered to customer", 2, "Delivered", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "34.0522", "-118.2437", "On the way", 3, "In Transit", new DateTime(2023, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "34.0522", "-118.2437", "Received by customer", 4, "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "34.0522", "-118.2437", "Awaiting pickup", 5, "Pending", new DateTime(2023, 9, 15, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "34.0522", "-118.2437", "Picked up", 6, "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "34.0522", "-118.2437", "On the way to destination", 7, "In Transit", new DateTime(2023, 9, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "34.0522", "-118.2437", "Delivered successfully", 8, "Delivered", new DateTime(2023, 9, 15, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "34.0522", "-118.2437", "Waiting for dispatch", 9, "In Warehouse", new DateTime(2023, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "34.0522", "-118.2437", "On route to delivery", 10, "In Transit", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "34.0522", "-118.2437", "Awaiting confirmation", 11, "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "34.0522", "-118.2437", "Picked up", 12, "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "34.0522", "-118.2437", "On the way", 13, "In Transit", new DateTime(2023, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "34.0522", "-118.2437", "Delivered to customer", 14, "Delivered", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "34.0522", "-118.2437", "On the way", 15, "In Transit", new DateTime(2023, 9, 15, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "34.0522", "-118.2437", "Received by customer", 16, "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "34.0522", "-118.2437", "Awaiting pickup", 17, "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "34.0522", "-118.2437", "Picked up", 18, "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "34.0522", "-118.2437", "On the way to destination", 19, "In Transit", new DateTime(2023, 9, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "34.0522", "-118.2437", "Delivered successfully", 20, "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "34.0522", "-118.2437", "Waiting for dispatch", 21, "In Warehouse", new DateTime(2023, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "34.0522", "-118.2437", "On route to delivery", 22, "In Transit", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "34.0522", "-118.2437", "Awaiting confirmation", 23, "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "34.0522", "-118.2437", "Picked up", 24, "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "34.0522", "-118.2437", "On the way", 25, "In Transit", new DateTime(2023, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, "34.0522", "-118.2437", "Delivered to customer", 26, "Delivered", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, "34.0522", "-118.2437", "On the way", 27, "In Transit", new DateTime(2023, 9, 15, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 28, "34.0522", "-118.2437", "Received by customer", 28, "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, "34.0522", "-118.2437", "Awaiting pickup", 29, "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, "34.0522", "-118.2437", "Picked up", 30, "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 31, "34.0522", "-118.2437", "On the way", 31, "In Transit", new DateTime(2023, 9, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, "34.0522", "-118.2437", "Delivered successfully", 32, "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, "34.0522", "-118.2437", "Waiting for dispatch", 33, "In Warehouse", new DateTime(2023, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, "34.0522", "-118.2437", "On route to delivery", 34, "In Transit", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, "34.0522", "-118.2437", "Awaiting confirmation", 35, "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, "34.0522", "-118.2437", "Picked up", 36, "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 37, "34.0522", "-118.2437", "On the way to destination", 37, "In Transit", new DateTime(2023, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, "34.0522", "-118.2437", "Delivered successfully", 38, "Delivered", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, "34.0522", "-118.2437", "Waiting for dispatch", 39, "In Warehouse", new DateTime(2023, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, "34.0522", "-118.2437", "On route to delivery", 40, "In Transit", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, "34.0522", "-118.2437", "Awaiting confirmation", 41, "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, "34.0522", "-118.2437", "Picked up", 42, "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 43, "34.0522", "-118.2437", "On the way", 43, "In Transit", new DateTime(2023, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, "34.0522", "-118.2437", "Received by customer", 44, "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, "34.0522", "-118.2437", "Awaiting pickup", 45, "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, "34.0522", "-118.2437", "Picked up", 46, "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 47, "34.0522", "-118.2437", "On the way", 47, "In Transit", new DateTime(2023, 9, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, "34.0522", "-118.2437", "Delivered successfully", 48, "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, "34.0522", "-118.2437", "Waiting for dispatch", 49, "In Warehouse", new DateTime(2023, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, "34.0522", "-118.2437", "On route to delivery", 50, "In Transit", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, "34.0522", "-118.2437", "Awaiting confirmation", 51, "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, "34.0522", "-118.2437", "Picked up", 52, "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 53, "34.0522", "-118.2437", "On the way to destination", 53, "In Transit", new DateTime(2023, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "Driver_Earnings", "Order_PlacementId", "Payment_Method", "Platform_Fee", "Processed_At", "Status", "Transaction_Identification" },
                values: new object[,]
                {
                    { 1, 300.00m, 290.00m, 1, "Credit Card", 10.00m, "2023-09-15 10:00:00", "Completed", "TXN001" },
                    { 2, 500.00m, 485.00m, 2, "PayPal", 15.00m, "2023-09-15 12:00:00", "Completed", "TXN002" },
                    { 3, 150.00m, 145.00m, 3, "Debit Card", 5.00m, null, "Pending", "TXN003" },
                    { 4, 600.00m, 580.00m, 4, "Credit Card", 20.00m, "2023-09-15 14:00:00", "Completed", "TXN004" },
                    { 5, 200.00m, 192.00m, 5, "Bank Transfer", 8.00m, "2023-09-15 15:00:00", "Completed", "TXN005" },
                    { 6, 80.00m, 80.00m, 6, "Cash", 0.00m, "2023-09-15 16:00:00", "Completed", "TXN006" },
                    { 7, 300.00m, 290.00m, 7, "Credit Card", 10.00m, "2023-09-15 17:00:00", "Completed", "TXN007" },
                    { 8, 450.00m, 435.00m, 8, "PayPal", 15.00m, "2023-09-15 18:00:00", "Completed", "TXN008" },
                    { 9, 150.00m, 145.00m, 9, "Debit Card", 5.00m, null, "Pending", "TXN009" },
                    { 10, 700.00m, 675.00m, 10, "Credit Card", 25.00m, "2023-09-15 19:00:00", "Completed", "TXN010" },
                    { 11, 250.00m, 240.00m, 11, "Bank Transfer", 10.00m, "2023-09-15 20:00:00", "Completed", "TXN011" },
                    { 12, 90.00m, 90.00m, 12, "Cash", 0.00m, "2023-09-15 21:00:00", "Completed", "TXN012" },
                    { 13, 350.00m, 338.00m, 13, "Credit Card", 12.00m, "2023-09-15 22:00:00", "Completed", "TXN013" },
                    { 14, 500.00m, 485.00m, 14, "PayPal", 15.00m, "2023-09-15 23:00:00", "Completed", "TXN014" },
                    { 15, 180.00m, 174.00m, 15, "Debit Card", 6.00m, null, "Pending", "TXN015" },
                    { 16, 650.00m, 628.00m, 16, "Credit Card", 22.00m, "2023-09-16 10:00:00", "Completed", "TXN016" },
                    { 17, 220.00m, 212.00m, 17, "Bank Transfer", 8.00m, "2023-09-16 11:00:00", "Completed", "TXN017" },
                    { 18, 75.00m, 75.00m, 18, "Cash", 0.00m, "2023-09-16 12:00:00", "Completed", "TXN018" },
                    { 19, 400.00m, 386.00m, 19, "Credit Card", 14.00m, "2023-09-16 13:00:00", "Completed", "TXN019" },
                    { 20, 600.00m, 580.00m, 20, "PayPal", 20.00m, "2023-09-16 14:00:00", "Completed", "TXN020" },
                    { 21, 150.00m, 145.00m, 21, "Debit Card", 5.00m, null, "Pending", "TXN021" },
                    { 22, 300.00m, 290.00m, 22, "Credit Card", 10.00m, "2023-09-16 15:00:00", "Completed", "TXN022" },
                    { 23, 200.00m, 192.00m, 23, "Bank Transfer", 8.00m, "2023-09-16 16:00:00", "Completed", "TXN023" },
                    { 24, 80.00m, 80.00m, 24, "Cash", 0.00m, "2023-09-16 17:00:00", "Completed", "TXN024" },
                    { 25, 300.00m, 290.00m, 25, "Credit Card", 10.00m, "2023-09-16 18:00:00", "Completed", "TXN025" },
                    { 26, 450.00m, 435.00m, 26, "PayPal", 15.00m, "2023-09-16 19:00:00", "Completed", "TXN026" },
                    { 27, 150.00m, 145.00m, 27, "Debit Card", 5.00m, null, "Pending", "TXN027" },
                    { 28, 700.00m, 675.00m, 28, "Credit Card", 25.00m, "2023-09-16 20:00:00", "Completed", "TXN028" },
                    { 29, 250.00m, 240.00m, 29, "Bank Transfer", 10.00m, "2023-09-16 21:00:00", "Completed", "TXN029" },
                    { 30, 90.00m, 90.00m, 30, "Cash", 0.00m, "2023-09-16 22:00:00", "Completed", "TXN030" },
                    { 31, 350.00m, 338.00m, 31, "Credit Card", 12.00m, "2023-09-16 23:00:00", "Completed", "TXN031" },
                    { 32, 500.00m, 485.00m, 32, "PayPal", 15.00m, "2023-09-17 10:00:00", "Completed", "TXN032" },
                    { 33, 180.00m, 174.00m, 33, "Debit Card", 6.00m, null, "Pending", "TXN033" },
                    { 34, 650.00m, 628.00m, 34, "Credit Card", 22.00m, "2023-09-17 11:00:00", "Completed", "TXN034" },
                    { 35, 220.00m, 212.00m, 35, "Bank Transfer", 8.00m, "2023-09-17 12:00:00", "Completed", "TXN035" },
                    { 36, 75.00m, 75.00m, 36, "Cash", 0.00m, "2023-09-17 13:00:00", "Completed", "TXN036" },
                    { 37, 400.00m, 386.00m, 37, "Credit Card", 14.00m, "2023-09-17 14:00:00", "Completed", "TXN037" },
                    { 38, 600.00m, 580.00m, 38, "PayPal", 20.00m, "2023-09-17 15:00:00", "Completed", "TXN038" },
                    { 39, 150.00m, 145.00m, 39, "Debit Card", 5.00m, null, "Pending", "TXN039" },
                    { 40, 300.00m, 290.00m, 40, "Credit Card", 10.00m, "2023-09-17 16:00:00", "Completed", "TXN040" },
                    { 41, 200.00m, 192.00m, 41, "Bank Transfer", 8.00m, "2023-09-17 17:00:00", "Completed", "TXN041" },
                    { 42, 80.00m, 80.00m, 42, "Cash", 0.00m, "2023-09-17 18:00:00", "Completed", "TXN042" },
                    { 43, 300.00m, 290.00m, 43, "Credit Card", 10.00m, "2023-09-17 19:00:00", "Completed", "TXN043" },
                    { 44, 450.00m, 435.00m, 44, "PayPal", 15.00m, "2023-09-17 20:00:00", "Completed", "TXN044" },
                    { 45, 150.00m, 145.00m, 45, "Debit Card", 5.00m, null, "Pending", "TXN045" },
                    { 46, 700.00m, 675.00m, 46, "Credit Card", 25.00m, "2023-09-15 10:00:00", "Completed", "TXN046" },
                    { 47, 250.00m, 240.00m, 47, "Bank Transfer", 10.00m, "2023-09-15 11:00:00", "Completed", "TXN047" },
                    { 48, 90.00m, 90.00m, 48, "Cash", 0.00m, "2023-09-15 12:00:00", "Completed", "TXN048" },
                    { 49, 350.00m, 90.00m, 49, "Credit Card", 12.00m, "2023-09-15 13:00:00", "Completed", "TXN049" }
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
                name: "IX_Earnings_Order_PlacementId",
                table: "Earnings",
                column: "Order_PlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_Order_PlacementId",
                table: "OrderItems",
                column: "Order_PlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPlacements_CustomerId",
                table: "OrderPlacements",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPlacements_DriverId",
                table: "OrderPlacements",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTrackings_Order_PlacementId",
                table: "OrderTrackings",
                column: "Order_PlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Order_PlacementId",
                table: "Payments",
                column: "Order_PlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DriverId",
                table: "Routes",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_Order_PlacementId",
                table: "Routes",
                column: "Order_PlacementId");

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
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrderTrackings");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Vehicles");

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
