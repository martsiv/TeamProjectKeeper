using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    public partial class NewUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Position_PositionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tabels_TableId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Tabels");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "WorkShifts",
                newName: "OpeningDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosingDate",
                table: "WorkShifts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Closed",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Opened",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CashRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashRegisters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashierShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashRegisterId = table.Column<int>(type: "int", nullable: false),
                    WorkShiftId = table.Column<int>(type: "int", nullable: false),
                    OpeningDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepositedCash = table.Column<int>(type: "int", nullable: true),
                    WithdrawnCash = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashierShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashierShifts_CashRegisters_CashRegisterId",
                        column: x => x.CashRegisterId,
                        principalTable: "CashRegisters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashierShifts_WorkShifts_WorkShiftId",
                        column: x => x.WorkShiftId,
                        principalTable: "WorkShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tables_Halls_HallId",
                        column: x => x.HallId,
                        principalTable: "Halls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Бар" });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Основний зал" });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Літня тераса" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "HallId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 1 },
                    { 12, 1 },
                    { 13, 1 },
                    { 14, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashierShifts_CashRegisterId",
                table: "CashierShifts",
                column: "CashRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_CashierShifts_WorkShiftId",
                table: "CashierShifts",
                column: "WorkShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_HallId",
                table: "Tables",
                column: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Position_PositionId",
                table: "Employees",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Position_PositionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CashierShifts");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "CashRegisters");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropColumn(
                name: "ClosingDate",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "Closed",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Opened",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OpeningDate",
                table: "WorkShifts",
                newName: "Date");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Tabels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tabels",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Position_PositionId",
                table: "Employees",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tabels_TableId",
                table: "Orders",
                column: "TableId",
                principalTable: "Tabels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
