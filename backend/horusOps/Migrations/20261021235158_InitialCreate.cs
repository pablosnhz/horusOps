using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace horusOps.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    ID_CLIENTE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI_CLIENTE = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    NOMBRE_CLIENTE = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    DIRECCION_ENVIO_CLIENTE = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    EMAIL_CLIENTE = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    TELEFONO_CLIENTE = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    FECHA_ALTA = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.ID_CLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "PROCESOS",
                columns: table => new
                {
                    ID_PROCESO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_PROCESO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DESCRIPCION_PROCESO = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    EXPRESION_CRON = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PROBABILIDAD_ERROR = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ACTIVO = table.Column<bool>(type: "bit", nullable: false),
                    FECHA_ALTA = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROCESOS", x => x.ID_PROCESO);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTOS",
                columns: table => new
                {
                    ID_PRODUCTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_PRODUCTO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PRECIO_PRODUCTO = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ACTIVO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTOS", x => x.ID_PRODUCTO);
                });

            migrationBuilder.CreateTable(
                name: "SUCURSALES",
                columns: table => new
                {
                    ID_SUCURSAL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_SUCURSAL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DIRECCION_SUCURSAL = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    CIUDAD = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ACTIVO = table.Column<bool>(type: "bit", nullable: false),
                    FECHA_ALTA = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUCURSALES", x => x.ID_SUCURSAL);
                });

            migrationBuilder.CreateTable(
                name: "EJECUCIONES_PROCESOS",
                columns: table => new
                {
                    ID_EJECUCION = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PROCESO = table.Column<int>(type: "int", nullable: false),
                    FECHA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    FECHA_FIN = table.Column<DateTime>(type: "datetime", nullable: true),
                    ESTADO_EJECUCION = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    REGISTROS_PROCESADOS = table.Column<int>(type: "int", nullable: false),
                    CANTIDAD_ERRORES = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EJECUCIONES_PROCESOS", x => x.ID_EJECUCION);
                    table.ForeignKey(
                        name: "FK_EJECUCIONES_PROCESOS_PROCESOS_ID_PROCESO",
                        column: x => x.ID_PROCESO,
                        principalTable: "PROCESOS",
                        principalColumn: "ID_PROCESO");
                });

            migrationBuilder.CreateTable(
                name: "EMPLEADOS",
                columns: table => new
                {
                    ID_EMPLEADO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_EMPLEADO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    APELLIDO_EMPLEADO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DNI_EMPLEADO = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    EMAIL_EMPLEADO = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    TELEFONO_EMPLEADO = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    FECHA_INGRESO = table.Column<DateTime>(type: "date", nullable: false),
                    ID_SUCURSAL = table.Column<int>(type: "int", nullable: false),
                    ACTIVO = table.Column<bool>(type: "bit", nullable: false),
                    FECHA_ALTA = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLEADOS", x => x.ID_EMPLEADO);
                    table.ForeignKey(
                        name: "FK_EMPLEADOS_SUCURSALES_ID_SUCURSAL",
                        column: x => x.ID_SUCURSAL,
                        principalTable: "SUCURSALES",
                        principalColumn: "ID_SUCURSAL");
                });

            migrationBuilder.CreateTable(
                name: "LOGS_PROCESOS",
                columns: table => new
                {
                    ID_LOG = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_EJECUCION = table.Column<long>(type: "bigint", nullable: false),
                    FECHA_LOG = table.Column<DateTime>(type: "datetime", nullable: false),
                    NIVEL_LOG = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    MENSAJE_LOG = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    DETALLE_ERROR = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGS_PROCESOS", x => x.ID_LOG);
                    table.ForeignKey(
                        name: "FK_LOGS_PROCESOS_EJECUCIONES_PROCESOS_ID_EJECUCION",
                        column: x => x.ID_EJECUCION,
                        principalTable: "EJECUCIONES_PROCESOS",
                        principalColumn: "ID_EJECUCION");
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_USUARIO = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CLAVE_HASH = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    ROL_USUARIO = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    ID_EMPLEADO = table.Column<int>(type: "int", nullable: true),
                    ACTIVO = table.Column<bool>(type: "bit", nullable: false),
                    FECHA_ALTA = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID_USUARIO);
                    table.ForeignKey(
                        name: "FK_USUARIOS_EMPLEADOS_ID_EMPLEADO",
                        column: x => x.ID_EMPLEADO,
                        principalTable: "EMPLEADOS",
                        principalColumn: "ID_EMPLEADO");
                });

            migrationBuilder.CreateTable(
                name: "VENTAS",
                columns: table => new
                {
                    ID_VENTA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FECHA_VENTA = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_CLIENTE = table.Column<int>(type: "int", nullable: false),
                    ID_EMPLEADO = table.Column<int>(type: "int", nullable: false),
                    ID_SUCURSAL = table.Column<int>(type: "int", nullable: false),
                    DNI_CLIENTE = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    NOMBRE_CLIENTE = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    DIRECCION_ENVIO_CLIENTE = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    NOMBRE_EMPLEADO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NOMBRE_SUCURSAL_VENTA = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DIRECCION_SUCURSAL_VENTA = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    IMPORTE_TOTAL = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENTAS", x => x.ID_VENTA);
                    table.ForeignKey(
                        name: "FK_VENTAS_CLIENTES_ID_CLIENTE",
                        column: x => x.ID_CLIENTE,
                        principalTable: "CLIENTES",
                        principalColumn: "ID_CLIENTE");
                    table.ForeignKey(
                        name: "FK_VENTAS_EMPLEADOS_ID_EMPLEADO",
                        column: x => x.ID_EMPLEADO,
                        principalTable: "EMPLEADOS",
                        principalColumn: "ID_EMPLEADO");
                    table.ForeignKey(
                        name: "FK_VENTAS_SUCURSALES_ID_SUCURSAL",
                        column: x => x.ID_SUCURSAL,
                        principalTable: "SUCURSALES",
                        principalColumn: "ID_SUCURSAL");
                });

            migrationBuilder.CreateTable(
                name: "DETALLE_VENTAS",
                columns: table => new
                {
                    ID_DETALLE_VENTA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_VENTA = table.Column<int>(type: "int", nullable: false),
                    ID_PRODUCTO = table.Column<int>(type: "int", nullable: false),
                    PRODUCTO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CANTIDAD = table.Column<int>(type: "int", nullable: false),
                    PRECIO_UNITARIO = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETALLE_VENTAS", x => x.ID_DETALLE_VENTA);
                    table.ForeignKey(
                        name: "FK_DETALLE_VENTAS_PRODUCTOS_ID_PRODUCTO",
                        column: x => x.ID_PRODUCTO,
                        principalTable: "PRODUCTOS",
                        principalColumn: "ID_PRODUCTO");
                    table.ForeignKey(
                        name: "FK_DETALLE_VENTAS_VENTAS_ID_VENTA",
                        column: x => x.ID_VENTA,
                        principalTable: "VENTAS",
                        principalColumn: "ID_VENTA");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_VENTAS_ID_PRODUCTO",
                table: "DETALLE_VENTAS",
                column: "ID_PRODUCTO");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_VENTAS_ID_VENTA",
                table: "DETALLE_VENTAS",
                column: "ID_VENTA");

            migrationBuilder.CreateIndex(
                name: "IX_EJECUCIONES_PROCESOS_ID_PROCESO",
                table: "EJECUCIONES_PROCESOS",
                column: "ID_PROCESO");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLEADOS_ID_SUCURSAL",
                table: "EMPLEADOS",
                column: "ID_SUCURSAL");

            migrationBuilder.CreateIndex(
                name: "IX_LOGS_PROCESOS_ID_EJECUCION",
                table: "LOGS_PROCESOS",
                column: "ID_EJECUCION");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_ID_EMPLEADO",
                table: "USUARIOS",
                column: "ID_EMPLEADO");

            migrationBuilder.CreateIndex(
                name: "IX_VENTAS_ID_CLIENTE",
                table: "VENTAS",
                column: "ID_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_VENTAS_ID_EMPLEADO",
                table: "VENTAS",
                column: "ID_EMPLEADO");

            migrationBuilder.CreateIndex(
                name: "IX_VENTAS_ID_SUCURSAL",
                table: "VENTAS",
                column: "ID_SUCURSAL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DETALLE_VENTAS");

            migrationBuilder.DropTable(
                name: "LOGS_PROCESOS");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "PRODUCTOS");

            migrationBuilder.DropTable(
                name: "VENTAS");

            migrationBuilder.DropTable(
                name: "EJECUCIONES_PROCESOS");

            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "EMPLEADOS");

            migrationBuilder.DropTable(
                name: "PROCESOS");

            migrationBuilder.DropTable(
                name: "SUCURSALES");
        }
    }
}
