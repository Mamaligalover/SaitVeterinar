using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinarSite.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

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
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                name: "IX_BirouExecutivCMVs_FileNameId",
                table: "BirouExecutivCMVs",
                column: "FileNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Cenzors_FileNameId",
                table: "Cenzors",
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

            migrationBuilder.CreateIndex(
                name: "IX_SearchAndResourchePeoples_FileNameId",
                table: "SearchAndResourchePeoples",
                column: "FileNameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirouExecutivCMVs");

            migrationBuilder.DropTable(
                name: "Cenzors");

            migrationBuilder.DropTable(
                name: "ComponentaComisieiDentologiceSiLitigii");

            migrationBuilder.DropTable(
                name: "ComponentaComisieiPentruStiintaCercetareFoRmare");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "LucratorMedicals");

            migrationBuilder.DropTable(
                name: "SearchAndResourchePeoples");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FileNames");

            migrationBuilder.DropTable(
                name: "FileContente");
        }
    }
}
