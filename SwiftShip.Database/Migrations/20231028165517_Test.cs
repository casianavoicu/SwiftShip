using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftShip.Database.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Parcel_CustomerId",
                table: "Parcel");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_CustomerId",
                table: "Parcel",
                column: "CustomerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Parcel_CustomerId",
                table: "Parcel");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_CustomerId",
                table: "Parcel",
                column: "CustomerId");
        }
    }
}
