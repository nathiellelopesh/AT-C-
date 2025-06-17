using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AT_FallsTurism.Migrations
{
    /// <inheritdoc />
    public partial class PopulateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destino_PacoteTuristico_PacoteTuristicoId",
                table: "Destino");

            migrationBuilder.DropForeignKey(
                name: "FK_reservas_Cliente_ClienteId",
                table: "reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_reservas_PacoteTuristico_PacoteTuristicoId",
                table: "reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservas",
                table: "reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PacoteTuristico",
                table: "PacoteTuristico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destino",
                table: "Destino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "reservas",
                newName: "Reservas");

            migrationBuilder.RenameTable(
                name: "PacoteTuristico",
                newName: "PacotesTuristicos");

            migrationBuilder.RenameTable(
                name: "Destino",
                newName: "Destinos");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.RenameColumn(
                name: "DataReserva",
                table: "Reservas",
                newName: "data_reserva");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reservas",
                newName: "id_reserva");

            migrationBuilder.RenameIndex(
                name: "IX_reservas_PacoteTuristicoId",
                table: "Reservas",
                newName: "IX_Reservas_PacoteTuristicoId");

            migrationBuilder.RenameIndex(
                name: "IX_reservas_ClienteId",
                table: "Reservas",
                newName: "IX_Reservas_ClienteId");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "PacotesTuristicos",
                newName: "titulo_pacote_turistico");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "PacotesTuristicos",
                newName: "preco_pacote_turistico");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "PacotesTuristicos",
                newName: "data_pacote_turistico");

            migrationBuilder.RenameColumn(
                name: "CapacidadeMaxima",
                table: "PacotesTuristicos",
                newName: "capacidade_pacote_turistico");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PacotesTuristicos",
                newName: "id_pacote_turistico");

            migrationBuilder.RenameColumn(
                name: "Pais",
                table: "Destinos",
                newName: "pais_destino");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Destinos",
                newName: "nome_destino");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Destinos",
                newName: "id_destino");

            migrationBuilder.RenameIndex(
                name: "IX_Destino_PacoteTuristicoId",
                table: "Destinos",
                newName: "IX_Destinos_PacoteTuristicoId");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Clientes",
                newName: "nome_cliente");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Clientes",
                newName: "email_cliente");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clientes",
                newName: "id_cliente");

            migrationBuilder.AlterColumn<string>(
                name: "titulo_pacote_turistico",
                table: "PacotesTuristicos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "pais_destino",
                table: "Destinos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "nome_destino",
                table: "Destinos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "nome_cliente",
                table: "Clientes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email_cliente",
                table: "Clientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas",
                column: "id_reserva");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacotesTuristicos",
                table: "PacotesTuristicos",
                column: "id_pacote_turistico");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinos",
                table: "Destinos",
                column: "id_destino");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "id_cliente");

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "id_cliente", "email_cliente", "nome_cliente" },
                values: new object[,]
                {
                    { 1, "maria@email.com", "Maria Silva" },
                    { 2, "leandro@email.com", "Leandro Santos" }
                });

            migrationBuilder.InsertData(
                table: "Destinos",
                columns: new[] { "id_destino", "nome_destino", "PacoteTuristicoId", "pais_destino" },
                values: new object[,]
                {
                    { 1, "Rio de Janeiro", null, "Brasil" },
                    { 2, "Munique", null, "Alemanha" }
                });

            migrationBuilder.InsertData(
                table: "PacotesTuristicos",
                columns: new[] { "id_pacote_turistico", "capacidade_pacote_turistico", "data_pacote_turistico", "preco_pacote_turistico", "titulo_pacote_turistico" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 560m, "Aventura no Rio" },
                    { 2, 7, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1940m, "Charme de Munique" },
                    { 3, 9, new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1840m, "Inverno na Europa" },
                    { 4, 6, new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1240m, "Conheça a Patagônia" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "id_reserva", "ClienteId", "data_reserva", "PacoteTuristicoId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 5, 15, 40, 50, 794, DateTimeKind.Local).AddTicks(5854), 1 },
                    { 2, 2, new DateTime(2025, 6, 10, 15, 40, 50, 800, DateTimeKind.Local).AddTicks(5355), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_email_cliente",
                table: "Clientes",
                column: "email_cliente",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Destinos_PacotesTuristicos_PacoteTuristicoId",
                table: "Destinos",
                column: "PacoteTuristicoId",
                principalTable: "PacotesTuristicos",
                principalColumn: "id_pacote_turistico");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Clientes_ClienteId",
                table: "Reservas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "id_cliente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_PacotesTuristicos_PacoteTuristicoId",
                table: "Reservas",
                column: "PacoteTuristicoId",
                principalTable: "PacotesTuristicos",
                principalColumn: "id_pacote_turistico",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinos_PacotesTuristicos_PacoteTuristicoId",
                table: "Destinos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Clientes_ClienteId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_PacotesTuristicos_PacoteTuristicoId",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PacotesTuristicos",
                table: "PacotesTuristicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinos",
                table: "Destinos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_email_cliente",
                table: "Clientes");

            migrationBuilder.DeleteData(
                table: "Destinos",
                keyColumn: "id_destino",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Destinos",
                keyColumn: "id_destino",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PacotesTuristicos",
                keyColumn: "id_pacote_turistico",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PacotesTuristicos",
                keyColumn: "id_pacote_turistico",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "id_reserva",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "id_reserva",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "id_cliente",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "id_cliente",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PacotesTuristicos",
                keyColumn: "id_pacote_turistico",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PacotesTuristicos",
                keyColumn: "id_pacote_turistico",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Reservas",
                newName: "reservas");

            migrationBuilder.RenameTable(
                name: "PacotesTuristicos",
                newName: "PacoteTuristico");

            migrationBuilder.RenameTable(
                name: "Destinos",
                newName: "Destino");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.RenameColumn(
                name: "data_reserva",
                table: "reservas",
                newName: "DataReserva");

            migrationBuilder.RenameColumn(
                name: "id_reserva",
                table: "reservas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_PacoteTuristicoId",
                table: "reservas",
                newName: "IX_reservas_PacoteTuristicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_ClienteId",
                table: "reservas",
                newName: "IX_reservas_ClienteId");

            migrationBuilder.RenameColumn(
                name: "titulo_pacote_turistico",
                table: "PacoteTuristico",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "preco_pacote_turistico",
                table: "PacoteTuristico",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "data_pacote_turistico",
                table: "PacoteTuristico",
                newName: "DataInicio");

            migrationBuilder.RenameColumn(
                name: "capacidade_pacote_turistico",
                table: "PacoteTuristico",
                newName: "CapacidadeMaxima");

            migrationBuilder.RenameColumn(
                name: "id_pacote_turistico",
                table: "PacoteTuristico",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "pais_destino",
                table: "Destino",
                newName: "Pais");

            migrationBuilder.RenameColumn(
                name: "nome_destino",
                table: "Destino",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "id_destino",
                table: "Destino",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Destinos_PacoteTuristicoId",
                table: "Destino",
                newName: "IX_Destino_PacoteTuristicoId");

            migrationBuilder.RenameColumn(
                name: "nome_cliente",
                table: "Cliente",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email_cliente",
                table: "Cliente",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id_cliente",
                table: "Cliente",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "PacoteTuristico",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Pais",
                table: "Destino",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Destino",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservas",
                table: "reservas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacoteTuristico",
                table: "PacoteTuristico",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destino",
                table: "Destino",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Destino_PacoteTuristico_PacoteTuristicoId",
                table: "Destino",
                column: "PacoteTuristicoId",
                principalTable: "PacoteTuristico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reservas_Cliente_ClienteId",
                table: "reservas",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservas_PacoteTuristico_PacoteTuristicoId",
                table: "reservas",
                column: "PacoteTuristicoId",
                principalTable: "PacoteTuristico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
