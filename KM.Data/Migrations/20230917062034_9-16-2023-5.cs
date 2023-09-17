using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Km.Data.Migrations
{
    /// <inheritdoc />
    public partial class _91620235 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Account_AccountId",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Person",
                newName: "accountId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_AccountId",
                table: "Person",
                newName: "IX_Person_accountId");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "PaymentMethod",
                newName: "zip");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Account_accountId",
                table: "Person",
                column: "accountId",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Account_accountId",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "accountId",
                table: "Person",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_accountId",
                table: "Person",
                newName: "IX_Person_AccountId");

            migrationBuilder.RenameColumn(
                name: "zip",
                table: "PaymentMethod",
                newName: "Zip");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Account_AccountId",
                table: "Person",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
