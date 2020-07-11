using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewsAPI.Migrations
{
    public partial class TextRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConfirmedAt", "CreatedAt" },
                values: new object[] { new DateTime(2020, 5, 14, 18, 7, 13, 707, DateTimeKind.Local).AddTicks(4597), new DateTime(2020, 5, 14, 18, 7, 13, 704, DateTimeKind.Local).AddTicks(2758) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConfirmedAt", "CreatedAt" },
                values: new object[] { new DateTime(2020, 5, 14, 18, 7, 13, 707, DateTimeKind.Local).AddTicks(5480), new DateTime(2020, 5, 14, 18, 7, 13, 707, DateTimeKind.Local).AddTicks(5466) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConfirmedAt", "CreatedAt" },
                values: new object[] { new DateTime(2020, 5, 14, 18, 7, 13, 707, DateTimeKind.Local).AddTicks(5496), new DateTime(2020, 5, 14, 18, 7, 13, 707, DateTimeKind.Local).AddTicks(5492) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConfirmedAt", "CreatedAt" },
                values: new object[] { new DateTime(2020, 5, 14, 17, 26, 39, 708, DateTimeKind.Local).AddTicks(2704), new DateTime(2020, 5, 14, 17, 26, 39, 703, DateTimeKind.Local).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConfirmedAt", "CreatedAt" },
                values: new object[] { new DateTime(2020, 5, 14, 17, 26, 39, 708, DateTimeKind.Local).AddTicks(4011), new DateTime(2020, 5, 14, 17, 26, 39, 708, DateTimeKind.Local).AddTicks(3992) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConfirmedAt", "CreatedAt" },
                values: new object[] { new DateTime(2020, 5, 14, 17, 26, 39, 708, DateTimeKind.Local).AddTicks(4037), new DateTime(2020, 5, 14, 17, 26, 39, 708, DateTimeKind.Local).AddTicks(4032) });
        }
    }
}
