using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.Server.Data.Migrations
{
    public partial class AddedDefaultDataAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "MessageDesc", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 2, 2, 19, 58, 48, 94, DateTimeKind.Local).AddTicks(6691), new DateTime(2023, 2, 2, 19, 58, 48, 94, DateTimeKind.Local).AddTicks(6708), "Matter Baby", "System" },
                    { 2, "System", new DateTime(2023, 2, 2, 19, 58, 48, 94, DateTimeKind.Local).AddTicks(6716), new DateTime(2023, 2, 2, 19, 58, 48, 94, DateTimeKind.Local).AddTicks(6718), "Whats Up", "System" }
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 2, 19, 58, 48, 90, DateTimeKind.Local).AddTicks(2308), new DateTime(2023, 2, 2, 19, 58, 48, 92, DateTimeKind.Local).AddTicks(1603) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 2, 19, 58, 48, 92, DateTimeKind.Local).AddTicks(3545), new DateTime(2023, 2, 2, 19, 58, 48, 92, DateTimeKind.Local).AddTicks(3555) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 2, 19, 55, 53, 966, DateTimeKind.Local).AddTicks(5421), new DateTime(2023, 2, 2, 19, 55, 53, 968, DateTimeKind.Local).AddTicks(7817) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 2, 19, 55, 53, 969, DateTimeKind.Local).AddTicks(159), new DateTime(2023, 2, 2, 19, 55, 53, 969, DateTimeKind.Local).AddTicks(170) });
        }
    }
}
