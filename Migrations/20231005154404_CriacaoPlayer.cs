using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jogoRPG.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Classe = table.Column<string>(type: "TEXT", nullable: false),
                    Nivel = table.Column<int>(type: "INTEGER", nullable: false),
                    Forca = table.Column<int>(type: "INTEGER", nullable: true),
                    Velocidade = table.Column<int>(type: "INTEGER", nullable: true),
                    Inteligencia = table.Column<int>(type: "INTEGER", nullable: true),
                    Resistencia = table.Column<int>(type: "INTEGER", nullable: true),
                    Vida = table.Column<int>(type: "INTEGER", nullable: true),
                    qntBoss = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Nome);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
