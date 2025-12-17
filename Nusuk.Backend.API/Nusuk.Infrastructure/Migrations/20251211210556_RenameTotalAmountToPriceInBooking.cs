using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nusuk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameTotalAmountToPriceInBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Bookings",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Bookings",
                newName: "TotalAmount");
        }
    }
}
