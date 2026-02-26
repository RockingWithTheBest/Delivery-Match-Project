using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Hey1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_OrderPlacements_OrderPlacementId",
                table: "Notifications");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_OrderPlacements_OrderPlacementId",
                table: "Notifications",
                column: "OrderPlacementId",
                principalTable: "OrderPlacements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_OrderPlacements_OrderPlacementId",
                table: "Notifications");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_OrderPlacements_OrderPlacementId",
                table: "Notifications",
                column: "OrderPlacementId",
                principalTable: "OrderPlacements",
                principalColumn: "Id");
        }
    }
}
