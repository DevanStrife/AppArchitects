using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHILL_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseRehaul : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Photos_PhotoId",
                table: "Labels");

            migrationBuilder.DropTable(
                name: "Photo_Coordinates");

            migrationBuilder.RenameColumn(
                name: "PhotoId",
                table: "Labels",
                newName: "ExpertsId");

            migrationBuilder.RenameIndex(
                name: "IX_Labels_PhotoId",
                table: "Labels",
                newName: "IX_Labels_ExpertsId");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Coordinate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X1 = table.Column<float>(type: "real", nullable: false),
                    Y1 = table.Column<float>(type: "real", nullable: false),
                    X2 = table.Column<float>(type: "real", nullable: false),
                    Y2 = table.Column<float>(type: "real", nullable: false),
                    X3 = table.Column<float>(type: "real", nullable: false),
                    Y3 = table.Column<float>(type: "real", nullable: false),
                    X4 = table.Column<float>(type: "real", nullable: false),
                    Y4 = table.Column<float>(type: "real", nullable: false),
                    PhotoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordinate_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coordinate_PhotoId",
                table: "Coordinate",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Experts_ExpertsId",
                table: "Labels",
                column: "ExpertsId",
                principalTable: "Experts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Experts_ExpertsId",
                table: "Labels");

            migrationBuilder.DropTable(
                name: "Coordinate");

            migrationBuilder.RenameColumn(
                name: "ExpertsId",
                table: "Labels",
                newName: "PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_Labels_ExpertsId",
                table: "Labels",
                newName: "IX_Labels_PhotoId");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Photo_Coordinates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    X1 = table.Column<float>(type: "real", nullable: false),
                    X2 = table.Column<float>(type: "real", nullable: false),
                    X3 = table.Column<float>(type: "real", nullable: false),
                    X4 = table.Column<float>(type: "real", nullable: false),
                    Y1 = table.Column<float>(type: "real", nullable: false),
                    Y2 = table.Column<float>(type: "real", nullable: false),
                    Y3 = table.Column<float>(type: "real", nullable: false),
                    Y4 = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo_Coordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Coordinates_Labels_Id",
                        column: x => x.Id,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Photos_PhotoId",
                table: "Labels",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id");
        }
    }
}
