using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class Rebuild9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Department",
                newName: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Department",
                newName: "Id");
        }
    }
}
