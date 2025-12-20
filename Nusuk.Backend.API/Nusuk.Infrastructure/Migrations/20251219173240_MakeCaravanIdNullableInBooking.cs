using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nusuk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeCaravanIdNullableInBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Caravans_CaravanId",
                table: "Bookings");

            migrationBuilder.AlterColumn<Guid>(
                name: "CaravanId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Caravans_CaravanId",
                table: "Bookings",
                column: "CaravanId",
                principalTable: "Caravans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Caravans_CaravanId",
                table: "Bookings");

            migrationBuilder.AlterColumn<Guid>(
                name: "CaravanId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Caravans_CaravanId",
                table: "Bookings",
                column: "CaravanId",
                principalTable: "Caravans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
