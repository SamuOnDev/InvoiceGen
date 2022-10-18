using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceGenAPI.Migrations
{
    public partial class fix6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceTaxPrice",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceTaxPrice",
                table: "Invoices");
        }
    }
}
