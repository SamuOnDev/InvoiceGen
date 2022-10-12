using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceGenAPI.Migrations
{
    public partial class Fixsometypesandnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesContent_Invoices_IContentInvoiceNumberInvoiceId",
                table: "InvoicesContent");

            migrationBuilder.DropIndex(
                name: "IX_InvoicesContent_IContentInvoiceNumberInvoiceId",
                table: "InvoicesContent");

            migrationBuilder.DropColumn(
                name: "IContentInvoiceNumberInvoiceId",
                table: "InvoicesContent");

            migrationBuilder.AlterColumn<int>(
                name: "IContentArticleNumber",
                table: "InvoicesContent",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "InvoicesContent",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "InvoicesContent");

            migrationBuilder.AlterColumn<string>(
                name: "IContentArticleNumber",
                table: "InvoicesContent",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IContentInvoiceNumberInvoiceId",
                table: "InvoicesContent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesContent_IContentInvoiceNumberInvoiceId",
                table: "InvoicesContent",
                column: "IContentInvoiceNumberInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesContent_Invoices_IContentInvoiceNumberInvoiceId",
                table: "InvoicesContent",
                column: "IContentInvoiceNumberInvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId");
        }
    }
}
