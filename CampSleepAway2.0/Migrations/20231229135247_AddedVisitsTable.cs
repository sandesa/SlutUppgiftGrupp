using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepAway2._0.Migrations
{
    /// <inheritdoc />
    public partial class AddedVisitsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisitsId",
                table: "NextOfKins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CamperId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Campers_CamperId",
                        column: x => x.CamperId,
                        principalTable: "Campers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_VisitsId",
                table: "NextOfKins",
                column: "VisitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_CamperId",
                table: "Visits",
                column: "CamperId");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Visits_VisitsId",
                table: "NextOfKins",
                column: "VisitsId",
                principalTable: "Visits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Visits_VisitsId",
                table: "NextOfKins");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_VisitsId",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "VisitsId",
                table: "NextOfKins");
        }
    }
}
