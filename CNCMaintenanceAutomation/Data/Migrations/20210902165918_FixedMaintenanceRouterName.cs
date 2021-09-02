using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCMaintenanceAutomation.Data.Migrations
{
    public partial class FixedMaintenanceRouterName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServiceCards_CncMachines_MachineId",
                table: "MaintenanceServiceCards");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServiceGenerals_CncMachines_MachineId",
                table: "MaintenanceServiceGenerals");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "MaintenanceServiceGenerals",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CncMachineId",
                table: "MaintenanceServiceGenerals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "MaintenanceServiceCards",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CncMachineId",
                table: "MaintenanceServiceCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServiceCards_CncMachines_MachineId",
                table: "MaintenanceServiceCards",
                column: "MachineId",
                principalTable: "CncMachines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServiceGenerals_CncMachines_MachineId",
                table: "MaintenanceServiceGenerals",
                column: "MachineId",
                principalTable: "CncMachines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServiceCards_CncMachines_MachineId",
                table: "MaintenanceServiceCards");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServiceGenerals_CncMachines_MachineId",
                table: "MaintenanceServiceGenerals");

            migrationBuilder.DropColumn(
                name: "CncMachineId",
                table: "MaintenanceServiceGenerals");

            migrationBuilder.DropColumn(
                name: "CncMachineId",
                table: "MaintenanceServiceCards");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "MaintenanceServiceGenerals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "MaintenanceServiceCards",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServiceCards_CncMachines_MachineId",
                table: "MaintenanceServiceCards",
                column: "MachineId",
                principalTable: "CncMachines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServiceGenerals_CncMachines_MachineId",
                table: "MaintenanceServiceGenerals",
                column: "MachineId",
                principalTable: "CncMachines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
