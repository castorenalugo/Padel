using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Padel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FechaCreacionAgregado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Migrations/20250214235002_FechaCreacionAgregado.sql"); 
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
