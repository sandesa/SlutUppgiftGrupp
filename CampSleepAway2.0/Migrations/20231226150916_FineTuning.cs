using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepAway2._0.Migrations
{
    /// <inheritdoc />
    public partial class FineTuning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabins_Councelors_CouncelorId",
                table: "Cabins");

            migrationBuilder.DropIndex(
                name: "IX_Cabins_CouncelorId",
                table: "Cabins");

            migrationBuilder.DropColumn(
                name: "CouncelorId",
                table: "Cabins");

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouncelorId = table.Column<int>(type: "int", nullable: true),
                    CabinId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Cabins_CabinId",
                        column: x => x.CabinId,
                        principalTable: "Cabins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Councelors_CouncelorId",
                        column: x => x.CouncelorId,
                        principalTable: "Councelors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CamperId = table.Column<int>(type: "int", nullable: false),
                    CabinId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stays_Cabins_CabinId",
                        column: x => x.CabinId,
                        principalTable: "Cabins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stays_Campers_CamperId",
                        column: x => x.CamperId,
                        principalTable: "Campers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CabinId",
                table: "Assignments",
                column: "CabinId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CouncelorId",
                table: "Assignments",
                column: "CouncelorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stays_CabinId",
                table: "Stays",
                column: "CabinId");

            migrationBuilder.CreateIndex(
                name: "IX_Stays_CamperId",
                table: "Stays",
                column: "CamperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Stays");

            migrationBuilder.AddColumn<int>(
                name: "CouncelorId",
                table: "Cabins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cabins_CouncelorId",
                table: "Cabins",
                column: "CouncelorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabins_Councelors_CouncelorId",
                table: "Cabins",
                column: "CouncelorId",
                principalTable: "Councelors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
