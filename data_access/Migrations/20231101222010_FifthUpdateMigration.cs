using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    public partial class FifthUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WorkShiftsEmployees_WorkShiftEmployeeId1_WorkShiftEmployeeId2",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_WorkShiftEmployeeId1_WorkShiftEmployeeId2",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "WorkShiftEmployeeId2",
                table: "Orders",
                newName: "WorkShiftID");

            migrationBuilder.RenameColumn(
                name: "WorkShiftEmployeeId1",
                table: "Orders",
                newName: "EmployeeID");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Tables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1,
                column: "Number",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2,
                column: "Number",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3,
                column: "Number",
                value: "3");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4,
                column: "Number",
                value: "4");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5,
                column: "Number",
                value: "5");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 6,
                column: "Number",
                value: "6");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 7,
                column: "Number",
                value: "7");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 8,
                column: "Number",
                value: "8");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 9,
                column: "Number",
                value: "9");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 10,
                column: "Number",
                value: "10");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 11,
                column: "Number",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 12,
                column: "Number",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 13,
                column: "Number",
                value: "3");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 14,
                column: "Number",
                value: "4");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WorkShiftID_EmployeeID",
                table: "Orders",
                columns: new[] { "WorkShiftID", "EmployeeID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WorkShiftsEmployees_WorkShiftID_EmployeeID",
                table: "Orders",
                columns: new[] { "WorkShiftID", "EmployeeID" },
                principalTable: "WorkShiftsEmployees",
                principalColumns: new[] { "EmployeeId", "WorkShiftId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WorkShiftsEmployees_WorkShiftID_EmployeeID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_WorkShiftID_EmployeeID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Tables");

            migrationBuilder.RenameColumn(
                name: "WorkShiftID",
                table: "Orders",
                newName: "WorkShiftEmployeeId2");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Orders",
                newName: "WorkShiftEmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WorkShiftEmployeeId1_WorkShiftEmployeeId2",
                table: "Orders",
                columns: new[] { "WorkShiftEmployeeId1", "WorkShiftEmployeeId2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WorkShiftsEmployees_WorkShiftEmployeeId1_WorkShiftEmployeeId2",
                table: "Orders",
                columns: new[] { "WorkShiftEmployeeId1", "WorkShiftEmployeeId2" },
                principalTable: "WorkShiftsEmployees",
                principalColumns: new[] { "EmployeeId", "WorkShiftId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
