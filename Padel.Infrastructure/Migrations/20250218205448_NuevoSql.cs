using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Padel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NuevoSql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Migrations/20250218205448_NuevoSql.sql"); 
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
