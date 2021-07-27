using Microsoft.EntityFrameworkCore.Migrations;

namespace bookapi.Migrations
{
    public partial class publishedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublishedId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "publisherId",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_publisherId",
                table: "books",
                column: "publisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_Publisher_publisherId",
                table: "books",
                column: "publisherId",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_Publisher_publisherId",
                table: "books");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_books_publisherId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "PublishedId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "publisherId",
                table: "books");
        }
    }
}
