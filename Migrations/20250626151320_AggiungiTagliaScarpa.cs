using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingOnline.Migrations
{
    /// <inheritdoc />
    public partial class AggiungiTagliaScarpa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TagliaScarpa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Taglia = table.Column<int>(type: "int", nullable: false),
                    Quantita = table.Column<int>(type: "int", nullable: false),
                    CatalogoScarpaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagliaScarpa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagliaScarpa_CatalogoScarpe_CatalogoScarpaId",
                        column: x => x.CatalogoScarpaId,
                        principalTable: "CatalogoScarpe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagliaScarpa_CatalogoScarpaId",
                table: "TagliaScarpa",
                column: "CatalogoScarpaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagliaScarpa");
        }
    }
}
