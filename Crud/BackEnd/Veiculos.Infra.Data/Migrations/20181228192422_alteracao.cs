using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHome.Infra.Data.Migrations
{
    public partial class alteracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarcadorPrimeiro",
                table: "Empreendimentos");

            migrationBuilder.DropColumn(
                name: "MarcadorSegundo",
                table: "Empreendimentos");

            migrationBuilder.DropColumn(
                name: "MarcadorTerceiro",
                table: "Empreendimentos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MarcadorPrimeiro",
                table: "Empreendimentos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarcadorSegundo",
                table: "Empreendimentos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarcadorTerceiro",
                table: "Empreendimentos",
                nullable: true);
        }
    }
}
