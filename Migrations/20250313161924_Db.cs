using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_EventPlus.Migrations
{
    /// <inheritdoc />
    public partial class Db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComentarioEvento",
                columns: table => new
                {
                    IdComentarioEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Exibe = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioEvento", x => x.IdComentarioEvento);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTipoEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "DATE", nullable: false),
                    NomeEvento = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.IdEvento);
                });

            migrationBuilder.CreateTable(
                name: "Instituicoes",
                columns: table => new
                {
                    IdInstituicoes = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cnpj = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicoes", x => x.IdInstituicoes);
                });

            migrationBuilder.CreateTable(
                name: "PresencasEventos",
                columns: table => new
                {
                    IdPresenca = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Situacao = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresencasEventos", x => x.IdPresenca);
                });

            migrationBuilder.CreateTable(
                name: "TiposEventos",
                columns: table => new
                {
                    IdTipoEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoEvento = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEventos", x => x.IdTipoEvento);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuarios",
                columns: table => new
                {
                    IdTiposUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoUsuario = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuarios", x => x.IdTiposUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTiposUsuarios = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomeUsuario = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposUsuarios_IdTiposUsuarios",
                        column: x => x.IdTiposUsuarios,
                        principalTable: "TiposUsuarios",
                        principalColumn: "IdTiposUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instituicoes_Cnpj",
                table: "Instituicoes",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTiposUsuarios",
                table: "Usuarios",
                column: "IdTiposUsuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioEvento");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Instituicoes");

            migrationBuilder.DropTable(
                name: "PresencasEventos");

            migrationBuilder.DropTable(
                name: "TiposEventos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TiposUsuarios");
        }
    }
}
