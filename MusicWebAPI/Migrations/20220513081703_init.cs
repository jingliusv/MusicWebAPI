using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicWebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Maroon 5" },
                    { 2, "Robyn" },
                    { 3, "Justin Timberlake" },
                    { 4, "Diana Krall" },
                    { 5, "Earth, Wind & Fire" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "JORDI" },
                    { 2, 1, "Red Pill Blues" },
                    { 3, 2, "Honey" },
                    { 4, 2, "Do It Again" },
                    { 5, 1, "V" },
                    { 6, 3, "The 20/20 Experience" },
                    { 7, 4, "When I Look in Your Eyes" },
                    { 8, 2, "Body Talk" },
                    { 9, 5, "Raise!" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "AlbumId", "ArtistId", "Length", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, "3:09", "Memories" },
                    { 2, 1, 1, "2:52", "Lost" },
                    { 3, 6, 3, "5:26", "Suit & Tie" },
                    { 4, 3, 2, "4:05", "Between the Lines" },
                    { 5, 1, 5, "4:48", "Boogie Wonderland" },
                    { 6, 7, 4, "5:18", "Let's Face the Music and Dance" },
                    { 7, 7, 4, "6:10", "I've Got You Under My Skin" },
                    { 8, 3, 2, "4:34", "Because It's In The Music" },
                    { 9, 8, 2, "4:48", "Dancing on My Own" },
                    { 10, 3, 2, "4:57", "Missing U" },
                    { 11, 2, 1, "3:59", "Best 4 U" },
                    { 12, 2, 1, "3:19", "What Lovers Do" },
                    { 13, 9, 5, "5:39", "Let's Groove" },
                    { 14, 9, 5, "3:35", "September" },
                    { 15, 5, 1, "3:09", "Maps" },
                    { 16, 5, 1, "3:55", "Sugar" },
                    { 17, 5, 1, "4:27", "Lost Stars" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
