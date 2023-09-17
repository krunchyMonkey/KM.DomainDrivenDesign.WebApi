using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Km.Data.Migrations
{
    /// <inheritdoc />
    public partial class _91620234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Person",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Account",
                newName: "AccountId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Person",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Account",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PaymentMethod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod",
                column: "Id");
        }
    }
}
