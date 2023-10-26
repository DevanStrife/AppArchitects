using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHILL_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class expert_connection_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experts_Photos_PhotoId",
                table: "Experts");

            migrationBuilder.DropIndex(
                name: "IX_Experts_PhotoId",
                table: "Experts");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Experts");

            migrationBuilder.CreateTable(
                name: "ExpertPhoto",
                columns: table => new
                {
                    ExpertsId = table.Column<int>(type: "int", nullable: false),
                    PhotosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertPhoto", x => new { x.ExpertsId, x.PhotosId });
                    table.ForeignKey(
                        name: "FK_ExpertPhoto_Experts_ExpertsId",
                        column: x => x.ExpertsId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertPhoto_Photos_PhotosId",
                        column: x => x.PhotosId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpertPhoto_PhotosId",
                table: "ExpertPhoto",
                column: "PhotosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpertPhoto");

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Experts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experts_PhotoId",
                table: "Experts",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experts_Photos_PhotoId",
                table: "Experts",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id");
        }
    }
}
