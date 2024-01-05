using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepAway2._0.Migrations
{
    /// <inheritdoc />
    public partial class AddedAnnotationsAndDidSomeOtherQualityOfLifeStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Visits_VisitsId",
                table: "NextOfKins");

            migrationBuilder.DropForeignKey(
                name: "FK_Stays_Cabins_CabinId",
                table: "Stays");

            migrationBuilder.DropForeignKey(
                name: "FK_Stays_Campers_CamperId",
                table: "Stays");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stays",
                table: "Stays");

            migrationBuilder.RenameTable(
                name: "Stays",
                newName: "CamperStays");

            migrationBuilder.RenameColumn(
                name: "VisitsId",
                table: "NextOfKins",
                newName: "VisitId");

            migrationBuilder.RenameIndex(
                name: "IX_NextOfKins_VisitsId",
                table: "NextOfKins",
                newName: "IX_NextOfKins_VisitId");

            migrationBuilder.RenameIndex(
                name: "IX_Stays_CamperId",
                table: "CamperStays",
                newName: "IX_CamperStays_CamperId");

            migrationBuilder.RenameIndex(
                name: "IX_Stays_CabinId",
                table: "CamperStays",
                newName: "IX_CamperStays_CabinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CamperStays",
                table: "CamperStays",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CouncelorAssignments",
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
                    table.PrimaryKey("PK_CouncelorAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouncelorAssignments_Cabins_CabinId",
                        column: x => x.CabinId,
                        principalTable: "Cabins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouncelorAssignments_Councelors_CouncelorId",
                        column: x => x.CouncelorId,
                        principalTable: "Councelors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CouncelorAssignments_CabinId",
                table: "CouncelorAssignments",
                column: "CabinId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CouncelorAssignments_CouncelorId",
                table: "CouncelorAssignments",
                column: "CouncelorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CamperStays_Cabins_CabinId",
                table: "CamperStays",
                column: "CabinId",
                principalTable: "Cabins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CamperStays_Campers_CamperId",
                table: "CamperStays",
                column: "CamperId",
                principalTable: "Campers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Visits_VisitId",
                table: "NextOfKins",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CamperStays_Cabins_CabinId",
                table: "CamperStays");

            migrationBuilder.DropForeignKey(
                name: "FK_CamperStays_Campers_CamperId",
                table: "CamperStays");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Visits_VisitId",
                table: "NextOfKins");

            migrationBuilder.DropTable(
                name: "CouncelorAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CamperStays",
                table: "CamperStays");

            migrationBuilder.RenameTable(
                name: "CamperStays",
                newName: "Stays");

            migrationBuilder.RenameColumn(
                name: "VisitId",
                table: "NextOfKins",
                newName: "VisitsId");

            migrationBuilder.RenameIndex(
                name: "IX_NextOfKins_VisitId",
                table: "NextOfKins",
                newName: "IX_NextOfKins_VisitsId");

            migrationBuilder.RenameIndex(
                name: "IX_CamperStays_CamperId",
                table: "Stays",
                newName: "IX_Stays_CamperId");

            migrationBuilder.RenameIndex(
                name: "IX_CamperStays_CabinId",
                table: "Stays",
                newName: "IX_Stays_CabinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stays",
                table: "Stays",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinId = table.Column<int>(type: "int", nullable: false),
                    CouncelorId = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CabinId",
                table: "Assignments",
                column: "CabinId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CouncelorId",
                table: "Assignments",
                column: "CouncelorId");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Visits_VisitsId",
                table: "NextOfKins",
                column: "VisitsId",
                principalTable: "Visits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stays_Cabins_CabinId",
                table: "Stays",
                column: "CabinId",
                principalTable: "Cabins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stays_Campers_CamperId",
                table: "Stays",
                column: "CamperId",
                principalTable: "Campers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
