using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceGenAPI.Migrations
{
    public partial class DatabaseCorrectionPriceandQuantityfromIContenttoInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IContentTotalArticle",
                table: "InvoicesContent");

            migrationBuilder.DropColumn(
                name: "IContentTotalPrice",
                table: "InvoicesContent");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceTotalArticle",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "InvoiceTotalPrice",
                table: "Invoices",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceTotalArticle",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceTotalPrice",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "IContentTotalArticle",
                table: "InvoicesContent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "IContentTotalPrice",
                table: "InvoicesContent",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
