using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity_Framework_Exercise.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Racks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RackId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Racks_RackId",
                        column: x => x.RackId,
                        principalTable: "Racks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Racks",
                columns: new[] { "Id", "DeletedAt", "Name" },
                values: new object[,]
                {
                    { 1, null, "Programming" },
                    { 2, null, "Self-Improvement" },
                    { 3, null, "Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "DeletedAt", "RackId", "Status", "Title" },
                values: new object[,]
                {
                    { 1, null, 1, 0, "Advanced C#" },
                    { 2, null, 1, 0, "Intermediate C#" },
                    { 3, null, 1, 0, "Beginner C#" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_RackId",
                table: "Books",
                column: "RackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Racks");
        }
    }
}
