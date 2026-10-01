using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DragTrans.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailConfirm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmate",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmate",
                table: "Users");
        }
    }
}
