using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class Rebuild4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecord_Seller_SellerID",
                table: "SalesRecord");

            migrationBuilder.RenameColumn(
                name: "SellerID",
                table: "SalesRecord",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecord_SellerID",
                table: "SalesRecord",
                newName: "IX_SalesRecord_SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecord_Seller_SellerId",
                table: "SalesRecord",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecord_Seller_SellerId",
                table: "SalesRecord");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "SalesRecord",
                newName: "SellerID");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecord_SellerId",
                table: "SalesRecord",
                newName: "IX_SalesRecord_SellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecord_Seller_SellerID",
                table: "SalesRecord",
                column: "SellerID",
                principalTable: "Seller",
                principalColumn: "SellerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
