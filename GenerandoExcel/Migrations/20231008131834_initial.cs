using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenerandoExcel.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Ezequiel" });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 2, "Georgina" });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 3, "Francisco" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
