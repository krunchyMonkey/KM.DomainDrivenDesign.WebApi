using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Km.Data.Migrations
{
    /// <inheritdoc />
    public partial class _91620238 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethod_Account_AccountId",
                table: "PaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Account_accountId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_accountId",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethod_AccountId",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "accountId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Person",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "PaymentMethod",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Account",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AccountPaymentMethod",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPaymentMethod", x => new { x.AccountId, x.PaymentMethodsId });
                    table.ForeignKey(
                        name: "FK_AccountPaymentMethod_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountPaymentMethod_PaymentMethod_PaymentMethodsId",
                        column: x => x.PaymentMethodsId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountPerson",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeopleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPerson", x => new { x.AccountId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_AccountPerson_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountPerson_Person_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountPaymentMethod_PaymentMethodsId",
                table: "AccountPaymentMethod",
                column: "PaymentMethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPerson_PeopleId",
                table: "AccountPerson",
                column: "PeopleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPaymentMethod");

            migrationBuilder.DropTable(
                name: "AccountPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Person",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PaymentMethod",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Account",
                newName: "AccountId");

            migrationBuilder.AddColumn<Guid>(
                name: "accountId",
                table: "Person",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodId",
                table: "PaymentMethod",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_accountId",
                table: "Person",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_AccountId",
                table: "PaymentMethod",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethod_Account_AccountId",
                table: "PaymentMethod",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Account_accountId",
                table: "Person",
                column: "accountId",
                principalTable: "Account",
                principalColumn: "AccountId");
        }
    }
}
