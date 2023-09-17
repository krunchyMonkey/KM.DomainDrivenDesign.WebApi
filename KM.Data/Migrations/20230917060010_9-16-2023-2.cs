using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Km.Data.Migrations
{
    /// <inheritdoc />
    public partial class _91620232 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethod_Account_AccountId",
                table: "PaymentMethod");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "PaymentMethod",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethod_Account_AccountId",
                table: "PaymentMethod",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethod_Account_AccountId",
                table: "PaymentMethod");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "PaymentMethod",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethod_Account_AccountId",
                table: "PaymentMethod",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id");
        }
    }
}
