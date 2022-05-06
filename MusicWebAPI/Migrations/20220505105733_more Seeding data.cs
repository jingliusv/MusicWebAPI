using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicWebAPI.Migrations
{
    public partial class moreSeedingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "AlbumId", "ArtistId", "Length", "Name" },
                values: new object[,]
                {
                    { 1, 4, 1, "3:09", "Memories" },
                    { 2, 4, 1, "2:52", "Lost" },
                    { 3, 6, 3, "5:26", "Suit & Tie" },
                    { 4, 3, 2, "4:05", "Between the Lines" },
                    { 5, 1, 5, "4:48", "Boogie Wonderland" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
