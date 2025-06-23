using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingOnline.Migrations
{
    /// <inheritdoc />
    public partial class FixCatalogoScarpe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_catalogo_Scarpes",
                table: "catalogo_Scarpes");

            migrationBuilder.RenameTable(
                name: "catalogo_Scarpes",
                newName: "CatalogoScarpe");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CatalogoScarpe",
                newName: "Nome");

            migrationBuilder.AddColumn<string>(
                name: "Descrizione",
                table: "CatalogoScarpe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImmagineUrl",
                table: "CatalogoScarpe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "CatalogoScarpe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogoScarpe",
                table: "CatalogoScarpe",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogoScarpe",
                table: "CatalogoScarpe");

            migrationBuilder.DropColumn(
                name: "Descrizione",
                table: "CatalogoScarpe");

            migrationBuilder.DropColumn(
                name: "ImmagineUrl",
                table: "CatalogoScarpe");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "CatalogoScarpe");

            migrationBuilder.RenameTable(
                name: "CatalogoScarpe",
                newName: "catalogo_Scarpes");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "catalogo_Scarpes",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_catalogo_Scarpes",
                table: "catalogo_Scarpes",
                column: "Id");
        }
    }
}
