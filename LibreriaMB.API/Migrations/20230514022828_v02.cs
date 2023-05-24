using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaMB.API.Migrations
{
    /// <inheritdoc />
    public partial class v02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Libreria_LibreriaId",
                table: "Libro");

            migrationBuilder.AlterColumn<int>(
                name: "LibreriaId",
                table: "Libro",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Libreria_LibreriaId",
                table: "Libro",
                column: "LibreriaId",
                principalTable: "Libreria",
                principalColumn: "LibreriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Libreria_LibreriaId",
                table: "Libro");

            migrationBuilder.AlterColumn<int>(
                name: "LibreriaId",
                table: "Libro",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Libreria_LibreriaId",
                table: "Libro",
                column: "LibreriaId",
                principalTable: "Libreria",
                principalColumn: "LibreriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
