using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AT_FallsTurism.Migrations
{
    /// <inheritdoc />
    public partial class FixPopulateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "id_reserva",
                keyValue: 1,
                column: "data_reserva",
                value: new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "id_reserva",
                keyValue: 2,
                column: "data_reserva",
                value: new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "id_reserva",
                keyValue: 1,
                column: "data_reserva",
                value: new DateTime(2025, 6, 5, 15, 40, 50, 794, DateTimeKind.Local).AddTicks(5854));

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "id_reserva",
                keyValue: 2,
                column: "data_reserva",
                value: new DateTime(2025, 6, 10, 15, 40, 50, 800, DateTimeKind.Local).AddTicks(5355));
        }
    }
}
