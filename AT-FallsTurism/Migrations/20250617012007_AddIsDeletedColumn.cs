using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AT_FallsTurism.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DestinoPacoteTuristico",
                keyColumns: new[] { "DestinosId", "PacotesTuristicosId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "Clientes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "id_cliente",
                keyValue: 1,
                column: "deleted_at",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "id_cliente",
                keyValue: 2,
                column: "deleted_at",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "Clientes");

            migrationBuilder.InsertData(
                table: "DestinoPacoteTuristico",
                columns: new[] { "DestinosId", "PacotesTuristicosId" },
                values: new object[] { 2, 1 });
        }
    }
}
