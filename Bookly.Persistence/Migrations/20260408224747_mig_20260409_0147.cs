using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookly.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_20260409_0147 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotHashPass",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotHashPass",
                table: "AspNetUsers");
        }
    }
}
