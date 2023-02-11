using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinarSite.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileContente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileContente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LucratorMedicals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodCMV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiplomNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEnterCMv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Sanctions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LucratorMedicals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileNames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileNames_FileContente_FileContentId",
                        column: x => x.FileContentId,
                        principalTable: "FileContente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BirouExecutivCMVs",
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
                    table.PrimaryKey("PK_BirouExecutivCMVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BirouExecutivCMVs_FileNames_FileNameId",
                        column: x => x.FileNameId,
                        principalTable: "FileNames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComponentaComisieiDentologiceSiLitigii",
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
                    table.PrimaryKey("PK_ComponentaComisieiDentologiceSiLitigii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentaComisieiDentologiceSiLitigii_FileNames_FileNameId",
                        column: x => x.FileNameId,
                        principalTable: "FileNames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComponentaComisieiPentruStiintaCercetareFoRmare",
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
                    table.PrimaryKey("PK_ComponentaComisieiPentruStiintaCercetareFoRmare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentaComisieiPentruStiintaCercetareFoRmare_FileNames_FileNameId",
                        column: x => x.FileNameId,
                        principalTable: "FileNames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirouExecutivCMVs_FileNameId",
                table: "BirouExecutivCMVs",
                column: "FileNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentaComisieiDentologiceSiLitigii_FileNameId",
                table: "ComponentaComisieiDentologiceSiLitigii",
                column: "FileNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentaComisieiPentruStiintaCercetareFoRmare_FileNameId",
                table: "ComponentaComisieiPentruStiintaCercetareFoRmare",
                column: "FileNameId");

            migrationBuilder.CreateIndex(
                name: "IX_FileNames_FileContentId",
                table: "FileNames",
                column: "FileContentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirouExecutivCMVs");

            migrationBuilder.DropTable(
                name: "ComponentaComisieiDentologiceSiLitigii");

            migrationBuilder.DropTable(
                name: "ComponentaComisieiPentruStiintaCercetareFoRmare");

            migrationBuilder.DropTable(
                name: "LucratorMedicals");

            migrationBuilder.DropTable(
                name: "FileNames");

            migrationBuilder.DropTable(
                name: "FileContente");
        }
    }
}
