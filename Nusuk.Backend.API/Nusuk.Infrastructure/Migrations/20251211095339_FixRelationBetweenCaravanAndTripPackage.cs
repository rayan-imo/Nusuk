using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nusuk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationBetweenCaravanAndTripPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caravans_TripPackages_TripPackageId",
                table: "Caravans");

            migrationBuilder.AlterColumn<Guid>(
                name: "TripPackageId",
                table: "Caravans",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Caravans_TripPackages_TripPackageId",
                table: "Caravans",
                column: "TripPackageId",
                principalTable: "TripPackages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caravans_TripPackages_TripPackageId",
                table: "Caravans");

            migrationBuilder.AlterColumn<Guid>(
                name: "TripPackageId",
                table: "Caravans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Caravans_TripPackages_TripPackageId",
                table: "Caravans",
                column: "TripPackageId",
                principalTable: "TripPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
