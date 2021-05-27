using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi_Final.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    GeneroName = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    PaisId = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    Pais_Nom = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Cantantes",
                columns: table => new
                {
                    CantanteId = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    CantanteName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    PaisId = table.Column<string>(type: "nvarchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cantantes", x => x.CantanteId);
                    table.ForeignKey(
                        name: "FK_Cantantes_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumId = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    AlbumTit = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    AlbumFec = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    stock = table.Column<int>(type: "int", nullable: false),
                    CantanteId = table.Column<string>(type: "nvarchar(6)", nullable: true),
                    GeneroId = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    PaisId = table.Column<string>(type: "nvarchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumId);
                    table.ForeignKey(
                        name: "FK_Albums_Cantantes_CantanteId",
                        column: x => x.CantanteId,
                        principalTable: "Cantantes",
                        principalColumn: "CantanteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Albums_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Albums_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_CantanteId",
                table: "Albums",
                column: "CantanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_GeneroId",
                table: "Albums",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_PaisId",
                table: "Albums",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Cantantes_PaisId",
                table: "Cantantes",
                column: "PaisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Cantantes");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
