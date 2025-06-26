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
                name: "PKcatalogoScarpes",
                table: "catalogoScarpes");

            migrationBuilder.RenameTable(
                name: "catalogoScarpes",
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
                newName: "catalogoScarpes");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "catalogoScarpes",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PKcatalogoScarpes",
                table: "catalogoScarpes",
                column: "Id");
        }
    }
}
