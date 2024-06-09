using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okul.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblDersler",
                columns: table => new
                {
                    Dersid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dersad = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    Kredi = table.Column<byte>(type: "tinyint", nullable: false),
                    DersKod = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDersler", x => x.Dersid);
                });

            migrationBuilder.CreateTable(
                name: "tblOgrenciler",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    Soyad = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    Numara = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOgrenciler", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDersler");

            migrationBuilder.DropTable(
                name: "tblOgrenciler");
        }
    }
}
