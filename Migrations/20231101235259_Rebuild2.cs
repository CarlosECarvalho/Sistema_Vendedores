using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class Rebuild2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecords_Seller_SellerID",
                table: "SalesRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesRecords",
                table: "SalesRecords");

            migrationBuilder.RenameTable(
                name: "SalesRecords",
                newName: "SalesRecord");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecords_SellerID",
                table: "SalesRecord",
                newName: "IX_SalesRecord_SellerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesRecord",
                table: "SalesRecord",
                column: "SalesRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecord_Seller_SellerID",
                table: "SalesRecord",
                column: "SellerID",
                principalTable: "Seller",
                principalColumn: "SellerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecord_Seller_SellerID",
                table: "SalesRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesRecord",
                table: "SalesRecord");

            migrationBuilder.RenameTable(
                name: "SalesRecord",
                newName: "SalesRecords");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecord_SellerID",
                table: "SalesRecords",
                newName: "IX_SalesRecords_SellerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesRecords",
                table: "SalesRecords",
                column: "SalesRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecords_Seller_SellerID",
                table: "SalesRecords",
                column: "SellerID",
                principalTable: "Seller",
                principalColumn: "SellerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
