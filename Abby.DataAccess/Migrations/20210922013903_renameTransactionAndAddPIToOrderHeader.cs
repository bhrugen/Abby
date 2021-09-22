using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abby.DataAccess.Migrations
{
    public partial class renameTransactionAndAddPIToOrderHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "OrderHeader",
                newName: "SessionId");

            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "OrderHeader");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "OrderHeader",
                newName: "TransactionId");
        }
    }
}
