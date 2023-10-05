using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jogoRPG.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoQuest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quest",
                columns: table => new
                {
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Raridade = table.Column<string>(type: "TEXT", nullable: false),
                    MinimoNivel = table.Column<int>(type: "INTEGER", nullable: false),
                    Recompensa = table.Column<string>(type: "TEXT", nullable: false),
                    Objetivo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quest", x => x.Nome);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quest");
        }
    }
}
