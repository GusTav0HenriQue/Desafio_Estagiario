using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Att : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Filmes_FilmeId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Usuarios_UserId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ElencoFilme_Elencos_AtoresId",
                table: "ElencoFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_ElencoFilme_Filmes_FilmesId",
                table: "ElencoFilme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Elencos",
                table: "Elencos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Avaliacoes",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "PontuacaoTotal",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "TotalDeVotos",
                table: "Filmes");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Filmes",
                newName: "Filme");

            migrationBuilder.RenameTable(
                name: "Elencos",
                newName: "Elenco");

            migrationBuilder.RenameTable(
                name: "Avaliacoes",
                newName: "Avaliacao");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "User",
                newName: "PassWord");

            migrationBuilder.RenameColumn(
                name: "Disabled",
                table: "User",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "Cargo",
                table: "User",
                newName: "CargoDoUsuario");

            migrationBuilder.RenameColumn(
                name: "Disabled",
                table: "Filme",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "Disabled",
                table: "Elenco",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "Cargo",
                table: "Elenco",
                newName: "Papel");

            migrationBuilder.RenameColumn(
                name: "Voto",
                table: "Avaliacao",
                newName: "ValorDaAvaliacao");

            migrationBuilder.RenameColumn(
                name: "Disabled",
                table: "Avaliacao",
                newName: "Ativo");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacoes_UserId",
                table: "Avaliacao",
                newName: "IX_Avaliacao_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacoes_FilmeId",
                table: "Avaliacao",
                newName: "IX_Avaliacao_FilmeId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "User",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Filme",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Sinopse",
                table: "Filme",
                type: "varchar(190)",
                maxLength: 190,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Filme",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoTotal",
                table: "Filme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeLancamento",
                table: "Filme",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UsuariosVotantes",
                table: "Filme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Elenco",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filme",
                table: "Filme",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elenco",
                table: "Elenco",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avaliacao",
                table: "Avaliacao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Filme_FilmeId",
                table: "Avaliacao",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_User_UserId",
                table: "Avaliacao",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElencoFilme_Elenco_AtoresId",
                table: "ElencoFilme",
                column: "AtoresId",
                principalTable: "Elenco",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElencoFilme_Filme_FilmesId",
                table: "ElencoFilme",
                column: "FilmesId",
                principalTable: "Filme",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Filme_FilmeId",
                table: "Avaliacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_User_UserId",
                table: "Avaliacao");

            migrationBuilder.DropForeignKey(
                name: "FK_ElencoFilme_Elenco_AtoresId",
                table: "ElencoFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_ElencoFilme_Filme_FilmesId",
                table: "ElencoFilme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filme",
                table: "Filme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Elenco",
                table: "Elenco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Avaliacao",
                table: "Avaliacao");

            migrationBuilder.DropColumn(
                name: "AvaliacaoTotal",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "DataDeLancamento",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "UsuariosVotantes",
                table: "Filme");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Filme",
                newName: "Filmes");

            migrationBuilder.RenameTable(
                name: "Elenco",
                newName: "Elencos");

            migrationBuilder.RenameTable(
                name: "Avaliacao",
                newName: "Avaliacoes");

            migrationBuilder.RenameColumn(
                name: "PassWord",
                table: "Usuarios",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "CargoDoUsuario",
                table: "Usuarios",
                newName: "Cargo");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Usuarios",
                newName: "Disabled");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Filmes",
                newName: "Disabled");

            migrationBuilder.RenameColumn(
                name: "Papel",
                table: "Elencos",
                newName: "Cargo");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Elencos",
                newName: "Disabled");

            migrationBuilder.RenameColumn(
                name: "ValorDaAvaliacao",
                table: "Avaliacoes",
                newName: "Voto");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Avaliacoes",
                newName: "Disabled");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacao_UserId",
                table: "Avaliacoes",
                newName: "IX_Avaliacoes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacao_FilmeId",
                table: "Avaliacoes",
                newName: "IX_Avaliacoes_FilmeId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Filmes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Sinopse",
                table: "Filmes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(190)",
                oldMaxLength: 190);

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Filmes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<int>(
                name: "PontuacaoTotal",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalDeVotos",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Elencos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elencos",
                table: "Elencos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avaliacoes",
                table: "Avaliacoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Filmes_FilmeId",
                table: "Avaliacoes",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Usuarios_UserId",
                table: "Avaliacoes",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElencoFilme_Elencos_AtoresId",
                table: "ElencoFilme",
                column: "AtoresId",
                principalTable: "Elencos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElencoFilme_Filmes_FilmesId",
                table: "ElencoFilme",
                column: "FilmesId",
                principalTable: "Filmes",
                principalColumn: "Id");
        }
    }
}
