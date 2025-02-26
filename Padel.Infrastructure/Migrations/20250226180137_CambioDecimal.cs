using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Padel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CambioDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Producto",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "Producto",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
