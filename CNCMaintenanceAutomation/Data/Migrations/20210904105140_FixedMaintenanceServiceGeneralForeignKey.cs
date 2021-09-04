using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCMaintenanceAutomation.Data.Migrations
{
    public partial class FixedMaintenanceServiceGeneralForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServiceGenerals_CncMachines_MachineId",
                table: "MaintenanceServiceGenerals");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceServiceGenerals_MachineId",
                table: "MaintenanceServiceGenerals");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "MaintenanceServiceGenerals");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServiceGenerals_CncMachineId",
                table: "MaintenanceServiceGenerals",
                column: "CncMachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServiceGenerals_CncMachines_CncMachineId",
                table: "MaintenanceServiceGenerals",
                column: "CncMachineId",
                principalTable: "CncMachines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServiceGenerals_CncMachines_CncMachineId",
                table: "MaintenanceServiceGenerals");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceServiceGenerals_CncMachineId",
                table: "MaintenanceServiceGenerals");

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "MaintenanceServiceGenerals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServiceGenerals_MachineId",
                table: "MaintenanceServiceGenerals",
                column: "MachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServiceGenerals_CncMachines_MachineId",
                table: "MaintenanceServiceGenerals",
                column: "MachineId",
                principalTable: "CncMachines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
