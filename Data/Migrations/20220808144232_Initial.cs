using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elenco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Papel = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elenco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Sinopse = table.Column<string>(type: "varchar(190)", maxLength: 190, nullable: false),
                    Genero = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    AvaliacaoTotal = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UsuariosVotantes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DataDeLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar", nullable: false),
                    Email = table.Column<string>(type: "varchar", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoDoUsuario = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElencoFilme",
                columns: table => new
                {
                    AtoresId = table.Column<int>(type: "int", nullable: false),
                    FilmesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElencoFilme", x => new { x.AtoresId, x.FilmesId });
                    table.ForeignKey(
                        name: "FK_ElencoFilme_Elenco_AtoresId",
                        column: x => x.AtoresId,
                        principalTable: "Elenco",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ElencoFilme_Filme_FilmesId",
                        column: x => x.FilmesId,
                        principalTable: "Filme",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorDaAvaliacao = table.Column<int>(type: "int", nullable: false),
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Avaliacao_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_FilmeId",
                table: "Avaliacao",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_UserId",
                table: "Avaliacao",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ElencoFilme_FilmesId",
                table: "ElencoFilme",
                column: "FilmesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "ElencoFilme");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Elenco");

            migrationBuilder.DropTable(
                name: "Filme");
        }
    }
}
