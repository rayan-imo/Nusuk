using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nusuk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsActive", "Level", "Name", "TotalPrice", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("aaaa1111-1111-1111-1111-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, 0, "باقة عمرة رمضان", 12500m, null, null },
                    { new Guid("aaaa2222-2222-2222-2222-222222222222"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, 0, "باقة الحج المتميز", 35000m, null, null },
                    { new Guid("aaaa3333-3333-3333-3333-333333333333"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, 0, "باقة عمرة العائلة الذهبية", 18500m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsIncluded", "Name", "Price", "ProviderName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("00010000-0000-0000-0000-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "مباشر درجة أعمال", null, "طيران", null, null, null, null },
                    { new Guid("00010000-0000-0000-0000-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "خمسة نجوم على بعد 200م", null, "فندق", null, null, null, null },
                    { new Guid("00010000-0000-0000-0000-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "فاخرة مع مرشدين", null, "مواصلات", null, null, null, null },
                    { new Guid("00010000-0000-0000-0000-000000000004"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "إفطار وسحور شامل", null, "وجبات", null, null, null, null },
                    { new Guid("00020000-0000-0000-0000-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "مباشر مع امتعة 50 كجم", null, "طيران", null, null, null, null },
                    { new Guid("00020000-0000-0000-0000-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "خمسة نجوم مكة والمدينة", null, "فندق", null, null, null, null },
                    { new Guid("00020000-0000-0000-0000-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "متخصص طوال الرحلة", null, "مرافق ديني", null, null, null, null },
                    { new Guid("00020000-0000-0000-0000-000000000004"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "مكيفة مع توصيل", null, "حافلات", null, null, null, null },
                    { new Guid("00030000-0000-0000-0000-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "تذاكر عائلية", null, "طيران", null, null, null, null },
                    { new Guid("00030000-0000-0000-0000-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "غرف متصلة 4 نجوم", null, "فندق", null, null, null, null },
                    { new Guid("00030000-0000-0000-0000-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "خاصة بالأطفال", null, "أنشطة للأطفال", null, null, null, null },
                    { new Guid("00030000-0000-0000-0000-000000000004"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "سيارة خاصة", null, "مواصلات", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "EndDate", "Name", "StartDate", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "المدة 10 أيام", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "عمرة رمضان", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "المدة 20 يوم", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "برنامج الحج المتميز", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "المدة 14 يوم", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "عمرة العائلة الذهبية", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "ServiceDetail",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Name", "PackageId", "Price", "ServiceId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("50000000-0000-0000-0000-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, new Guid("aaaa1111-1111-1111-1111-111111111111"), 0m, new Guid("00010000-0000-0000-0000-000000000001"), null, null },
                    { new Guid("50000000-0000-0000-0000-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, new Guid("aaaa1111-1111-1111-1111-111111111111"), 0m, new Guid("00010000-0000-0000-0000-000000000002"), null, null },
                    { new Guid("50000000-0000-0000-0000-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, new Guid("aaaa1111-1111-1111-1111-111111111111"), 0m, new Guid("00010000-0000-0000-0000-000000000003"), null, null },
                    { new Guid("50000000-0000-0000-0000-000000000004"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, new Guid("aaaa1111-1111-1111-1111-111111111111"), 0m, new Guid("00010000-0000-0000-0000-000000000004"), null, null },
                    { new Guid("50000000-0000-0000-0000-000000000005"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, new Guid("aaaa2222-2222-2222-2222-222222222222"), 0m, new Guid("00020000-0000-0000-0000-000000000001"), null, null },
                    { new Guid("50000000-0000-0000-0000-000000000006"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, new Guid("aaaa2222-2222-2222-2222-222222222222"), 0m, new Guid("00020000-0000-0000-0000-000000000002"), null, null },
                    { new Guid("50000000-0000-0000-0000-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, new Guid("aaaa2222-2222-2222-2222-222222222222"), 0m, new Guid("00020000-0000-0000-0000-000000000003"), null, null },
                    { new Guid("50000000-0000-0000-0000-000000000008"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, new Guid("aaaa2222-2222-2222-2222-222222222222"), 0m, new Guid("00020000-0000-0000-0000-000000000004"), null, null },
                    { new Guid("50000000-0000-0000-0000-000000000009"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, new Guid("aaaa3333-3333-3333-3333-333333333333"), 0m, new Guid("00030000-0000-0000-0000-000000000001"), null, null },
                    { new Guid("50000000-0000-0000-0000-000000000010"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, new Guid("aaaa3333-3333-3333-3333-333333333333"), 0m, new Guid("00030000-0000-0000-0000-000000000002"), null, null },
                    { new Guid("50000000-0000-0000-0000-000000000011"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, new Guid("aaaa3333-3333-3333-3333-333333333333"), 0m, new Guid("00030000-0000-0000-0000-000000000003"), null, null },
                    { new Guid("50000000-0000-0000-0000-000000000012"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, new Guid("aaaa3333-3333-3333-3333-333333333333"), 0m, new Guid("00030000-0000-0000-0000-000000000004"), null, null }
                });

            migrationBuilder.InsertData(
                table: "TripPackages",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "PackageId", "TripId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("60000000-0000-0000-0000-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("aaaa1111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("aaaa2222-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("aaaa3333-3333-3333-3333-333333333333"), new Guid("33333333-3333-3333-3333-333333333333"), null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "TripPackages",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "TripPackages",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "TripPackages",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("aaaa1111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("aaaa2222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("aaaa3333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00010000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00010000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00010000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00010000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00020000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00020000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00020000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00020000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00030000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00030000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00030000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00030000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));
        }
    }
}
