using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinarSite.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cenzors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileNameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cenzors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cenzors_FileNames_FileNameId",
                        column: x => x.FileNameId,
                        principalTable: "FileNames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SearchAndResourchePeoples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileNameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchAndResourchePeoples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchAndResourchePeoples_FileNames_FileNameId",
                        column: x => x.FileNameId,
                        principalTable: "FileNames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cenzors_FileNameId",
                table: "Cenzors",
                column: "FileNameId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchAndResourchePeoples_FileNameId",
                table: "SearchAndResourchePeoples",
                column: "FileNameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cenzors");

            migrationBuilder.DropTable(
                name: "SearchAndResourchePeoples");
        }
    }
}
