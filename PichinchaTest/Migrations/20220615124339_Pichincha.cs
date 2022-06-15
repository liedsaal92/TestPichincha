using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PichinchaTest.Migrations
{
    public partial class Pichincha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    cliente_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contrasena = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    persona_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.cliente_id);
                });

            migrationBuilder.CreateTable(
                name: "cuenta",
                columns: table => new
                {
                    cuenta_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_cuenta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    tipo_cuenta = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    saldo_inicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    cliente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuenta", x => x.cuenta_id);
                });

            migrationBuilder.CreateTable(
                name: "movimientos",
                columns: table => new
                {
                    movimiento_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipo_movimiento = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cuenta_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientos", x => x.movimiento_id);
                });

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    persona_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    genero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    identificacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.persona_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "cuenta");

            migrationBuilder.DropTable(
                name: "movimientos");

            migrationBuilder.DropTable(
                name: "persona");
        }
    }
}
