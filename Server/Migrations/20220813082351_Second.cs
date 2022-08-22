using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Server.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vozila",
                columns: new[] { "VoznaLinijaId", "Km", "Naziv", "Tip" },
                values: new object[] { "1", "1234500", "autobus1", "autobus" });

            migrationBuilder.InsertData(
                table: "Vozila",
                columns: new[] { "VoznaLinijaId", "Km", "Naziv", "Tip" },
                values: new object[] { "2", "3459800", "tramvaj1", "tramvaj" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vozila",
                keyColumn: "VoznaLinijaId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Vozila",
                keyColumn: "VoznaLinijaId",
                keyValue: "2");
        }
    }
}
