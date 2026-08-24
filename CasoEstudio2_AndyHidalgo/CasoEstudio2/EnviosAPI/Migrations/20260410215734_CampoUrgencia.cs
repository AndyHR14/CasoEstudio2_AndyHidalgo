using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnviosAPI.Migrations
{
    /// <inheritdoc />
    public partial class CampoUrgencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Urgencia",
                table: "Envios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Normal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Urgencia",
                table: "Envios");
        }
    }
}
