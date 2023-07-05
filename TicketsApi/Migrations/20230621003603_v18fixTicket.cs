using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsApi.Migrations
{
    /// <inheritdoc />
    public partial class v18fixTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "Seat",
                table: "Ticket",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seat",
                table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "Order",
                table: "Ticket",
                type: "text",
                nullable: true);
        }
    }
}
