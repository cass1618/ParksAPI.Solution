using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksAPI.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Description", "ParkName", "Size" },
                values: new object[,]
                {
                    { 1, "Music, river, events", "Drake Park", "Medium" },
                    { 2, "Gazebos, playground", "Esther Short", "Medium" },
                    { 3, "Music, Dancing, Trees", "Mount Tabor", "Large" },
                    { 4, "Beach, pavillions, grills", "Cottonwood", "Small" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4);
        }
    }
}
