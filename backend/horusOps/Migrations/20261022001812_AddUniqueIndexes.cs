using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace horusOps.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_ID_EMPLEADO",
                table: "USUARIOS");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_ID_EMPLEADO",
                table: "USUARIOS",
                column: "ID_EMPLEADO",
                unique: true,
                filter: "[ID_EMPLEADO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_NOMBRE_USUARIO",
                table: "USUARIOS",
                column: "NOMBRE_USUARIO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLEADOS_DNI_EMPLEADO",
                table: "EMPLEADOS",
                column: "DNI_EMPLEADO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLEADOS_EMAIL_EMPLEADO",
                table: "EMPLEADOS",
                column: "EMAIL_EMPLEADO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_DNI_CLIENTE",
                table: "CLIENTES",
                column: "DNI_CLIENTE",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_ID_EMPLEADO",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_NOMBRE_USUARIO",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_EMPLEADOS_DNI_EMPLEADO",
                table: "EMPLEADOS");

            migrationBuilder.DropIndex(
                name: "IX_EMPLEADOS_EMAIL_EMPLEADO",
                table: "EMPLEADOS");

            migrationBuilder.DropIndex(
                name: "IX_CLIENTES_DNI_CLIENTE",
                table: "CLIENTES");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_ID_EMPLEADO",
                table: "USUARIOS",
                column: "ID_EMPLEADO");
        }
    }
}
