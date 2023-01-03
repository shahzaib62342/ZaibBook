using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaibBook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddWriterInProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WriterId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_WriterId",
                table: "Products",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Writer_WriterId",
                table: "Products",
                column: "WriterId",
                principalTable: "Writer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Writer_WriterId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_WriterId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Products");
        }
    }
}
