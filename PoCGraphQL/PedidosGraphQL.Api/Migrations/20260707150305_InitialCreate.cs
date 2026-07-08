using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PedidosGraphQL.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cliente = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    FechaPedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "Cliente", "Estado", "FechaPedido", "Total" },
                values: new object[,]
                {
                    { 1, "Ana García", 2, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), 129.90m },
                    { 2, "Luis Martínez", 1, new DateTime(2026, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), 59.50m },
                    { 3, "Marta Sánchez", 0, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), 340.00m },
                    { 4, "Carlos Ruiz", 3, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), 89.99m },
                    { 5, "Elena Torres", 0, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 210.25m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
