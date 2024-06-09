using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okul.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblOgrDers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    DersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOgrDers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOgrDers_tblDersler_DersId",
                        column: x => x.DersId,
                        principalTable: "tblDersler",
                        principalColumn: "Dersid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOgrDers_tblOgrenciler_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "tblOgrenciler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOgrDers_DersId",
                table: "tblOgrDers",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOgrDers_OgrenciId",
                table: "tblOgrDers",
                column: "OgrenciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOgrDers");
        }
    }
}
