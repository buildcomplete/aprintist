using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace aprintist.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Actual = table.Column<TimeSpan>(nullable: false),
                    Estimate = table.Column<TimeSpan>(nullable: false),
                    Printer = table.Column<string>(nullable: true),
                    Slicer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
