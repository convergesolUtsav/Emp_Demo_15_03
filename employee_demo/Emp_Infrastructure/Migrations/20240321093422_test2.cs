using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Employees",
                table: "EmergencyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Employees_EmployeeId1",
                table: "EmergencyContacts");

            migrationBuilder.DropIndex(
                name: "IX_EmergencyContacts_EmployeeId1",
                table: "EmergencyContacts");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "EmergencyContacts");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Employees_EmployeeId",
                table: "EmergencyContacts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Employees_EmployeeId",
                table: "EmergencyContacts");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "EmergencyContacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_EmployeeId1",
                table: "EmergencyContacts",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Employees",
                table: "EmergencyContacts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Employees_EmployeeId1",
                table: "EmergencyContacts",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
