using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web24BM.Data.Migrations
{
    /// <inheritdoc />
    public partial class _05112023Curriculoupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Curp",
                table: "curriculums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Curp",
                table: "curriculums");
        }
    }
}
