using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    public partial class swapEmployeeWorkShift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WorkShiftsEmployees_WorkShiftID_EmployeeID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_WorkShiftID_EmployeeID",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeID_WorkShiftID",
                table: "Orders",
                columns: new[] { "EmployeeID", "WorkShiftID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WorkShiftsEmployees_EmployeeID_WorkShiftID",
                table: "Orders",
                columns: new[] { "EmployeeID", "WorkShiftID" },
                principalTable: "WorkShiftsEmployees",
                principalColumns: new[] { "EmployeeId", "WorkShiftId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WorkShiftsEmployees_EmployeeID_WorkShiftID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_EmployeeID_WorkShiftID",
                table: "Orders");

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
    }
}
