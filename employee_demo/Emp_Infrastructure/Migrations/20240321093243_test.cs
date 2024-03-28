using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Employees",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_EmpId",
                table: "Addresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EmpId",
                table: "Addresses",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Employees",
                table: "Addresses",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
