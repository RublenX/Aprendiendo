using Microsoft.EntityFrameworkCore.Migrations;

namespace EFEjemplo.Migrations
{
    public partial class AddEntidadesAutorAlbum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Canciones",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Canciones",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Canciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Canciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Albumnes",
                columns: table => new
                {
                    AlbumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albumnes", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    AutorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.AutorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_AlbumId",
                table: "Canciones",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_AutorId",
                table: "Canciones",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Canciones_Albumnes_AlbumId",
                table: "Canciones",
                column: "AlbumId",
                principalTable: "Albumnes",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Canciones_Autores_AutorId",
                table: "Canciones",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "AutorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Canciones_Albumnes_AlbumId",
                table: "Canciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Canciones_Autores_AutorId",
                table: "Canciones");

            migrationBuilder.DropTable(
                name: "Albumnes");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Canciones_AlbumId",
                table: "Canciones");

            migrationBuilder.DropIndex(
                name: "IX_Canciones_AutorId",
                table: "Canciones");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Canciones");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Canciones");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Canciones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Canciones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
