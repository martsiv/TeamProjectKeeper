using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    public partial class SixthUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CashRegisters",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "PK1" });

            migrationBuilder.InsertData(
                table: "CashRegisters",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "PK2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
