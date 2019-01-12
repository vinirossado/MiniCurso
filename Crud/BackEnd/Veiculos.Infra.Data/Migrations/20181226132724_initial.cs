using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHome.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteAppId = table.Column<long>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    CodigoVerificacao = table.Column<int>(nullable: true),
                    CodigoAlteracaoSenha = table.Column<int>(nullable: true),
                    ValidadeCodigo = table.Column<DateTime>(nullable: true),
                    DataConfirmacao = table.Column<DateTime>(nullable: true),
                    Imagem = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Perfil = table.Column<string>(nullable: true),
                    FacebookId = table.Column<string>(nullable: true),
                    GoogleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteAppId = table.Column<long>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FacebookId = table.Column<string>(nullable: true),
                    GoogleId = table.Column<string>(nullable: true),
                    Imagem = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Perfil = table.Column<string>(nullable: true),
                    CodigoVerificacao = table.Column<int>(nullable: true),
                    CodigoAlteracaoSenha = table.Column<int>(nullable: true),
                    ValidadeCodigo = table.Column<DateTime>(nullable: true),
                    DataConfirmacao = table.Column<DateTime>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    TelefoneFixo = table.Column<string>(nullable: true),
                    TelefoneMovel = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empreendimentos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteAppId = table.Column<long>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    MarcadorPrimeiro = table.Column<string>(nullable: true),
                    MarcadorSegundo = table.Column<string>(nullable: true),
                    MarcadorTerceiro = table.Column<string>(nullable: true),
                    Background = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    NumeroQuartos = table.Column<string>(nullable: true),
                    AreaPrivativa = table.Column<string>(nullable: true),
                    NumeroTorres = table.Column<string>(nullable: true),
                    NumeroAndares = table.Column<string>(nullable: true),
                    NumeroUnidades = table.Column<string>(nullable: true),
                    UnidadesPorAndar = table.Column<string>(nullable: true),
                    NumeroElevadores = table.Column<string>(nullable: true),
                    NumeroVagas = table.Column<string>(nullable: true),
                    LazerJson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empreendimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecursosGraficos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteAppId = table.Column<long>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    EmpreendimentoId = table.Column<long>(nullable: false),
                    Recurso = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    RecursoFull = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursosGraficos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecursosGraficos_Empreendimentos_EmpreendimentoId",
                        column: x => x.EmpreendimentoId,
                        principalTable: "Empreendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecursosGraficos_Empreendimentos_EmpreendimentoId1",
                        column: x => x.EmpreendimentoId,
                        principalTable: "Empreendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecursosGraficos_EmpreendimentoId",
                table: "RecursosGraficos",
                column: "EmpreendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_RecursosGraficos_EmpreendimentoId1",
                table: "RecursosGraficos",
                column: "EmpreendimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "RecursosGraficos");

            migrationBuilder.DropTable(
                name: "Empreendimentos");
        }
    }
}
