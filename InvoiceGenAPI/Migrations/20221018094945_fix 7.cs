using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceGenAPI.Migrations
{
    public partial class fix7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "InvoiceTaxPrice",
                table: "Invoices",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<float>(
                name: "InvoicePriceWithTaxes",
                table: "Invoices",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoicePriceWithTaxes",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceTaxPrice",
                table: "Invoices",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
