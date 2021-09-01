using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCMaintenanceAutomation.Data.Migrations
{
    public partial class FixedMaintenanceServiceDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServiceDetails_MaintenanceServiceGenerals_MaintenanceServieGeneralId",
                table: "MaintenanceServiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceServiceDetails_MaintenanceServieGeneralId",
                table: "MaintenanceServiceDetails");

            migrationBuilder.DropColumn(
                name: "MaintenanceServieGeneralId",
                table: "MaintenanceServiceDetails");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServiceDetails_MaintenanceServiceGeneralId",
                table: "MaintenanceServiceDetails",
                column: "MaintenanceServiceGeneralId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServiceDetails_MaintenanceServiceGenerals_MaintenanceServiceGeneralId",
                table: "MaintenanceServiceDetails",
                column: "MaintenanceServiceGeneralId",
                principalTable: "MaintenanceServiceGenerals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServiceDetails_MaintenanceServiceGenerals_MaintenanceServiceGeneralId",
                table: "MaintenanceServiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceServiceDetails_MaintenanceServiceGeneralId",
                table: "MaintenanceServiceDetails");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceServieGeneralId",
                table: "MaintenanceServiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServiceDetails_MaintenanceServieGeneralId",
                table: "MaintenanceServiceDetails",
                column: "MaintenanceServieGeneralId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServiceDetails_MaintenanceServiceGenerals_MaintenanceServieGeneralId",
                table: "MaintenanceServiceDetails",
                column: "MaintenanceServieGeneralId",
                principalTable: "MaintenanceServiceGenerals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
