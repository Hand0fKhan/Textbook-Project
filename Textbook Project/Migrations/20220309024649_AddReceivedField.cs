using Microsoft.EntityFrameworkCore.Migrations;

namespace Textbook_Project.Migrations
{
    public partial class AddReceivedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OrderRecieved",
                table: "Checkout",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderRecieved",
                table: "Checkout");
        }
    }
}
