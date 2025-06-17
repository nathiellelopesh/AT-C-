using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AT_FallsTurism.Migrations
{
    /// <inheritdoc />
    public partial class FixManyToManySeedKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinos_PacotesTuristicos_PacoteTuristicoId",
                table: "Destinos");

            migrationBuilder.DropIndex(
                name: "IX_Destinos_PacoteTuristicoId",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "PacoteTuristicoId",
                table: "Destinos");

            migrationBuilder.CreateTable(
                name: "DestinoPacoteTuristico",
                columns: table => new
                {
                    DestinosId = table.Column<int>(type: "int", nullable: false),
                    PacotesTuristicosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinoPacoteTuristico", x => new { x.DestinosId, x.PacotesTuristicosId });
                    table.ForeignKey(
                        name: "FK_DestinoPacoteTuristico_Destinos_DestinosId",
                        column: x => x.DestinosId,
                        principalTable: "Destinos",
                        principalColumn: "id_destino",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinoPacoteTuristico_PacotesTuristicos_PacotesTuristicosId",
                        column: x => x.PacotesTuristicosId,
                        principalTable: "PacotesTuristicos",
                        principalColumn: "id_pacote_turistico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DestinoPacoteTuristico",
                columns: new[] { "DestinosId", "PacotesTuristicosId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinoPacoteTuristico_PacotesTuristicosId",
                table: "DestinoPacoteTuristico",
                column: "PacotesTuristicosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinoPacoteTuristico");

            migrationBuilder.AddColumn<int>(
                name: "PacoteTuristicoId",
                table: "Destinos",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "id_destino",
                keyValue: 1,
                column: "PacoteTuristicoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "id_destino",
                keyValue: 2,
                column: "PacoteTuristicoId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Destinos_PacoteTuristicoId",
                table: "Destinos",
                column: "PacoteTuristicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinos_PacotesTuristicos_PacoteTuristicoId",
                table: "Destinos",
                column: "PacoteTuristicoId",
                principalTable: "PacotesTuristicos",
                principalColumn: "id_pacote_turistico");
        }
    }
}
