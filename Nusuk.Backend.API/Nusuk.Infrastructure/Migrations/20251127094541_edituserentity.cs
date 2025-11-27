using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nusuk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class edituserentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caravans_Bookings_BookingId",
                table: "Caravans");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceDetail_ServiceDetailId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_UsersService_UserServiceId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersService_UserServiceId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserServiceId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserServiceId",
                table: "Service",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceDetailId",
                table: "Service",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookingId",
                table: "Caravans",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Caravans_Bookings_BookingId",
                table: "Caravans",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceDetail_ServiceDetailId",
                table: "Service",
                column: "ServiceDetailId",
                principalTable: "ServiceDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_UsersService_UserServiceId",
                table: "Service",
                column: "UserServiceId",
                principalTable: "UsersService",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersService_UserServiceId",
                table: "Users",
                column: "UserServiceId",
                principalTable: "UsersService",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caravans_Bookings_BookingId",
                table: "Caravans");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceDetail_ServiceDetailId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_UsersService_UserServiceId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersService_UserServiceId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserServiceId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserServiceId",
                table: "Service",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceDetailId",
                table: "Service",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BookingId",
                table: "Caravans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Caravans_Bookings_BookingId",
                table: "Caravans",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceDetail_ServiceDetailId",
                table: "Service",
                column: "ServiceDetailId",
                principalTable: "ServiceDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_UsersService_UserServiceId",
                table: "Service",
                column: "UserServiceId",
                principalTable: "UsersService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersService_UserServiceId",
                table: "Users",
                column: "UserServiceId",
                principalTable: "UsersService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
