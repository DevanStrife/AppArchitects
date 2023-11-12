using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHILL_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class CoordinateFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinate_Photos_PhotoId",
                table: "Coordinate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coordinate",
                table: "Coordinate");

            migrationBuilder.RenameTable(
                name: "Coordinate",
                newName: "Coordinates");

            migrationBuilder.RenameIndex(
                name: "IX_Coordinate_PhotoId",
                table: "Coordinates",
                newName: "IX_Coordinates_PhotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Photos_PhotoId",
                table: "Coordinates",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Photos_PhotoId",
                table: "Coordinates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates");

            migrationBuilder.RenameTable(
                name: "Coordinates",
                newName: "Coordinate");

            migrationBuilder.RenameIndex(
                name: "IX_Coordinates_PhotoId",
                table: "Coordinate",
                newName: "IX_Coordinate_PhotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coordinate",
                table: "Coordinate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinate_Photos_PhotoId",
                table: "Coordinate",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
